using System.Security.Claims;

namespace Zamiux.Web.Utils.Auth
{
    public static class GetUserIDExtensions
    {
        public static int GetCurrentUserID(this ClaimsPrincipal principal)
        {
            // check user logined
            if (principal.Identity.IsAuthenticated)
            {
                var UserId = principal.Claims.Single(u => u.Type == ClaimTypes.NameIdentifier).Value;
                return Convert.ToInt32(UserId); 
            }
            else
            {

                return default ; 
            }
        }
    }
}
