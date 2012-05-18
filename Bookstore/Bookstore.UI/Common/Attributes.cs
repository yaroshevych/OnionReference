using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.UI.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ControllerLoggingAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Log Trace message.
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = ((ILoggingController)filterContext.Controller).Logger;

            if (logger.IsTraceEnabled)
            {
                var args = string.Concat(filterContext.ActionParameters.Select(p => p.Key + "=\"" + p.Value + "\","));

                if (args.Length > 0)
                    args = args.Substring(0, args.Length - 1);

                logger.Trace("+{0} ({1})", filterContext.ActionDescriptor.ActionName, args);
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Log Trace and Error messages.
        /// </summary>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var logger = ((ILoggingController)filterContext.Controller).Logger;

            if (filterContext.Exception != null)
            {
                if (logger.IsErrorEnabled)
                {
                    var form = filterContext.RequestContext.HttpContext.Request.Form;
                    string args = string.Concat(form.AllKeys.Select(p => p + "=" + form[p] + ","));

                    if (args.Length > 0)
                        args = args.Substring(0, args.Length - 1);

                    logger.Error(filterContext.Exception, "{0} ({1})", filterContext.ActionDescriptor.ActionName, args);
                }
            }
            else
            {
                if (logger.IsTraceEnabled)
                    logger.Trace("-{0}", filterContext.ActionDescriptor.ActionName);
            }
        }
    }
}