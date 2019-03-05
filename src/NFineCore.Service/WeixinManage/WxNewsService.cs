﻿using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dto.WeixinManage;
using NFineCore.EntityFramework.Entity.WeixinManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Repository.WeixinManage;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.GroupMessage;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
using SharpRepository.Repository.FetchStrategies;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NFineCore.EntityFramework;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using Senparc.Weixin.Entities;

namespace NFineCore.Service.WeixinManage
{
    public class WxNewsService
    {
        WxImageRepository wxImageRepository = new WxImageRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        WxNewsRepository wxNewsRepository = new WxNewsRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        WxNewsItemRepository wxNewsItemRepository = new WxNewsItemRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<WxNewsGridDto> GetList(Pagination pagination, string keyword)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var wxNewsList = new List<WxNews>();
            if (string.IsNullOrEmpty(keyword))
            {
                var specification = new Specification<WxNews>(obj => obj.AppId == appId);
                var pagingOptions = new PagingOptions<WxNews, DateTime?>(pagination.page, pagination.rows, x => x.CreationTime, isDescending: true);
                if (!string.IsNullOrEmpty(keyword))
                {
                    specification = new Specification<WxNews>(obj => obj.AppId == appId);
                }
                specification.FetchStrategy.Include(p => p.WxNewsItems.Select(e => e.Thumb));
                wxNewsList = wxNewsRepository.FindAll(specification, pagingOptions).ToList();
                foreach (WxNews wxNews in wxNewsList)
                {
                    wxNews.WxNewsItems = wxNews.WxNewsItems.OrderBy(u => u.Index).ToList();
                }
                pagination.records = pagingOptions.TotalItems;
            }
            else
            {
                var wxNewsItemSpecification = new Specification<WxNewsItem>(obj => obj.WxNews.AppId == appId && obj.Title.Contains(keyword));
                wxNewsItemSpecification.FetchStrategy.Include(p => p.WxNews.WxNewsItems.Select(e => e.Thumb));
                var wxNewsItemList = wxNewsItemRepository.FindAll(wxNewsItemSpecification).ToList();
                foreach (WxNewsItem wxNewsItem in wxNewsItemList)
                {
                    wxNewsList.Add(wxNewsItem.WxNews);
                }
                wxNewsList = wxNewsList.Distinct().ToList();
                foreach (WxNews wxNews in wxNewsList)
                {
                    wxNews.WxNewsItems = wxNews.WxNewsItems.OrderBy(u => u.Index).ToList();
                }
                pagination.records = wxNewsList.Count();
                wxNewsList = wxNewsList.Skip((pagination.page - 1) * pagination.rows).Take(pagination.rows).ToList();
            }
            return Mapper.Map<List<WxNewsGridDto>>(wxNewsList);
        }

