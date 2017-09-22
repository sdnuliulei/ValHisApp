using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.DynamicProxy;

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
            string methodName = invocation.Method.Name;
            string before = "1";
            //在被拦截的方法执行完毕后 继续执行
            invocation.Proceed();

            string end = "2";
        }
    }
}
