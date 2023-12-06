namespace Zamiux.Web.Utils.ImageHandler
{
    public static class PathTools
    {
        #region Products

        public static string SliderImage = "/images/sliders/";
        public static string SliderImageAbs = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sliders/");
        public static string SliderImageThumb = "/images/sliders/thumbs/";
        public static string SliderImageThumbAbs = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/sliders/thumbs/");

        #endregion
    }
}