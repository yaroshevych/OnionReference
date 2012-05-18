using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookstore.Core;
using System.Globalization;
using NLog;

namespace Bookstore.Infrastructure
{
    public class Logger : NLog.Logger, ILogger
    {
        public void Debug(Exception exception, string format, params object[] args)
        {
            if (!base.IsDebugEnabled) return;
            base.DebugException(string.Format(CultureInfo.InvariantCulture, format, args), exception);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            if (!base.IsErrorEnabled) return;
            base.ErrorException(string.Format(CultureInfo.InvariantCulture, format, args), exception);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (!base.IsFatalEnabled) return;
            base.FatalException(string.Format(CultureInfo.InvariantCulture, format, args), exception);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            if (!base.IsInfoEnabled) return;
            base.InfoException(string.Format(CultureInfo.InvariantCulture, format, args), exception);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            if (!base.IsTraceEnabled) return;
            base.TraceException(string.Format(CultureInfo.InvariantCulture, format, args), exception);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            if (!base.IsWarnEnabled) return;
            base.WarnException(string.Format(CultureInfo.InvariantCulture, format, args), exception);
        }

        public void Debug(Exception exception)
        {
            this.Debug(exception, string.Empty);
        }

        public void Error(Exception exception)
        {
            this.Error(exception, string.Empty);
        }

        public void Fatal(Exception exception)
        {
            this.Fatal(exception, string.Empty);
        }

        public void Info(Exception exception)
        {
            this.Info(exception, string.Empty);
        }

        public void Trace(Exception exception)
        {
            this.Trace(exception, string.Empty);
        }

        public void Warn(Exception exception)
        {
            this.Warn(exception, string.Empty);
        }

        public void Debug(Func<string> messageFunc)
        {
            Debug(new LogMessageGenerator(messageFunc));
        }

        public void Error(Func<string> messageFunc)
        {
            Error(new LogMessageGenerator(messageFunc));
        }

        public void Fatal(Func<string> messageFunc)
        {
            Fatal(new LogMessageGenerator(messageFunc));
        }

        public void Info(Func<string> messageFunc)
        {
            Info(new LogMessageGenerator(messageFunc));
        }

        public void Trace(Func<string> messageFunc)
        {
            Trace(new LogMessageGenerator(messageFunc));
        }

        public void Warn(Func<string> messageFunc)
        {
            Warn(new LogMessageGenerator(messageFunc));
        }
    }
}
