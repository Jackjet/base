using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Conan.Utils
{
    public class IMGUtility
    {
        public enum CutMode { None=1, WH, W, H, Cut };
        #region 根据路径 生成 缩略图
        /// <summary>
        /// 根据路径 生成 缩略图
        /// </summary>
        /// <param name="p_strSource">传回的图片路径</param>
        /// <param name="p_strSave">图片保存的新路径</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="mode"></param>
        /// <param name="q">质量</param>
        public static void Thumbnail(string p_strSource, string p_strSave, int width, int height, CutMode mode,long q=100L)
        {
            FileInfo fileInfo = new FileInfo(p_strSave);
            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();

            Image image = Image.FromFile(p_strSource);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num3 = image.Width;
            int num4 = image.Height;

            switch (mode)
            {
                case CutMode.WH:
                    break;
                case CutMode.W:
                    num2 = image.Height * width / image.Width;
                    break;
                case CutMode.H:
                    num = image.Width * height / image.Height;
                    break;

                case CutMode.Cut:
                    if ((double)image.Width / (double)image.Height < (double)num / (double)num2)
                    {
                        num4 = image.Height;
                        num3 = image.Height * num / num2;
                        y = 0;
                        x = (image.Width - num3) / 2;
                        break;
                    }
                    num3 = image.Width;
                    num4 = image.Width * height / num;
                    x = 0;
                    y = (image.Height - num4) / 2;
                    break;
                default:
                    if (image.Width > image.Height)
                        num2 = image.Height * width / image.Width;
                    else
                        num = image.Width * height / image.Height;
                    break;
            }

            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.White);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
            try
            {
                ImageCodecInfo encoderInfo = IMGUtility.GetEncoderInfo("image/jpeg");
                Encoder quality = Encoder.Quality;
                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(quality, q);
                encoderParameters.Param[0] = encoderParameter;
                image2.Save(p_strSave, encoderInfo, encoderParameters);
            }
            catch (Exception ex)
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
                throw ex;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }
        #endregion
        #region 根据文件流 生成 缩略图 
        /// <summary>
        /// 根据文件流 生成 缩略图  
        /// </summary>
        /// <param name="s">文件流</param> 
        /// <param name="p_strSave">图片保存的新路径</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="mode"></param>
        /// <param name="q">质量</param>
        public static void Thumbnail(Stream s, string p_strSave, int width, int height, CutMode mode, long q = 100L,string ext="jpg")
        {
            FileInfo fileInfo = new FileInfo(p_strSave);
            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();

            Image image = Image.FromStream(s);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num3 = image.Width;
            int num4 = image.Height;
            switch (mode)
            {
                case CutMode.WH:
                    break;
                case CutMode.W:
                    num2 = image.Height * width / image.Width;
                    break;
                case CutMode.H:
                    num = image.Width * height / image.Height;
                    break;

                case CutMode.Cut:
                    if ((double)image.Width / (double)image.Height < (double)num / (double)num2)
                    {
                        num4 = image.Height;
                        num3 = image.Height * num / num2;
                        y = 0;
                        x = (image.Width - num3) / 2;
                        break;
                    }
                    num3 = image.Width;
                    num4 = image.Width * height / num;
                    x = 0;
                    y = (image.Height - num4) / 2;
                    break;
                default:
                    if (image.Width > image.Height)
                        num2 = image.Height * width / image.Width;
                    else
                        num = image.Width * height / image.Height;
                    break;
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.White);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
            try
            {
                ImageCodecInfo encoderInfo = IMGUtility.GetEncoderInfo("image/jpeg");
                Encoder quality = Encoder.Quality;
                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(quality, q);
                encoderParameters.Param[0] = encoderParameter;
                image2.Save(p_strSave, encoderInfo, encoderParameters);
            }
            catch (Exception ex)
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
                throw ex;
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }
        #endregion
        public static bool Crop(string p_strSource, string p_strSave, int x, int y, int w, int h, int width, int height)
        {
            FileInfo fileInfo = new FileInfo(p_strSave);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
            bool result;
            using (Image image = Image.FromFile(p_strSource))
            {
                try
                {
                    Image image2 = new Bitmap(width, height);
                    Graphics graphics = Graphics.FromImage(image2);
                    graphics.InterpolationMode = InterpolationMode.High;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.Clear(Color.White);
                    graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                    image2.Save(p_strSave);
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < imageEncoders.Length; i++)
            {
                if (imageEncoders[i].MimeType == mimeType)
                {
                    return imageEncoders[i];
                }
            }
            return null;
        }
    }
}
