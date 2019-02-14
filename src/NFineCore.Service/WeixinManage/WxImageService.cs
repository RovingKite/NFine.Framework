using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.WeixinManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Repository.WeixinManage;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFineCore.Service.WeixinManage
{
    public class WxImageService
    {
        WxImageRepository wxImageRepository = new WxImageRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<WxImageGridDto> GetList()
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var specification = new Specification<WxImage>(p => p.DeletedMark == false && p.AppId == appId);
            var sortingOtopns = new SortingOptions<WxImage, DateTime?>(x => x.CreationTime, isDescending: false);
            var list = wxImageRepository.FindAll(specification, sortingOtopns).ToList();
            return Mapper.Map<List<WxImageGridDto>>(list);
        }

        public List<WxImageGridDto> GetList(Pagination pagination, string keyword)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var specification = new Specification<WxImage>(p => p.AppId == appId);
            var pagingOptions = new PagingOptions<WxImage, DateTime?>(pagination.page, pagination.rows, x => x.CreationTime, isDescending: true);
            if (!string.IsNullOrEmpty(keyword))
            {
                specification = new Specification<WxImage>(p => p.AppId == appId && (p.FileName.Contains(keyword)));
            }
            var list = wxImageRepository.FindAll(specification, pagingOptions).ToList();
            pagination.records = pagingOptions.TotalItems;
            return Mapper.Map<List<WxImageGridDto>>(list);
        }

        public WxImageOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxImageOutputDto wxImagOutputDto = new WxImageOutputDto();
            WxImage wxImage = wxImageRepository.Get(id);
            AutoMapper.Mapper.Map<WxImage, WxImageOutputDto>(wxImage, wxImagOutputDto);
            return wxImagOutputDto;
        }

        //public WxApp GetEntityByAppId(string appId)
        //{
        //    var specification = new Specification<WxApp>(p => p.AppId == appId);
        //    WxApp wxApp = wxAppRepository.Find(specification);
        //    return wxApp;
        //}

        public void SubmitForm(WxImageInputDto wxImageInputDto, string keyValue)
        {
            WxImage wxImage = new WxImage();
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                wxImage = wxImageRepository.Get(id);
                //AutoMapper.Mapper.Map<WxImageInputDto, WxImage>(wxImageInputDto, wxImage);
                wxImage.FileName = wxImageInputDto.FileName;
                wxImage.LastModificationTime = DateTime.Now;
                wxImageRepository.Update(wxImage);
            }
            else
            {
                AutoMapper.Mapper.Map<WxImageInputDto, WxImage>(wxImageInputDto, wxImage);
                wxImage.Id = IdWorkerHelper.GenId64();
                wxImage.AppId = appId;
                wxImage.DeletedMark = false;
                wxImage.CreationTime = DateTime.Now;
                wxImage.CreatorUserId = 1;
                wxImageRepository.Add(wxImage);
            }
        }

        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            WxImage wxImage = wxImageRepository.Get(id);
            wxImage.DeletedMark = true;
            wxImage.DeletionTime = DateTime.Now;
            wxImageRepository.Update(wxImage);
            //if (!string.IsNullOrEmpty(wxImage.MediaId))
            //{
            //    string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            //    AccessTokenResult accessTokenResult = AccessTokenContainer.GetAccessTokenResult(appId);
            //    WxJsonResult wxJsonResult = MediaApi.DeleteForeverMedia(accessTokenResult.access_token, wxImage.MediaId);
            //    if (wxJsonResult.ErrorCodeValue == 0)
            //    {
            //        wxImageRepository.Update(wxImage);
            //    }
            //}
            //else
            //{
            //    wxImageRepository.Update(wxImage);
            //}
        }

        public UploadForeverMediaResult UploadForeverImage(string keyValue,string webRootPath)
        {
            var id = Convert.ToInt64(keyValue);
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            WxImage wxImage = wxImageRepository.Get(id);
            AccessTokenResult accessTokenResult = AccessTokenContainer.GetAccessTokenResult(appId);
            string fullFilePaht = webRootPath + wxImage.FilePath;
            var uploadForeverMediaResult = MediaApi.UploadForeverMedia(accessTokenResult.access_token, fullFilePaht, 10000);
            if (uploadForeverMediaResult.ErrorCodeValue == 0) {
                wxImage.MediaId = uploadForeverMediaResult.media_id;
                wxImage.MediaUrl = uploadForeverMediaResult.url;
                wxImageRepository.Update(wxImage);
            }
            return uploadForeverMediaResult;
        }
    }
}
