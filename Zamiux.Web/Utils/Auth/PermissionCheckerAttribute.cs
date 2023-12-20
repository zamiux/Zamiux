using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Zamiux.Web.Context;

namespace Zamiux.Web.Utils.Auth
{
    // baraye in ke ye class ro be Attribute[] tabdil konim , bayad az 2 ta interface ers bari kone
    // 1- AuthorizeAttribute , 2- IAuthorizationFilter
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        // agar bekhaei baraye Attribute[] parameter voroodi bezari
        // bayad hatman az dar in class Ctor tarif koni va parameter voroodi bedi.

        //ctor
        private readonly string _permissionName;
        public PermissionCheckerAttribute(string permissionName)
        {
                _permissionName = permissionName;
        }
        // in parameter : permissionName hokm input voroodi Attribute[] hastesh.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectResult("/login");
            }
            // 1- who is user?
            int userid = context.HttpContext.User.GetCurrentUserID();

            // ye new methodi ke mishe bahash az tarigh HttpContext be Entities Dastresi dasht.
            // class : RequestServices az jense IServiceProvider
            var db_context = context.HttpContext.RequestServices.GetRequiredService<ZamiuxDbContext>();
            var user_data = db_context.users.Single(u => u.Id == userid);

            // 3- check permission name is user permissions
            if (!user_data.isSuperUser) // is not admin
            {
                // 2- get user permissions / roles
                var HasPermissions = db_context.UserRoles
                    .Include(ur => ur.Role)
                    .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(p => p.Permission)
                    .Any(ur => ur.UserId == userid && ur.Role.RolePermissions
                    .Any(r => r.Permission.TitlePermissionFa == _permissionName));

                if (!HasPermissions) // check permission 
                {
                    context.Result = new RedirectResult("/");
                }
            }

            throw new NotImplementedException();
        }
    }
}
