using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Core
{
    public enum OptState { Success = 1, Error = 2, Unauthorized = 3 }

    public class OptResult
    {
        /// <summary>
        /// 返回成功信息
        /// </summary>
        public OptResult()
        {
            State = OptState.Success;
            Msg = string.Empty;
            Data = null;
            GoBackUrl = "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public OptResult(OptState state, string msg, dynamic data = null, string goBackUrl = "")
        {
            State = state;
            Msg = msg;
            Data = data;
            GoBackUrl = goBackUrl;
        }
        /// <summary>
        /// 返回失败信息
        /// </summary>
        /// <param name="msg"></param>
        public OptResult(string msg, string goBackUrl = "")
        {
            State = OptState.Error;
            Msg = msg;
            Data = null;
            GoBackUrl = goBackUrl;
        }

        public OptState State { get; set; }

        public string Msg { get; set; }

        public dynamic Data { get; set; }

        public string GoBackUrl { get; set; }

        /// <summary>
        /// 设置成功时的提示
        /// </summary>
        /// <param name="info"></param>
        /// <param name="over"></param>
        public void SucMsg(string msg, string goBackUrl = "", bool over = false)
        {
            if (over)
            {
                if (State == OptState.Success)
                {
                    Msg = msg;
                    GoBackUrl = goBackUrl;
                }

            }
            else
            {
                if (State == OptState.Success && string.IsNullOrWhiteSpace(Msg))
                {
                    Msg = msg;
                    GoBackUrl = goBackUrl;
                }
            }
        }
    }
}

