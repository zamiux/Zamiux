namespace Zamiux.Web.Utils
{
    public static class PathExtension
    {
        #region User Content
        public static string UserProfileContentOrgin = "/zamiux/content/img/user/userprofile/";
        public static string UserProfileContentServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/user/userprofile/");

        public static string UserBackgroundContentOrgin = "/zamiux/content/img/user/userbackground/";
        public static string UserBackgroundContentServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/user/userbackground/");
        #endregion
    }
}
