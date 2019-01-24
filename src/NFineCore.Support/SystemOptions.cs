using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.Support
{
    public class SystemOptions
    {
        public string FileServer { get; set; }
        public string FilePath { get; set; }
        public int ImgMaxHeight { get; set; }
        public int ImgMaxWidth { get; set; }
        public int ThumbHeight { get; set; }
        public int ThumbWidth { get; set; }
        public string ThumbMode { get; set; }
        public int WaterMarkType { get; set; }
        public string WaterMarkText { get; set; }
        public int WaterMarkImgQuality { get; set; }
        public int WaterMarkPosition { get; set; }
        public int WaterMarkTransparency { get; set; }
        public string WaterMarkPic { get; set; }
        public string FileSave { get; set; }
        public string FileExtension { get; set; }
        public string VideoExtension { get; set; }
        public string AttachSize { get; set; }
        public string ImgSize { get; set; }
        public string WaterMarkFont { get; set; }
        public int WaterMarkFontSize { get; set; }
        public string VideoSize { get; set; }
    }
}
