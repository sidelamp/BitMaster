using System.Drawing;
using System.Drawing.Drawing2D;

namespace BitMaster.Helpers
{
    /// <summary>
    /// Вспомогательные методы для работы с изображениями.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Уменьшает изображение до указанного размера с качественной интерполяцией.
        /// </summary>
        public static Bitmap Scale(Image source, int width, int height)
        {
            var result = new Bitmap(width, height);
            using (var g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(source, 0, 0, width, height);
            }
            return result;
        }
    }
}
