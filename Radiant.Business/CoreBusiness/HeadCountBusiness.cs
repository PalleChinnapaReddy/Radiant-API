using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class HeadCountBusiness : IHeadCountBusiness
    {
        private readonly IHeadCountRepository _headCountRepository;
        private readonly ILogger<HeadCountBusiness> _logger;
        private readonly IMapper _modelMapper;

        public HeadCountBusiness(IHeadCountRepository headCountRepository
            , ILogger<HeadCountBusiness> logger
            , IMapper modelMapper)
        {
            _headCountRepository = headCountRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<List<AssignedHeadCountDto>> GetAssignedHeadCounts(AssignedHeadCountRequestDto requestDto)
        {
            try
            {
                var headCountRequest = _modelMapper.Map<AssignedHeadCountRequestModel>(requestDto);
                var headCounts = await _headCountRepository.GetAssignedHeadCounts(headCountRequest);
                return _modelMapper.Map<List<AssignedHeadCountDto>>(headCounts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAssignedHeadCounts(List<HeadCountAssignedTypeDto> headCountAssignedTypes)
        {
            try
            {
                var headCountAssignedTypeModels = _modelMapper.Map<List<HeadCountAssignedType>>(headCountAssignedTypes);
                await _headCountRepository.UpdateAssignedHeadCounts(headCountAssignedTypeModels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
