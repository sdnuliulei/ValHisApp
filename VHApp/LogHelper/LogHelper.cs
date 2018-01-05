using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;

namespace VHApp.LogHelper
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public static class LoggerHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoggerHelper));

        public static void StartLog4Net()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory+ "log4net.config"));
            log4net.Config.XmlConfigurator.Configure();
        }

        #region 文本日志
        /// <summary>
        /// 文本日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dir"></param>
        public static void WriteToFile(string message, string dir = "")
        {
            WriteToFileInfo(() => Log.Info(message), "RollingLogFileAppender", dir);
        }

        /// <summary>
        /// 文本日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="dir"></param>
        public static void WriteToFile(string message, string error, string dir = "")
        {
            WriteToFileError(() => Log.Error(message), "RollingLogFileAppender", dir);
        }

        private static void WriteToFileInfo(Action action, string appendersName, string dir = "")
        {
            var appenders = LogManager.GetRepository().GetAppenders();
            var appender = appenders.FirstOrDefault(i => i.Name == appendersName) as RollingFileAppender;
            if (appender != null)
            {
                appender.File = string.Format("log/", DateTime.Now, dir, appendersName);
                appender.ActivateOptions();
                action();
            }
        }

        private static void WriteToFileError(Action action, string appendersName, string dir = "")
        {
            var appenders = LogManager.GetRepository().GetAppenders();
            var appender = appenders.FirstOrDefault(i => i.Name == appendersName) as RollingFileAppender;
            if (appender != null)
            {
                appender.DatePattern = "yyyy-MM-dd\".error.log\"";
                appender.File = string.Format("log/", DateTime.Now.ToString(), dir, appendersName);
                appender.ActivateOptions();
                action();
            }
        }
        #endregion
    }
}
