using Microsoft.VisualBasic;

namespace SWD392_Project.BussinessLayer.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ROUTE_LOGIN = "/login";
        private const string ROUTE_REGISTER = "/register";
        private const string ROUTE_MAIN = "/Medicine/ListMedicine";
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

            // check if not logged in and route is not /login or /register => redirect to login
            if (!userId.HasValue && !context.Request.Path.Equals(ROUTE_LOGIN, StringComparison.OrdinalIgnoreCase)
                && !context.Request.Path.Equals(ROUTE_REGISTER, StringComparison.OrdinalIgnoreCase))
            {
                // No active session, redirect to login page
                context.Response.Redirect(ROUTE_LOGIN);
                return;
            }

            // Active session, proceed to next middleware
            await _next(context);
        }
    }
}
