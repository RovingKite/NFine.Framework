using AutoMapper;
using NFineCore.Support;
using NFineCore.EntityFramework.Dtos.WeixinManage;
using NFineCore.EntityFramework.Models.WeixinManage;
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

        public void SubmitForm(WxNewsInputDto wxNewsInputDto, string keyValue)
        {
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            WxNews wxNews = new WxNews();
            if (!string.IsNullOrEmpty(keyValue))
            {
                long newsId = Convert.ToInt64(keyValue);
                var genericFetchStrategy = new GenericFetchStrategy<WxNews>().Include(p => p.WxNewsItems.First().Thumb);
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
        }

        public void UploadForm(WxNewsInputDto wxNewsInputDto, string keyValue)
        {
            SubmitForm(wxNewsInputDto, keyValue);
            UpdateForeverNews(keyValue);
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
                newsModel[index].thumb_media_id = wxNewsItem.Thumb.MediaId;
                newsModel[index].thumb_url = wxNewsItem.Thumb.MediaUrl;
            }
            var uploadForeverMediaResult = MediaApi.UploadNews(appId, 10000, newsModel);
            if (uploadForeverMediaResult.ErrorCodeValue == 0)
            {
                wxNews.MediaId = uploadForeverMediaResult.media_id;
                wxNewsRepository.Update(wxNews);
            }
            return uploadForeverMediaResult;
        }

        /// <summary>
        /// 更新永久图文素材
        /// </summary>
        /// <param name="keyValue"></param>
        public void UpdateForeverNews(string keyValue)
        {
            long id = Convert.ToInt64(keyValue);
            string appId = WxOperatorProvider.Provider.GetCurrent().AppId;
            var specification = new Specification<WxNews>().FetchStrategy.Include(p => p.WxNewsItems.Select(e => e.Thumb));
            WxNews wxNews = wxNewsRepository.Get(id, specification);

            NewsModel[] newsModel = new NewsModel[wxNews.WxNewsItems.Count()];
            var index = 0;
            foreach (WxNewsItem wxNewsItem in wxNews.WxNewsItems)
            {
                newsModel[index] = new NewsModel();
                newsModel[index].title = wxNewsItem.Title;
                newsModel[index].author = wxNewsItem.Author;
                newsModel[index].content = wxNewsItem.Content;
                newsModel[index].content_source_url = wxNewsItem.ContentSourceUrl;
                newsModel[index].digest = wxNewsItem.Digest;
                newsModel[index].need_open_comment = wxNewsItem.NeedOpenComment;
                newsModel[index].only_fans_can_comment = wxNewsItem.OnlyFansCanComment;
                newsModel[index].show_cover_pic = wxNewsItem.ShowCoverPic.ToString();
                newsModel[index].thumb_media_id = wxNewsItem.Thumb.MediaId;
                newsModel[index].thumb_url = wxNewsItem.Thumb.MediaUrl;
                index++;
            }
            if (!string.IsNullOrEmpty(wxNews.MediaId))
            {
                for (var i = 0; i < newsModel.Length; i++)
                {
                    var wxJsonResult = MediaApi.UpdateForeverNews(appId, wxNews.MediaId, i, newsModel[i], 10000);
                }
            }
        }
    }
}
