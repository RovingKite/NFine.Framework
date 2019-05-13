
using AutoMapper;
using NFine.Support;
using NFine.EntityFramework.Dto.SystemManage;
using NFine.EntityFramework.Entity.SystemManage;
using NFine.Repository.SystemManage;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NFine.Core;
using NFine.EntityFramework.Dto.OAManage;
using NFine.EntityFramework.Entity.OAManage;
using NFine.Repository.OAManage;
using Newtonsoft.Json;
using NFine.EntityFramework;

namespace NFine.Service.OAManage
{
    public class ResFileService:IResFileService
    {
        ResFileRepository resFileRepository = new ResFileRepository(SharpRepoConfig.sharpRepoConfig, "efCore");
        ResFileRecycleRepository resFileRecycleRepository = new ResFileRecycleRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public ResFileOutputDto GetForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            ResFileOutputDto resFileOutputDto = new ResFileOutputDto();
            ResFile resFile = resFileRepository.Get(id);
            AutoMapper.Mapper.Map<ResFile, ResFileOutputDto>(resFile, resFileOutputDto);
            return resFileOutputDto;
        }

        public List<ResFileGridDto> GetList(string keyword)
        {
            var specification = new Specification<ResFile>(u => u.DeletedMark == false && (u.FileName.Contains(keyword)));
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileGridDto>>(list);
        }

