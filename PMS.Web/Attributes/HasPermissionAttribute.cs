using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Web.Mvc;
using PMS.Common;

namespace PMS.Web.Attributes
{
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        public List<string> Permissions { get; protected set; }

        public HasPermissionAttribute(string permission)
            : this(new[] { permission })
        {
        }

        public HasPermissionAttribute(params string[] permissions)
        {
            Permissions = new List<string>(permissions);
        }

        public virtual bool HasPermission(ActionExecutingContext filterContext)
        {
            return Permissions.Any(permission => UserPrincipal.CurrentUser.PermittedActions.Contains(new Guid(permission)));
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HasPermission(filterContext))
            {
                ProccessNoPermissionResult(filterContext);
            }
        }
        public virtual void ProccessNoPermissionResult(ActionExecutingContext filterContext)
        {
            throw new SecurityException("Not permitted action");
        }
    }
}