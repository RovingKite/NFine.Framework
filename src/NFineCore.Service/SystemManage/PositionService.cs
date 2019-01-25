using AutoMapper;
using NFineCore.EntityFramework.Dtos.SystemManage;
using NFineCore.EntityFramework.Models.SystemManage;
using NFineCore.Repository.SystemManage;
using NFineCore.Support;
using SharpRepository.Repository.Queries;
using SharpRepository.Repository.Specifications;
using Snowflake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFineCore.Service.SystemManage
{
    public class PositionService
    {
        PositionRepository positionRepository = new PositionRepository(SharpRepoConfig.sharpRepoConfig, "efCore");

        public List<PositionGridDto> GetList()
        {
            var spec = new Specification<Position>();
            spec = new Specification<Position>(p => p.EnabledMark.Equals(true));
            var list = positionRepository.FindAll(spec).ToList();
            return Mapper.Map<List<PositionGridDto>>(list);
        }

        public List<PositionGridDto> GetList(string keyword)
        {
            var spec = new Specification<Position>(p => p.DeletedMark.Equals(false));
            if (!string.IsNullOrEmpty(keyword))
            {
                spec = new Specification<Position>(p => p.DeletedMark.Equals(false) && (p.FullName.Contains(keyword) || p.EnCode.Contains(keyword)));
            }
            var sortingOtopns = new SortingOptions<Position, int?>(x => x.SortCode, isDescending: false);
            var list = positionRepository.FindAll(spec, sortingOtopns).ToList();
            return Mapper.Map<List<PositionGridDto>>(list);
        }

        public PositionOutputDto GetForm(string keyValue)
        {
            long id = Convert.ToInt64(keyValue);
            PositionOutputDto positionOutputDto = new PositionOutputDto();
            Position position = positionRepository.Get(id);
            AutoMapper.Mapper.Map<Position, PositionOutputDto>(position, positionOutputDto);
            return positionOutputDto;
        }

        public void SubmitForm(PositionInputDto positionInputDto, string keyValue)
        {
            Position position = new Position();
            if (!string.IsNullOrEmpty(keyValue))
            {
                var id = Convert.ToInt64(keyValue);
                position = positionRepository.Get(id);
                AutoMapper.Mapper.Map<PositionInputDto, Position>(positionInputDto, position);
                position.LastModificationTime = DateTime.Now;
                positionRepository.Update(position);
            }
            else
            {
                AutoMapper.Mapper.Map<PositionInputDto, Position>(positionInputDto, position);
                position.Id = IdWorkerHelper.GenId64();
                position.CreationTime = DateTime.Now;
                position.CreatorUserId = 1;
                positionRepository.Add(position);
            }
        }
        public void DeleteForm(string keyValue)
        {
            var id = Convert.ToInt64(keyValue);
            Position position = positionRepository.Get(id);
            position.DeletedMark = true;
            position.DeletionTime = DateTime.Now;
            positionRepository.Update(position);
        }
    }
}