        public List<ResFileGridDto> GetFolderList()
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            var specification = new Specification<ResFile>(u => u.DeletedMark == false && u.FileType == "Folder" && u.CreatorUserId== userId);
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileGridDto>>(list);
        }

        public List<ResFileGridDto> GetRootFiles()
        {
            var specification = new Specification<ResFile>(u => u.DeletedMark == false && u.ParentId == 0);
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileGridDto>>(list);            
        }

        public List<ResFileGridDto> GetDocumentFiles()
        {
            var specification = new Specification<ResFile>(u => u.DeletedMark == false && u.FileType == "Document");
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileGridDto>>(list);
        }

        public List<ResFileGridDto> GetImageFiles()
        {
            var specification = new Specification<ResFile>(u => u.DeletedMark == false && u.FileType == "Image");
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileGridDto>>(list);
        }

        public List<ResFileRecycleGridDto> GetRecycleFiles()
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            var specification = new Specification<ResFileRecycle>(u => u.DeletedMark == false && u.CreatorUserId == userId);
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRecycleRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileRecycleGridDto>>(list);
        }

        public List<ResFileGridDto> GetChildrenFiles(string parentId)
        {
            var specification = new Specification<ResFile>(u => u.DeletedMark == false && u.ParentId == Convert.ToInt64(parentId));
            specification.FetchStrategy.Include(p => p.CreatorUser);
            var list = resFileRepository.FindAll(specification).ToList();
            return Mapper.Map<List<ResFileGridDto>>(list);
        }

        public void NewFolder(string folderName)
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            ResFile resFile = new ResFile();
            resFile.Id = IdWorkerHelper.GenId64();
            resFile.FileName = folderName;
            resFile.FileSize = 0;
            resFile.FileType = "Folder";
            resFile.ParentId = 0;
            resFile.DeletedMark = false;
            resFile.CreationTime = DateTime.Now;
            resFile.CreatorUserId = userId;
            resFileRepository.Add(resFile);
        }

        public void Rename(string keyValue, string fileName)
        {
            long id = Convert.ToInt64(keyValue);
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            ResFile resFile = resFileRepository.Get(id);
            resFile.FileName = fileName;
            resFile.LastModifierUserId = userId;
            resFile.LastModificationTime = DateTime.Now;
            resFileRepository.Update(resFile);
        }

        public void SubmitForm(ResFileInputDto resFileInputDto, string keyValue)
        {
            ResFile resFile = new ResFile();
            if (!string.IsNullOrEmpty(keyValue))
            {
                //var id = Convert.ToInt64(keyValue);
                //area = areaRepository.Get(id);
                //AutoMapper.Mapper.Map<AreaInputDto, Area>(areaInputDto, area);
                //area.LastModificationTime = DateTime.Now;
                //areaRepository.Update(area);
            }
            else
            {
                AutoMapper.Mapper.Map<ResFileInputDto, ResFile>(resFileInputDto, resFile);
                long UserId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
                resFile.Id = IdWorkerHelper.GenId64();
                resFile.DeletedMark = false;
                resFile.CreationTime = DateTime.Now;
                resFile.CreatorUserId = UserId;
                resFileRepository.Add(resFile);
            }
        }

        public void DeleteForm(string keyValue)
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            string[] ids = keyValue.Split(',');
            for (int i = 0; i < ids.Length; i++) {
                long id = Convert.ToInt64(ids[i]);
                ResFile resFile = resFileRepository.Get(id);
                resFile.DeletedMark = true;
                resFile.DeletionTime = System.DateTime.Now;
                resFile.DeleterUserId = userId;
                resFileRepository.Update(resFile);

                ResFileRecycle resFileRecycle = resFileRecycleRepository.Get(id);
                if (resFileRecycle == null)
                {
                    resFileRecycle = new ResFileRecycle();
                    resFileRecycle = ObjectReflection.Mapper<ResFileRecycle, ResFile>(resFile);
                    resFileRecycle.DeletedMark = false;
                    resFileRecycle.CreationTime = System.DateTime.Now;
                    resFileRecycle.CreatorUserId = userId;
                    resFileRecycleRepository.Add(resFileRecycle);
                }
                else
                {
                    resFileRecycle = ObjectReflection.Mapper<ResFileRecycle, ResFile>(resFile);
                    resFileRecycle.DeletedMark = false;
                    resFileRecycle.CreationTime = System.DateTime.Now;
                    resFileRecycle.CreatorUserId = userId;
                    resFileRecycleRepository.Update(resFileRecycle);
                }
            }
        }

        public void DeleteCompletely(string keyValue)
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            string[] ids = keyValue.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                long id = Convert.ToInt64(ids[i]);
                ResFileRecycle resFileRecycle = resFileRecycleRepository.Get(id);
                resFileRecycle.DeletedMark = true;
                resFileRecycle.DeletionTime = System.DateTime.Now;
                resFileRecycle.CreatorUserId = userId;
                resFileRecycleRepository.Update(resFileRecycle);
            }
        }

        public void EmptyRecycle()
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            var specification = new Specification<ResFileRecycle>(u => u.DeletedMark == false && u.CreatorUserId == userId);
            var resFileRecycles = resFileRecycleRepository.FindAll(specification).ToList();
            foreach (ResFileRecycle resFileRecycle in resFileRecycles)
            {
                resFileRecycle.DeletedMark = true;
                resFileRecycle.DeletionTime = System.DateTime.Now;
                resFileRecycle.DeleterUserId = userId;
            }
            resFileRecycleRepository.Update(resFileRecycles);
        }

        public void Rename()
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            var specification = new Specification<ResFile>(u => u.DeletedMark == true && u.CreatorUserId == Convert.ToInt64(userId));
            var resFiles = resFileRepository.FindAll(specification).ToList();
            resFileRepository.Delete(resFiles);
        }

        public void Restore(string keyValue)
        {
            long userId = Convert.ToInt64(OperatorProvider.Provider.GetOperator().Id);
            string[] ids = keyValue.Split(',');
            for (int i = 0; i < ids.Length; i++)
            {
                long id = Convert.ToInt64(ids[i]);
                ResFileRecycle resFileRecycle = resFileRecycleRepository.Get(id);
                resFileRecycle.DeletedMark = true;
                resFileRecycle.DeletionTime = System.DateTime.Now;
                resFileRecycle.CreatorUserId = userId;
                resFileRecycleRepository.Update(resFileRecycle);

                ResFile resFile = resFileRepository.Get(id);
                resFile.DeletedMark = false;
                resFileRepository.Update(resFile);
            }
        }
    }
}
