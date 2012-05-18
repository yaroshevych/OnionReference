using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Core;

namespace Bookstore.UI.Common
{
    [ControllerLogging]
    public class LoggingController<T> : Controller, ILoggingController
    {
        private static ILogger logger;

        protected LoggingController(ILoggerFactory factory)
        {
            if (logger == null)
                logger = factory.Create<T>();
        }

        public ILogger Logger
        {
            get { return logger; }
        }
    }

    public interface ILoggingController
    {
        ILogger Logger { get; }
    }
}