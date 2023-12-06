namespace Zamiux.Web.Utils
{
    public static class PathExtension
    {
        #region User Content
        public static string UserProfileContentOrgin = "/zamiux/content/img/user/userprofile/";
        public static string UserProfileContentServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/user/userprofile/");
        public static string UserProfileContentOrginThumb = "/zamiux/content/img/user/userprofile/Thumb/";
        public static string UserProfileContentServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/user/userprofile/Thumb/");

        public static string UserBackgroundContentOrgin = "/zamiux/content/img/user/userbackground/";
        public static string UserBackgroundContentServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/user/userbackground/");
        public static string UserBackgroundContentOrginThumb = "/zamiux/content/img/user/userbackground/Thumb/";
        public static string UserBackgroundContentServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/user/userbackground/Thumb/");
        #endregion

        #region Logo
        public static string logoContentOrgin = "/zamiux/content/img/logo/";
        public static string logoContentServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/logo/");
        public static string logoContentOrginThumb = "/zamiux/content/img/logo/Thumb/";
        public static string logoContentServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/logo/Thumb/");

        public static string logoContentOrginDark = "/zamiux/content/img/logo/dark/";
        public static string logoContentServerDark = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/logo/dark/");
        public static string logoContentOrginDarkThumb = "/zamiux/content/img/logo/dark/Thumb/";
        public static string logoContentServerDarkThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/zamiux/content/img/logo/dark/Thumb/");
        #endregion
    }
}
