using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Dto.Base
{
    public class BaseDtoResp<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回的提示信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 业务编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        public dynamic Extend { get; set; }

        public T Data { get; set; }
    }
}