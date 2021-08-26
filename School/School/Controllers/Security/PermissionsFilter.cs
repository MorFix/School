using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SportStore.Controllers.Security;

namespace School.Controllers.Security
{
    public class PermissionsFilter : IAsyncActionFilter
    {
        public PermissionsFilter()
        {
        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var attribute = context.ActionDescriptor.EndpointMetadata.OfType<PermissionsAttribute>().FirstOrDefault();
            if (attribute == null)
            {
                return next();
            }

            var user = context.HttpContext.GetSchoolUser();
            if (user == null || !attribute.Permissions.Contains(user.PermissionsLevel)) {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);

                return Task.CompletedTask;
            }

            return next();
        }
    }
}
