using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Core
{
    public interface ILoggerFactory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        ILogger Create<T>();
    }

    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsTraceEnabled { get; }
        bool IsWarnEnabled { get; }

        void Debug(Exception exception);
        void Debug(string format, params object[] args);
        void Debug(Exception exception, string format, params object[] args);
        void Debug(Func<string> messageFunc);

        void Error(Exception exception);
        void Error(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
        void Error(Func<string> messageFunc);

        void Fatal(Exception exception);
        void Fatal(string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);
        void Fatal(Func<string> messageFunc);

        void Info(Exception exception);
        void Info(string format, params object[] args);
        void Info(Exception exception, string format, params object[] args);
        void Info(Func<string> messageFunc);

        void Trace(Exception exception);
        void Trace(string format, params object[] args);
        void Trace(Exception exception, string format, params object[] args);
        void Trace(Func<string> messageFunc);

        void Warn(Exception exception);
        void Warn(string format, params object[] args);
        void Warn(Exception exception, string format, params object[] args);
        void Warn(Func<string> messageFunc);
    }
}
