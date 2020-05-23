第一步 打开主库(master)的mysql安装目录，打开配置文件my.ini。在[mysql]的后面添加如下代码

server-id=1 #master的标示

log-bin=mysql-bin #slave会基于此log-bin来做replication(复制)

binlog-do-db=psj #用于master-slave的具体数据库

binlog_ignore_db=mysql #不用于master-slave的具体数据库

binlog_ignore_db=information_schema #和binlog-do-db一样，可以设置多个

查看主库状态
show master status;

第二部从库配置
server-id=2 #比刚刚主库设定的server-id大就行了，且从库之间不能有一样

log-bin=mysql-bin #slave会基于此log-bin来做replication

replicate-do-db=psj #用于master-slave的具体数据库

保存后启动从库的mysql服务，进入mysql的命令行，输入如下代码：

先停止它的slave
stop slave
再改变它的master
change master to master_host='192.168.0.100',master_user='root',master_password='7020110',master_log_file='mysql-bin.000003',master_log_pos=412
再启动它的slave
start slave;
然后再输入如下代码，检查是否成功
show slave status


mysql replication 中slave机器上有两个关键的进程，死一个都不行，一个是slave_sql_running，一个是Slave_IO_Running，一个负责与主机的io通信，一个负责自己的slave mysql进程。
如果主从数据出问题(数据不同步)

如果是Slave_SQL_Running：no
方式一（忽略错误后，继续同步 ）
stop slave;                                                      
SET GLOBAL SQL_SLAVE_SKIP_COUNTER=1; START SLAVE;            
start slave;                                                      
show slave status
方式二 (重新做主从，完全同步 )
stop slave
change master to master_host='192.168.0.100',master_user='root',master_password='7020110',master_log_file='mysql-bin.000003',master_log_pos=412
start slave;
show slave status

如果是slave_io_running：no
show master status (查看主服务器)
show slave status (在从服务器上查看)
（看是否MASTER_LOG_FILE不对应）
slave stop;                 
CHANGE MASTER TO MASTER_LOG_FILE='mysql-bin.000026', MASTER_LOG_POS=0;  
slave start;                               
show slave status



