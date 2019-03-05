using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.Service.SystemManage;

namespace NFineCore.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnPostUpload(List<IFormFile> files)
        {
            string action = HttpContext.Request.Query["action"];
            switch (action)
            {
                case "config": //编辑器配置
                    EditorConfig();
                    break;
                case "uploadimage": //编辑器上传图片
                    EditorUploadImage();
                    break;
                case "uploadvideo": //编辑器上传视频
                    //EditorUploadVideo(context);
                    break;
                case "uploadfile": //编辑器上传附件
                    //EditorUploadFile(context);
                    break;
                case "uploadscrawl": //编辑器上传涂鸦
                    //EditorUploadScrawl(context);
                    break;
                case "listimage": //编辑器浏览图片
                    //EditorListImage(context);
                    break;
                case "listfile": //编辑器浏览文件
                    //EditorListFile(context);
                    break;
                case "catchimage": //编辑器远程抓取图片
                    //EditorCatchImage(context);
                    break;
                default: //普通上传
                    UploadFile();
                    break;
            }
        }

        #region 上传文件处理===================================
        private void UploadFile()
        {
            //检查是否允许匿名上传
            /*if (sysConfig.fileanonymous == 0 && !new ManagePage().IsAdminLogin() && !new BasePage().IsUserLogin())
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"禁止匿名非法上传！\"}");
                return;
            }*/

            //string _delfile = HttpContext.Request.Query["DelFilePath"]; //要删除的文件
            //string fileName = HttpContext.Request.Query["name"]; //文件名
            var upfile = HttpContext.Request.Form.Files["upfile"];
            string fileName = upfile.FileName;
            string fileType = upfile.ContentType;
            byte[] byteData; //获取文件流
            using (var stream = upfile.OpenReadStream())
            {
                byteData = new byte[stream.Length];
                stream.Read(byteData, 0, (int)stream.Length);
            }
           
            bool _isWater = false; //默认不打水印
            bool _isThumb = false; //默认不生成缩略图
            if (HttpContext.Request.Query["IsWater"] == "1")
            {
                _isWater = true;
            }
            if (HttpContext.Request.Query["IsThumb"] == "1")
            {
                _isThumb = true;
            }
            if (byteData.Length == 0)
            {
                //context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            string webRootPath = _hostingEnvironment.WebRootPath;
            string remsg = new NFineCore.Support.Upload().FileSaveAs(byteData, fileName, _isThumb, _isWater);
            Dictionary<string, object> dic = JsonHelper.DataRowFromJSON(remsg);
            string status = dic["status"].ToString();
            string msg = dic["msg"].ToString();
            if (status == "1")
            {
                string filePath = dic["path"].ToString(); //取得上传后的路径
                string thumbPath = dic["thumb"].ToString();
                string fileSize = dic["size"].ToString();
                string fileExt = dic["ext"].ToString();
                SaveAttach(fileName, fileType, filePath, thumbPath, fileSize, fileExt);
                showSuccess(fileName, filePath, thumbPath, fileSize, fileExt);
            }
            else
            {
                showError(msg);
            }
        }
        #endregion

        #region 编辑器请求处理=================================
        public void EditorConfig()
        {
            StringBuilder jsonStr = new StringBuilder();
            jsonStr.Append("{");
            //上传图片配置项
            jsonStr.Append("\"imageActionName\": \"uploadimage\","); //执行上传图片的action名称
            jsonStr.Append("\"imageFieldName\": \"upfile\","); //提交的图片表单名称
            jsonStr.Append("\"imageMaxSize\": \"2048000\","); //上传大小限制，单位B
            jsonStr.Append("\"imageAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],"); //上传图片格式显示
            jsonStr.Append("\"imageCompressEnable\": false,"); //是否压缩图片,默认是true
            jsonStr.Append("\"imageCompressBorder\": 1600,"); //图片压缩最长边限制
            jsonStr.Append("\"imageInsertAlign\": \"none\","); //插入的图片浮动方式
            jsonStr.Append("\"imageUrlPrefix\": \"\","); //图片访问路径前缀
            jsonStr.Append("\"imagePathFormat\": \"\","); //上传保存路径
            //涂鸦图片上传配置项
            jsonStr.Append("\"scrawlActionName\": \"uploadscrawl\","); //执行上传涂鸦的action名称
            jsonStr.Append("\"scrawlFieldName\": \"upfile\","); //提交的图片表单名称
            jsonStr.Append("\"scrawlPathFormat\": \"\","); //上传保存路径
            jsonStr.Append("\"scrawlMaxSize\": \"2048000\","); //上传大小限制，单位B
            jsonStr.Append("\"scrawlUrlPrefix\": \"\","); //图片访问路径前缀
            jsonStr.Append("\"scrawlInsertAlign\": \"none\",");
            //截图工具上传
            jsonStr.Append("\"snapscreenActionName\": \"uploadimage\","); //执行上传截图的action名称
            jsonStr.Append("\"snapscreenPathFormat\": \"\","); //上传保存路径
            jsonStr.Append("\"snapscreenUrlPrefix\": \"\","); //图片访问路径前缀
            jsonStr.Append("\"snapscreenInsertAlign\": \"none\","); //插入的图片浮动方式
            //抓取远程图片配置
            jsonStr.Append("\"catcherLocalDomain\": [\"127.0.0.1\", \"localhost\", \"img.baidu.com\"],");
            jsonStr.Append("\"catcherActionName\": \"catchimage\","); //执行抓取远程图片的action名称
            jsonStr.Append("\"catcherFieldName\": \"source\","); //提交的图片列表表单名称
            jsonStr.Append("\"catcherPathFormat\": \"\","); //上传保存路径
            jsonStr.Append("\"catcherUrlPrefix\": \"\","); //图片访问路径前缀
            jsonStr.Append("\"catcherMaxSize\": \"2048000\","); //上传大小限制，单位B
            jsonStr.Append("\"catcherAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],"); //抓取图片格式显示
            //上传视频配置
            jsonStr.Append("\"videoActionName\": \"uploadvideo\","); //上传视频的action名称
            jsonStr.Append("\"videoFieldName\": \"upfile\","); //提交的视频表单名称
            jsonStr.Append("\"videoPathFormat\": \"\","); //上传保存路径
            jsonStr.Append("\"videoUrlPrefix\": \"\","); //视频访问路径前缀
            jsonStr.Append("\"videoMaxSize\": \"2048000\","); //上传大小限制，单位B
            jsonStr.Append("\"videoAllowFiles\": [\".flv\", \".swf\", \".mkv\", \".avi\", \".rm\", \".rmvb\", \".mpeg\", \".mpg\", \".ogg\", \".ogv\", \".mov\", \".wmv\", \".mp4\", \".webm\", \".mp3\", \".wav\", \".mid\"],");
            //上传附件配置
            jsonStr.Append("\"fileActionName\": \"uploadfile\","); //上传视频的action名称
            jsonStr.Append("\"fileFieldName\": \"upfile\","); //提交的文件表单名称
            jsonStr.Append("\"filePathFormat\": \"\","); //上传保存路径
            jsonStr.Append("\"fileUrlPrefix\": \"\","); //文件访问路径前缀
            jsonStr.Append("\"fileMaxSize\": \"2048000\","); //上传大小限制，单位B
            jsonStr.Append("\"fileAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\", \".flv\", \".swf\", \".mkv\", \".avi\", \".rm\", \".rmvb\", \".mpeg\", \".mpg\", \".ogg\", \".ogv\", \".mov\", \".wmv\", \".mp4\", \".webm\", \".mp3\", \".wav\", \".mid\", \".zip\", \".tar\", \".gz\", \".7z\", \".bz2\", \".cab\", \".iso\", \".doc\", \".docx\", \".xls\", \".xlsx\", \".ppt\", \".pptx\", \".txt\", \".md\", \".xml\"],");
            //列出指定目录下的图片
            jsonStr.Append("\"imageManagerActionName\": \"listimage\","); //执行图片管理的action名称
            jsonStr.Append("\"imageManagerListPath\": \"\","); //指定要列出图片的目录
            jsonStr.Append("\"imageManagerListSize\": 20,"); //每次列出文件数量
            jsonStr.Append("\"imageManagerUrlPrefix\": \"\","); //图片访问路径前缀
            jsonStr.Append("\"imageManagerInsertAlign\": \"none\","); //插入的图片浮动方式
            jsonStr.Append("\"imageManagerAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\"],"); //列出的文件类型
            //列出指定目录下的文件
            jsonStr.Append("\"fileManagerActionName\": \"listfile\","); //执行文件管理的action名称
            jsonStr.Append("\"fileManagerListPath\": \"\","); //指定要列出文件的目录
            jsonStr.Append("\"fileManagerUrlPrefix\": \"\","); //文件访问路径前缀
            jsonStr.Append("\"fileManagerListSize\": 20,"); //每次列出文件数量
            jsonStr.Append("\"fileManagerAllowFiles\": [\".png\", \".jpg\", \".jpeg\", \".gif\", \".bmp\",");
            jsonStr.Append("\".flv\", \".swf\", \".mkv\", \".avi\", \".rm\", \".rmvb\", \".mpeg\", \".mpg\",");
            jsonStr.Append("\".ogg\", \".ogv\", \".mov\", \".wmv\", \".mp4\", \".webm\", \".mp3\", \".wav\", \".mid\",");
            jsonStr.Append("\".rar\", \".zip\", \".tar\", \".gz\", \".7z\", \".bz2\", \".cab\", \".iso\",");
            jsonStr.Append("\".doc\", \".docx\", \".xls\", \".xlsx\", \".ppt\", \".pptx\", \".pdf\", \".txt\", \".md\", \".xml\"]");
            jsonStr.Append("}");
            HttpContext.Response.Headers.Add("Content-Type", "text/plain");
            HttpContext.Response.WriteAsync(jsonStr.ToString());
        }

        public void EditorUploadImage()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            bool _iswater = false;    //默认不打水印
            bool _isThumbnail = true; //默认生成缩略图
            if (HttpContext.Request.Query["IsWater"] == "1")
            {
                _iswater = true;
            }
            var upfile = HttpContext.Request.Form.Files["upfile"];
            string fileName = upfile.FileName;
            byte[] byteData; //获取文件流
            using (var stream = upfile.OpenReadStream())
            {
                byteData = new byte[stream.Length];
                stream.Read(byteData, 0, (int)stream.Length);
            }
            //开始上传
            string remsg = new NFineCore.Support.Upload().FileSaveAs(byteData, fileName, _isThumbnail, _iswater);
            Dictionary<string, object> dic = JsonHelper.DataRowFromJSON(remsg);
            string status = dic["status"].ToString();
            string msg = dic["msg"].ToString();
            if (status == "1")
            {
                //string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
                //AccessTokenResult accessTokenResult = AccessTokenContainer.GetAccessTokenResult(appId);

                //string filePath = dic["path"].ToString(); //取得上传后的路径
                //string thumbPath = dic["thumb"].ToString();
                //string fileSize = dic["size"].ToString();
                //string fileExt = dic["ext"].ToString();
                //string title = fileName;
                //string original = fileName;

                //UploadImgResult uploadImgResult = MediaApi.UploadImg(accessTokenResult.access_token, webRootPath+filePath);
                //string url = uploadImgResult.url;
                //editorUploadSuccess(url, title, original);
            }
            else
            {
                showError(msg);
            }
        }
        #endregion

        #region 保存附件信息方法
        public void SaveAttach(string fileName, string fileType, string filePath, string thumbPath, string fileSize, string fileExt)
        {
            AttachService attachService = new AttachService();
            AttachInputDto attachInputDto = new AttachInputDto();
            attachInputDto.FileName = fileName;
            attachInputDto.FileType = fileType;
            attachInputDto.FilePath = filePath;
            attachInputDto.FileSize = Convert.ToInt64(fileSize);
            attachInputDto.FileExt = fileExt;
            attachInputDto.ThumbPath = thumbPath;
            attachService.SubmitForm(attachInputDto, "");
        }
        #endregion
        
        #region 辅助工具方法===================================
        /// <summary>
        /// 显示错误提示
        /// </summary>
        private void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "ERROR";
            hash["error"] = message;
            HttpContext.Response.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(hash));
        }

        /// <summary>
        /// 显示成功提示
        /// </summary>
        private void showSuccess(string fileName, string filePath)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "SUCCESS";
            hash["url"] = filePath;
            hash["title"] = fileName;
            hash["original"] = fileName;
            HttpContext.Response.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(hash));
        }
        /// <summary>
        /// 显示成功提示
        /// </summary>
        private void showSuccess(string fileName, string filePath, string thumbPath, string fileSize, string fileExt)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "SUCCESS";
            hash["filePath"] = filePath;
            hash["fileName"] = fileName;
            hash["thumbPath"] = thumbPath;
            hash["fileSize"] = fileSize;
            hash["fileExt"] = fileExt;
            hash["url"] = filePath;
            hash["title"] = fileName;
            hash["original "] = fileName;
            HttpContext.Response.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(hash));
        }
        /// <summary>
        /// 显示成功提示
        /// </summary>
        private void showSuccess(string fileName, string filePath, string thumbPath, string fileSize, string fileExt,string url,string title,string original)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "SUCCESS";
            hash["filePath"] = filePath;
            hash["fileName"] = fileName;
            hash["thumbPath"] = thumbPath;
            hash["fileSize"] = fileSize;
            hash["fileExt"] = fileExt;
            hash["url"] = url;
            hash["title"] = title;
            hash["original "] = original;
            HttpContext.Response.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(hash));
        }
        /// <summary>
        /// 显示成功提示
        /// </summary>
        private void editorUploadSuccess(string url, string title, string original, string error = "")
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "SUCCESS";
            hash["url"] = url;
            hash["title"] = title;
            hash["original"] = original;
            hash["error"] = "";
            HttpContext.Response.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(hash));
        }
        /// <summary>
        /// 显示成功提示
        /// </summary>
        private void editorUploadError(string url, string title, string original, string error)
        {
            Hashtable hash = new Hashtable();
            hash["state"] = "ERROR";
            hash["url"] = "";
            hash["title"] = "";
            hash["original"] = "";
            hash["error"] = error;
            HttpContext.Response.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
            HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(hash));
        }
        #endregion
    }
}