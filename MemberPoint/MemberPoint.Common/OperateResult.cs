using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPoint.Common
{
    public enum ResultStatus
    {
        Error = -1,
        Success = 1
    }


    public class OperateResult
    {
        /// <summary>
        /// 结果状态
        /// </summary>
        public ResultStatus ResultStatus { get; set; }
        /// <summary>
        /// 消息提示
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resultStatus"></param>
        /// <param name="msg"></param>
        public OperateResult(ResultStatus resultStatus, string msg)
        {
            this.ResultStatus = resultStatus;
            this.Msg = msg;
        }
        public OperateResult(ResultStatus resultStatus, string msg, object data)
        {
            this.ResultStatus = resultStatus;
            this.Msg = msg;
            this.Data = data;
        }

    }
}
