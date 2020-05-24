using System;
using ServiceStack.Redis;
using ServiceStack.Logging;
using System.Configuration;
using ServiceStack.Common.Extensions;

namespace Common
{
    //主从架构的Redis的读写其实和单一Redis实例的读写差不多，只是部分配置和读取区分了主从
    //不过我们需要注意的是：ServiceStack.Redis中GetClient() 的这个方法，默认只能拿到Master Redis中获取连接，而拿不到Slave的readonly连接。
    //这样Slave起到了冗余备份的作用，读的功能没有发挥出来，如果并发请求太多的话，则Redis的性能会有影响。
    //因此，我们需要的写入和读取的时候做一个区分，写入的时候，调用client.GetClient() 来获取writeHosts的Master的Redis链接。
    //读取的时候则调用client.GetReadOnlyClient() 来获取的readonlyHost的Slave的Redis链接，或者可以直接使用client.GetCacheClient() 来获取一个连接，
    //他会在写的时候调用GetClient获取连接，读的时候调用GetReadOnlyClient获取连接，这样可以做到读写分离，从而利用Redis的主从复制功能。


    /// <summary>
    /// Redis缓存帮助类
    /// </summary>
    public class RedisCacheHelper
    {
        private static readonly PooledRedisClientManager pool = null;
        //private static readonly string[] redisHosts = null;
        private static readonly string[] writeHosts = null;
        private static readonly string[] readHosts = null;
        public static int RedisMaxReadPool = int.Parse(ConfigurationManager.AppSettings["redis_max_read_pool"]);
        public static int RedisMaxWritePool = int.Parse(ConfigurationManager.AppSettings["redis_max_write_pool"]);

        ///// <summary>
        ///// 单个
        ///// </summary>
        //static RedisCacheHelper()
        //{
        //    var redisHostStr = ConfigurationManager.AppSettings["redis_server_session"];

        //    if (!string.IsNullOrEmpty(redisHostStr))
        //    {
        //        redisHosts = redisHostStr.Split(',');

        //        if (redisHosts.Length > 0)
        //        {
        //            pool = new PooledRedisClientManager(redisHosts, redisHosts,
        //                new RedisClientManagerConfig()
        //                {
        //                    MaxWritePoolSize = RedisMaxWritePool,
        //                    MaxReadPoolSize = RedisMaxReadPool,
        //                    AutoStart = true
        //                });
        //        }
        //    }
        //}

        /// <summary>
        /// 主从
        /// </summary>
        static RedisCacheHelper()
        {
            var redisMasterHost = ConfigurationManager.AppSettings["redis_server_master_session"];
            var redisSlaveHost = ConfigurationManager.AppSettings["redis_server_slave_session"];

            if (!string.IsNullOrEmpty(redisMasterHost))
            {
                writeHosts = redisMasterHost.Split(',');
                readHosts = redisSlaveHost.Split(',');

                if (readHosts.Length <= 0)
                {
                    readHosts = writeHosts;
                }
                pool = new PooledRedisClientManager(writeHosts, readHosts,
                        new RedisClientManagerConfig()
                        {
                            MaxWritePoolSize = RedisMaxWritePool,
                            MaxReadPoolSize = RedisMaxReadPool,
                            AutoStart = true
                        });
            }
        }

        /// <summary>
        /// 添加键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiry"></param>
        public static void Add<T>(string key, T value, DateTime expiry)
        {
            if (value == null)
            {
                return;
            }

            if (expiry <= DateTime.Now)
            {
                Remove(key);

                return;
            }

            try
            {
                if (pool != null)
                {
                    
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            r.Set(key, value, expiry - DateTime.Now);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}  Error:{3}", "cache", "存储", key, ex.Message);
                throw new Exception(msg);
            }

        }

        /// <summary>
        /// 添加键值对
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpiration"></param>
        public static void Add<T>(string key, T value, TimeSpan slidingExpiration)
        {
            if (value == null)
            {
                return;
            }

            if (slidingExpiration.TotalSeconds <= 0)
            {
                Remove(key);

                return;
            }

            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            r.Set(key, value, slidingExpiration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}  Error:{3}", "cache", "存储", key, ex.Message);
                throw new Exception(msg);
            }

        }


        /// <summary>
        /// 获取某个键对应的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return default(T);
            }

            T obj = default(T);

            try
            {
                if (pool != null)
                {
                    //pool.GetReadOnlyClient
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            obj = r.Get<T>(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}  Error:{3}", "cache", "获取", key, ex.Message);
                throw new Exception(msg);
            }


            return obj;
        }


        /// <summary>
        /// 移除某个键
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {                            
                            r.SendTimeout = 1000;
                            r.Remove(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}  Error:{3}", "cache", "删除", key, ex.Message);
                throw new Exception(msg);
            }

        }

        /// <summary>
        /// 是否存在某个键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            return r.ContainsKey(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}  Error:{3}", "cache", "是否存在", key, ex.Message);
                throw new Exception(msg);
            }

            return false;
        }
    }
}

