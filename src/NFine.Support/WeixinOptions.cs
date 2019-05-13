using System;
using System.Collections.Generic;
using System.Text;

namespace NFine.Support
{
    public class WeixinOptions
    {
        public string WebPath { get; set; }
        public string WebRootPath { get; set; }
        public string FileServer { get; set; }
        public string UploadPath { get; set; }
        public int ImageMaxHeight { get; set; }
        public int ImageMaxWidth { get; set; }
        public int ThumbnailHeight { get; set; }
        public int ThumbnailWidth { get; set; }
        public string ThumbnailMode { get; set; }
        public int WaterMarkType { get; set; }
        public string WaterMarkText { get; set; }
        public int WaterMarkImgQuality { get; set; }
        public int WaterMarkPosition { get; set; }
        public int WaterMarkTransparency { get; set; }
        public string WaterMarkPic { get; set; }
        public int FileSave { get; set; }
        public string FileExtension { get; set; }
        public string VideoExtension { get; set; }
        public string AttachSize { get; set; }
        public string ImgSize { get; set; }
        public string WaterMarkFont { get; set; }
        public int WaterMarkFontSize { get; set; }
        public string VideoSize { get; set; }
    }
}
