using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace VHApp.AOP
{
    public class CallLogger:IInterceptor
    {
        public CallLogger()
        {
        }

        /// <summary>
        /// 拦截方法 打印被拦截的方法执行前的名称、参数和方法执行后的 返回结果
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            LogHelper.LoggerHelper.StartLog4Net();
            string module = invocation.TargetType.FullName;
            string methodName = invocation.Method.Name;
            LogHelper.LoggerHelper.WriteToFile(JsonConvert.SerializeObject(invocation.Arguments));
            //在被拦截的方法执行完毕后 继续执行
            invocation.Proceed();
            LogHelper.LoggerHelper.WriteToFile(invocation.ReturnValue.ToString());
        }
    }
}
