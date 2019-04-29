﻿using NFineCore.EntityFramework.Dto.OAManage;
using NFineCore.EntityFramework.Dto.SystemManage;
using NFineCore.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.Service.OAManage
{
    public interface IResFileService
    {
        ResFileOutputDto GetForm(string keyValue);
        List<ResFileGridDto> GetList(string keyword);

        List<ResFileGridDto> GetFolderList();

        List<ResFileGridDto> GetRootFiles();

        List<ResFileGridDto> GetDocumentFiles();

        List<ResFileGridDto> GetImageFiles();

        List<ResFileRecycleGridDto> GetRecycleFiles();

        List<ResFileGridDto> GetChildrenFiles(string parentId);

        void NewFolder(string folderName);

        void SubmitForm(ResFileInputDto resFileInputDto, string keyValue);

        void DeleteForm(string keyValue);

        void DeleteCompletely(string keyValue);

        void EmptyRecycle();

        void Rename(string keyValue, string fileName);

        void Restore(string keyValue);
    }
}
