using Microsoft.VisualBasic;

namespace SWD392_Project.BussinessLayer.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ROUTE_LOGIN = "/login";
        private const string ROUTE_DASHBOARD = "/dashboard";
        private const string ROUTE_HOME = "/";
        private const string USERID_KEY = "userId";
        private const string ROLEID_KEY = "roleId";

        public AuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            int? userId = Helper.SessionHelper.GetIdFromSession(context.Session, USERID_KEY);
            int? roleId = Helper.SessionHelper.GetIdFromSession(context.Session, ROLEID_KEY);

            // check if not logged in and route is not /login => redirect to login
            if (!userId.HasValue && !context.Request.Path.Equals(ROUTE_LOGIN, StringComparison.OrdinalIgnoreCase))
            {
                // No active session, redirect to login page
                context.Response.Redirect(ROUTE_LOGIN);
                return;
            }

            // check if logged in and route is /login => redirect to home
            if (userId.HasValue && context.Request.Path.Equals(ROUTE_LOGIN, StringComparison.OrdinalIgnoreCase))
            {
                // Active session, redirect to home page
                context.Response.Redirect(ROUTE_HOME);
                return;
            }

            // check role of user when go to /dashboard
            if (userId.HasValue && context.Request.Path.Equals(ROUTE_DASHBOARD, StringComparison.OrdinalIgnoreCase))
            {
                // check if user is not admin => redirect to home page
                if (roleId != 1)
                {
                    context.Response.Redirect(ROUTE_HOME);
                    return;
                }
            }

            // Active session, proceed to next middleware
            await _next(context);
        }
    }
}
