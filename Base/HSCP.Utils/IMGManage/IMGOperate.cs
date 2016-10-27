/*
 * 作者：Ldw    
 * 日期：2016.06.27
 * 描述：咨讯
 * 修改记录：    
 * */
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conan.Utils
{
    public enum ImagePathType
    {
        员工头像,
        健康证,
        培训证,
        职业资格证,
        门店营业执照,
        门店负责人身份证照,
        门店LOGO,
        会员头像,
        产品BANNER,
        充值凭证,
        产品Icon,
        产品类别Icon,
        优惠券Icon,
        广告首页轮播图,
        广告位横栏,
        广告位边栏,
        资讯图片,
        礼品图片,
        分享红包图标,
        分享红包背景图,


        邀请送礼图标,
        邀请送礼背景图





    }
    class ImagePath
    {
        /// <summary>
        /// 类型
        /// </summary>
        public ImagePathType Type { get; set; }
        /// <summary>
        /// 宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 固定路径
        /// </summary>
        public string FixedPath { get; set; }
    }
    public class IMGOperate
    {
        #region 图片固定路径数据 （注：1.图片从小到大2.请和前台设置一致）
        /// <summary>
        /// 图片固定路径数据
        /// </summary>
        private static List<ImagePath> imagePathData = new List<ImagePath>
            {
                new ImagePath { Type = ImagePathType.产品BANNER,FixedPath="/product/banner",Width=160,Height=80},
                new ImagePath { Type = ImagePathType.产品BANNER,FixedPath="/product/banner",Width=240,Height=120},
                new ImagePath { Type = ImagePathType.产品BANNER,FixedPath="/product/banner",Width=300,Height=150},

                new ImagePath { Type = ImagePathType.产品Icon,FixedPath="/product/icon",Width=90,Height=90},
                new ImagePath { Type = ImagePathType.产品Icon,FixedPath="/product/icon",Width=116,Height=116},
                new ImagePath { Type = ImagePathType.产品Icon,FixedPath="/product/icon",Width=200,Height=200},

                 new ImagePath { Type = ImagePathType.资讯图片,FixedPath="/Information/icon",Width=90,Height=90},
                new ImagePath { Type = ImagePathType.资讯图片,FixedPath="/Information/icon",Width=116,Height=116},
                new ImagePath { Type = ImagePathType.资讯图片,FixedPath="/Information/icon",Width=200,Height=200},

                new ImagePath { Type = ImagePathType.产品类别Icon,FixedPath="/productCategory/icon",Width=90,Height=90},
                new ImagePath { Type = ImagePathType.产品类别Icon,FixedPath="/productCategory/icon",Width=116,Height=116},
                new ImagePath { Type = ImagePathType.产品类别Icon,FixedPath="/productCategory/icon",Width=200,Height=200},

                new ImagePath { Type = ImagePathType.充值凭证,FixedPath="/finance/credentials",Width = 100,Height= 100},

                new ImagePath { Type = ImagePathType.优惠券Icon,FixedPath="/coupon/icon",Width = 100,Height= 100},

                new ImagePath { Type = ImagePathType.员工头像,FixedPath="/employee/headPortrait",Width = 100,Height= 120},

                new ImagePath { Type = ImagePathType.会员头像,FixedPath="/member/headPortrait",Width = 104,Height= 144},

                new ImagePath { Type = ImagePathType.门店LOGO,FixedPath="/store/logo",Width = 100,Height= 100},

                new ImagePath { Type = ImagePathType.门店营业执照,FixedPath="/store/businessLicenseImg",Width = 200,Height=141},

                new ImagePath { Type = ImagePathType.门店负责人身份证照,FixedPath="/store/officerIDCartImg",Width = 200,Height= 141},

                new ImagePath { Type = ImagePathType.广告首页轮播图,FixedPath="/Advertising/carouselFigure",Width = 640,Height= 240},

                new ImagePath { Type = ImagePathType.广告位横栏,FixedPath="/Advertising/position",Width =380,Height=105},
                  new ImagePath { Type = ImagePathType.广告位边栏,FixedPath="/Advertising/position",Width = 185,Height= 92},

                new ImagePath { Type = ImagePathType.礼品图片,FixedPath="/Gift/Img",Width=100,Height=100},


                   new ImagePath { Type = ImagePathType.分享红包图标,FixedPath="/shares/Img",Width=100,Height=100},


                      new ImagePath { Type = ImagePathType.分享红包背景图,FixedPath="/sharesbg/Img",Width=520,Height=1000},




                             new ImagePath { Type = ImagePathType.邀请送礼图标,FixedPath="/yqsl/Img",Width=100,Height=100},


                      new ImagePath { Type = ImagePathType.邀请送礼背景图,FixedPath="/yqslbg/Img",Width=520,Height=1000},





            };
        #endregion

        #region 根据图片类型获取固定路径
        /// <summary>
        /// 根据图片类型获取固定路径
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        private static ImagePath GetPathByType(ImagePathType type)
        {
            return imagePathData.FirstOrDefault(o => o.Type == type);
        }
        /// <summary>
        /// 根据图片类型获取固定路径
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        private static List<ImagePath> GetPathByTypes(ImagePathType type)
        {
            return imagePathData.Where(o => o.Type == type).ToList();
        }
        #endregion

        #region 存储图片 根据临时路径
        /// <summary>
        /// 存储图片 根据临时路径
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="tempUrl">图片临时路径  /fafafaf/afa/faf.jpg</param>
        /// <param name="mapPath">服务器虚拟路径 d:\wi\web</param>
        /// <param name="domainName">http：//+域名</param>
        /// <param name="rootPath">根路径   upload</param>
        /// <param name="tempPath">临时文件根路径 tempConan</param>
        /// <returns></returns>
        public static string BaseSave(ImagePathType type, string tempUrl, string mapPath, string domainName, string rootPath, string tempPath = "tempConan")
        {
            //判断是不是临时图片
            if (string.IsNullOrEmpty(tempUrl) || tempUrl.IndexOf(tempPath) == -1)
                return tempUrl;


            // 保存图片或的路径，多个路径中间用逗号","隔开
            string savePathData = "";
            // 去掉临时图片路径的开头"/"
            if (tempUrl.StartsWith("/"))
                tempUrl = tempUrl.Substring(1);

            // 获取 固定路径
            string fixedPath = GetPathByType(type).FixedPath;

            // 获取 存储图片宽高,格式为：[宽x高,宽x高,宽x高...]注：宽高中间用小写"x"隔开
            var sizeArray = tempUrl.Substring(tempUrl.LastIndexOf("[") + 1, tempUrl.IndexOf("]") - tempUrl.LastIndexOf("[") - 1).Split('-');
            var sizeAll = tempUrl.Substring(tempUrl.LastIndexOf("["), tempUrl.IndexOf("]") - tempUrl.LastIndexOf("[") + 1);
            var tempUrlNoExt = tempUrl.Substring(0, tempUrl.LastIndexOf("."));
            var ext = Path.GetExtension(tempUrl);// tempUrl.Substring(tempUrl.LastIndexOf("."));


            for (int i = 0; i < sizeArray.Length; i++)
            {
                //获取一条宽高
                var wh = sizeArray[i].Split('x');
                if (wh.Length == 2)
                {
                    //宽
                    int width = int.Parse(wh[0]);
                    //高
                    int height = int.Parse(wh[1]);

                    //图片保存相对路径
                    string tpath = tempUrlNoExt.Replace(sizeAll, "").Replace(tempPath, "").Replace("_", "").Trim(new char[] { '/', '\\' });
                    var relativePath = $"{fixedPath}/{tpath}/{sizeArray[i]}{ext}".TrimStart('/');// tempUrlNoExt.Replace(sizeAll, "").Replace(tempPath, rootPath + fixedPath) + sizeArray[i] + ext;

                    //图片保存路径 例："D:\"+相对路径
                    var savePath = Path.Combine(rootPath, relativePath.Replace("/", "\\"));


                    //图片保存路径数据 http：//+域名+相对路径
                    string saveData;
                    if (relativePath.StartsWith("/"))
                        saveData = $"{domainName}{relativePath}";
                    else
                        saveData = $"{domainName}/{relativePath}";
                    if (savePathData != "")
                        savePathData = savePathData + "," + saveData;
                    else
                        savePathData = saveData;

                    //图片处理
                    IMGUtility.Thumbnail(Path.Combine(mapPath, tempUrl), savePath, width, height, IMGUtility.CutMode.WH);
                }
            }
            return savePathData;
        }
        #endregion

        #region 存储图片 根据文件流
        /// <summary>
        /// 存储图片 根据文件流
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="s">图片临时路径</param>
        /// <param name="mapPath">绝对路径（D:\相对路径）</param>
        /// <param name="domainName">http：//+域名</param>
        /// <param name="rootPath">根路径</param>
        /// <returns></returns>
        public static string BaseSave(ImagePathType type, Stream s, string mapPath, string domainName)
        {
            // 获取 当前所有路径
            var paths = GetPathByTypes(type);
            // 保存图片或的路径，多个路径中间用逗号","隔开
            string savePathData = "";
            foreach (var p in paths)
            {
                //宽
                int width = p.Width;
                //高
                int height = p.Height;
                //固定路径
                string fixedPath = p.FixedPath.Trim('/');

                var dt = DateTime.Now;
                var random = new Random().Next(100, 999);
                string fn = "/" + dt.ToString("HHmmssff") + random + "_" + width + "x" + height + ".jpg";
                string path = fixedPath + "/" + dt.ToString("yyyy") + "/" + dt.ToString("MM") + "/" + dt.ToString("dd");
                //图片保存相对路径
                var relativePath = path + fn;

                //图片保存路径 例："D:\"+相对路径
                var savePath = Path.Combine(mapPath, relativePath);
                //图片保存路径数据 http：//+域名+相对路径
                var saveData = domainName + "/" + relativePath;
                if (savePathData != "")
                    savePathData = savePathData + "," + saveData;
                else
                    savePathData = saveData;
                //图片处理
                IMGUtility.Thumbnail(s, savePath, width, height, IMGUtility.CutMode.WH);
            }
            return savePathData;
        }
        #endregion

        #region 根据真实路径 存储缩略图片
        ///// <summary>
        ///// 根据真实路径  存储缩略图片///////////////////////未写完
        ///// </summary>
        ///// <param name="returnUrl">传回的路径</param>
        ///// <param name="mapPath">服务器虚拟路径</param>
        ///// <param name="domainName">http：//+域名</param>
        ///// <param name="width">宽</param>
        ///// <param name="height">高</param>
        ///// <returns></returns>
        //public static string BaseSaveThumbnail(string returnUrl, string mapPath, string domainName,int width,int height)
        //{
        //    var urlArray = returnUrl.Split(',');
        //    for (int i = 0; i < urlArray.Length; i++)
        //    {
        //        var realPath = urlArray[i].Replace(domainName + "/", mapPath);
        //        var savePath = realPath.Replace(".jpg", "_thum.jpg");

        //    }
        //    return "";
        //}
        #endregion
    }
}