        public WxNewsOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            var genericFetchStrategy = new GenericFetchStrategy<WxNews>().Include(p => p.WxNewsItems.Select(e => e.Thumb));
            WxNews wxNews = wxNewsRepository.Get(id, genericFetchStrategy);
            wxNews.WxNewsItems = wxNews.WxNewsItems.OrderBy(u => u.Index).ToList();
            WxNewsOutputDto wxNewsOutputDto = new WxNewsOutputDto();
            AutoMapper.Mapper.Map<WxNews, WxNewsOutputDto>(wxNews, wxNewsOutputDto);
            return wxNewsOutputDto;
        }

        public WxNews SubmitForm(WxNewsInputDto wxNewsInputDto, string keyValue)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            WxNews wxNews = new WxNews();
            if (!string.IsNullOrEmpty(keyValue))
            {
                long newsId = Convert.ToInt64(keyValue);
                var genericFetchStrategy = new GenericFetchStrategy<WxNews>().Include(p => p.WxNewsItems.First().Thumb);
                wxNewsRepository.CachingEnabled = false;
                wxNewsRepository.ClearCache();
                wxNews = wxNewsRepository.Get(newsId, genericFetchStrategy);
                wxNews.LastModificationTime = DateTime.Now;
                wxNewsRepository.Update(wxNews);
                foreach (WxNewsItemInputDto wxNewsItemInputDto in wxNewsInputDto.WxNewsItems)
                {
                    if (!string.IsNullOrEmpty(wxNewsItemInputDto.Id))
                    {
                        long newsItemId = Convert.ToInt64(wxNewsItemInputDto.Id);
                        WxNewsItem wxNewsItem = wxNewsItemRepository.Get(newsItemId);
                        wxNewsItem.NewsId = wxNews.Id;
                        wxNewsItem.Title = wxNewsItemInputDto.Title;
                        wxNewsItem.Author = wxNewsItemInputDto.Author;
                        wxNewsItem.Digest = wxNewsItemInputDto.Digest;
                        wxNewsItem.Content = wxNewsItemInputDto.Content;
                        wxNewsItem.ContentSourceUrl = wxNewsItemInputDto.ContentSourceUrl;
                        wxNewsItem.ThumbId = Convert.ToInt64(wxNewsItemInputDto.Thumb.Id);
                        if (!string.IsNullOrEmpty(wxNewsItemInputDto.Thumb.MediaId))
                        {
                            wxNewsItem.ShowCoverPic = 1;
                        }
                        else
                        {
                            wxNewsItem.ShowCoverPic = 0;
                        }
                        wxNewsItem.Index = wxNewsItemInputDto.Index;
                        wxNewsItem.NeedOpenComment = wxNewsItemInputDto.NeedOpenComment;
                        wxNewsItem.OnlyFansCanComment = wxNewsItemInputDto.OnlyFansCanComment;
                        wxNewsItem.LastModificationTime = DateTime.Now;
                        wxNewsItemRepository.Update(wxNewsItem);
                    }
                    else
                    {
                        WxNewsItem wxNewsItem = new WxNewsItem();
                        wxNewsItem.Id = IdWorkerHelper.GenId64();
                        wxNewsItem.NewsId = wxNews.Id;
                        wxNewsItem.Title = wxNewsItemInputDto.Title;
                        wxNewsItem.Author = wxNewsItemInputDto.Author;
                        wxNewsItem.Digest = wxNewsItemInputDto.Digest;
                        wxNewsItem.Content = wxNewsItemInputDto.Content;
                        wxNewsItem.ContentSourceUrl = wxNewsItemInputDto.ContentSourceUrl;
                        wxNewsItem.ThumbId = Convert.ToInt64(wxNewsItemInputDto.Thumb.Id);
                        if (!string.IsNullOrEmpty(wxNewsItemInputDto.Thumb.Id))
                        {
                            wxNewsItem.ShowCoverPic = 1;
                        }
                        else
                        {
                            wxNewsItem.ShowCoverPic = 0;
                        }
                        wxNewsItem.Index = wxNewsItemInputDto.Index;
                        wxNewsItem.NeedOpenComment = wxNewsItemInputDto.NeedOpenComment;
                        wxNewsItem.OnlyFansCanComment = wxNewsItemInputDto.OnlyFansCanComment;
                        wxNewsItem.DeletedMark = false;
                        wxNewsItem.CreationTime = DateTime.Now;
                        wxNewsItemRepository.Add(wxNewsItem);
                    }
                }
            }
            else
            {
                wxNews.Id = IdWorkerHelper.GenId64();
                wxNews.AppId = appId;
                wxNews.DeletedMark = false;
                wxNews.CreationTime = DateTime.Now;
                wxNews.WxNewsItems = new List<WxNewsItem>();
                foreach (WxNewsItemInputDto wxNewsItemInputDto in wxNewsInputDto.WxNewsItems)
                {
                    WxNewsItem wxNewsItem = new WxNewsItem();
                    wxNewsItem.Id = IdWorkerHelper.GenId64();
                    wxNewsItem.NewsId = wxNews.Id;
                    wxNewsItem.Title = wxNewsItemInputDto.Title;
                    wxNewsItem.Author = wxNewsItemInputDto.Author;
                    wxNewsItem.Digest = wxNewsItemInputDto.Digest;
                    wxNewsItem.Content = wxNewsItemInputDto.Content;
                    wxNewsItem.ContentSourceUrl = wxNewsItemInputDto.ContentSourceUrl;
                    wxNewsItem.ThumbId = Convert.ToInt64(wxNewsItemInputDto.Thumb.Id);
                    if (!string.IsNullOrEmpty(wxNewsItemInputDto.Thumb.Id))
                    {
                        wxNewsItem.ShowCoverPic = 1;
                    }
                    else
                    {
                        wxNewsItem.ShowCoverPic = 0;
                    }
                    wxNewsItem.Index = wxNewsItemInputDto.Index;
                    wxNewsItem.NeedOpenComment = wxNewsItemInputDto.NeedOpenComment;
                    wxNewsItem.OnlyFansCanComment = wxNewsItemInputDto.OnlyFansCanComment;
                    wxNewsItem.DeletedMark = false;
                    wxNewsItem.CreationTime = DateTime.Now;
                    wxNews.WxNewsItems.Add(wxNewsItem);
                }
                wxNewsRepository.Add(wxNews);
            }
            return wxNews;
        }

        public void UploadForm(WxNewsInputDto wxNewsInputDto, string keyValue)
        {
            WxNews wxNews = SubmitForm(wxNewsInputDto, keyValue);
            wxNewsInputDto.Id = wxNews.Id.ToString();
            wxNewsInputDto.AppId = wxNews.AppId;
            if (!string.IsNullOrEmpty(wxNewsInputDto.MediaId))
            {
                UpdateForeverNews(wxNewsInputDto);
            }
            else
            {
                UploadForeverNews(wxNewsInputDto);
            }
        }

        public void DeleteForm(string keyValue)
        {            
            var id = Convert.ToInt64(keyValue);
            var genericFetchStrategy = new GenericFetchStrategy<WxNews>().Include(p => p.WxNewsItems);
            WxNews wxNews = wxNewsRepository.Get(id, genericFetchStrategy);
            if (!string.IsNullOrEmpty(wxNews.MediaId)) {
                string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
                AccessTokenResult accessTokenResult = AccessTokenContainer.GetAccessTokenResult(appId);
                var wxJsonResult = MediaApi.DeleteForeverMedia(accessTokenResult.access_token, wxNews.MediaId, 10000);
                if (wxJsonResult.ErrorCodeValue == 0)
                {
                    wxNews.MediaId = null;
                    wxNews.DeletedMark = true;
                    wxNews.DeletionTime = DateTime.Now;
                    foreach (WxNewsItem item in wxNews.WxNewsItems)
                    {
                        item.DeletedMark = true;
                        item.DeletionTime = DateTime.Now;
                    }
                    wxNewsRepository.Update(wxNews);
                }
            }
            else {
                wxNews.MediaId = null;
                wxNews.DeletedMark = true;
                wxNews.DeletionTime = DateTime.Now;
                foreach (WxNewsItem item in wxNews.WxNewsItems)
                {
                    item.DeletedMark = true;
                    item.DeletionTime = DateTime.Now;
                }
                wxNewsRepository.Update(wxNews);
            }
        }

        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="keyValue">NewsId</param>
        public UploadForeverMediaResult UploadForeverNews(string keyValue) {
            long id = Convert.ToInt64(keyValue);
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var specification = new Specification<WxNews>().FetchStrategy.Include(p => p.WxNewsItems.Select(e => e.Thumb));
            WxNews wxNews = wxNewsRepository.Get(id, specification);
            wxNews.WxNewsItems = wxNews.WxNewsItems.OrderBy(x => x.Index).ToList();
            var uploadForeverMediaResult = UploadForeverNews(wxNews);
            return uploadForeverMediaResult;
        }

        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="wxNews"></param>
        /// <returns></returns>
        public UploadForeverMediaResult UploadForeverNews(WxNews wxNews)
        {
            NewsModel[] newsModel = new NewsModel[wxNews.WxNewsItems.Count()];
            foreach (WxNewsItem wxNewsItem in wxNews.WxNewsItems)
            {
                int index = wxNews.WxNewsItems.IndexOf(wxNewsItem);
                newsModel[index] = new NewsModel();
                newsModel[index].title = wxNewsItem.Title;
                newsModel[index].author = wxNewsItem.Author;
                newsModel[index].content = wxNewsItem.Content;
                newsModel[index].content_source_url = wxNewsItem.ContentSourceUrl;
                newsModel[index].digest = wxNewsItem.Digest;
                newsModel[index].need_open_comment = wxNewsItem.NeedOpenComment;
                newsModel[index].only_fans_can_comment = wxNewsItem.OnlyFansCanComment;
                newsModel[index].show_cover_pic = wxNewsItem.ShowCoverPic.ToString();
                if (wxNewsItem.Thumb == null)
                {
                    wxNewsItem.Thumb = wxImageRepository.Get(Convert.ToInt64(wxNewsItem.ThumbId));
                }
                newsModel[index].thumb_media_id = wxNewsItem.Thumb.MediaId;
                newsModel[index].thumb_url = wxNewsItem.Thumb.MediaUrl;
            }
            var uploadForeverMediaResult = MediaApi.UploadNews(wxNews.AppId, 10000, newsModel);
            if (uploadForeverMediaResult.ErrorCodeValue == 0)
            {
                wxNewsRepository.Update(new WxNews { Id = wxNews.Id, MediaId = uploadForeverMediaResult.media_id });
            }
            return uploadForeverMediaResult;
        }

        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="wxNews"></param>
        /// <returns></returns>
        public UploadForeverMediaResult UploadForeverNews(WxNewsInputDto wxNewsInputDto)
        {
            NewsModel[] newsModel = new NewsModel[wxNewsInputDto.WxNewsItems.Count()];
            foreach (WxNewsItemInputDto wxNewsItemInputDto in wxNewsInputDto.WxNewsItems)
            {
                int index = wxNewsInputDto.WxNewsItems.IndexOf(wxNewsItemInputDto);
                newsModel[index] = new NewsModel();
                newsModel[index].title = wxNewsItemInputDto.Title;
                newsModel[index].author = wxNewsItemInputDto.Author;
                newsModel[index].content = wxNewsItemInputDto.Content;
                newsModel[index].content_source_url = wxNewsItemInputDto.ContentSourceUrl;
                newsModel[index].digest = wxNewsItemInputDto.Digest;
                newsModel[index].need_open_comment = wxNewsItemInputDto.NeedOpenComment;
                newsModel[index].only_fans_can_comment = wxNewsItemInputDto.OnlyFansCanComment;
                newsModel[index].show_cover_pic = wxNewsItemInputDto.ShowCoverPic.ToString();
                newsModel[index].thumb_media_id = wxNewsItemInputDto.Thumb.MediaId;
                newsModel[index].thumb_url = wxNewsItemInputDto.Thumb.MediaUrl;
            }
            var uploadForeverMediaResult = MediaApi.UploadNews(wxNewsInputDto.AppId, 10000, newsModel);
            if (uploadForeverMediaResult.ErrorCodeValue == 0)
            {
                WxNews wxNews = wxNewsRepository.Get(Convert.ToInt64(wxNewsInputDto.Id));
                wxNews.MediaId = uploadForeverMediaResult.media_id;
                wxNewsRepository.Update(wxNews);
            }
            return uploadForeverMediaResult;
        }

        /// <summary>
        /// 更新永久图文素材
        /// </summary>
        /// <param name="wxNews"></param>
        public void UpdateForeverNews(WxNewsInputDto wxNewsInputDto)
        {
            NewsModel[] newsModel = new NewsModel[wxNewsInputDto.WxNewsItems.Count()];
            foreach (WxNewsItemInputDto wxNewsItemInputDto in wxNewsInputDto.WxNewsItems)
            {
                int index = wxNewsInputDto.WxNewsItems.IndexOf(wxNewsItemInputDto); //index 为索引值
                newsModel[index] = new NewsModel();
                newsModel[index].title = wxNewsItemInputDto.Title;
                newsModel[index].author = wxNewsItemInputDto.Author;
                newsModel[index].content = wxNewsItemInputDto.Content;
                newsModel[index].content_source_url = wxNewsItemInputDto.ContentSourceUrl;
                newsModel[index].digest = wxNewsItemInputDto.Digest;
                newsModel[index].need_open_comment = wxNewsItemInputDto.NeedOpenComment;
                newsModel[index].only_fans_can_comment = wxNewsItemInputDto.OnlyFansCanComment;
                newsModel[index].show_cover_pic = wxNewsItemInputDto.ShowCoverPic.ToString();
                newsModel[index].thumb_media_id = wxNewsItemInputDto.Thumb.MediaId;
                newsModel[index].thumb_url = wxNewsItemInputDto.Thumb.MediaUrl;
            }
            if (!string.IsNullOrEmpty(wxNewsInputDto.MediaId))
            {
                for (var i = 0; i < newsModel.Length; i++)
                {
                    var wxJsonResult = MediaApi.UpdateForeverNews(wxNewsInputDto.AppId, wxNewsInputDto.MediaId, i, newsModel[i], 10000);
                }
            }
        }
    }
}
