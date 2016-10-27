

namespace Conan.Model
{
    /// <summary>
    /// 字典添加类
    /// </summary>
    public class DictionaryAddCmd
    {
        public int Id { get; set; }
        public string Text { get; set; }//文本
        public bool IsHide { get; set; }//是否隐藏
        public string Option { get; set; }//具体属性 如价格 税点等  
        public string Img { get; set; }//图片
        public int Sort { get; set; }//排序
        public string Remark { get; set; }//备注

    }
}
