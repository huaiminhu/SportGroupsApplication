﻿using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ResultDTOs;

namespace SportGroups.Business.Services
{
    public class ClubMemberService : IClubMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClubMemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClubInfoDto>> GetAllClubsOfUserAsync(int userId)
        {
            var clubs = await _unitOfWork.ClubMembers.GetAllClubsOfUserAsync(userId);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }

        public async Task<ResultDto> JoinClubAsync(int userId, int clubId)
        {
            // 防止會員重複加入
            var existing = await _unitOfWork.ClubMembers.GetMemberAsync(userId, clubId);
            if (existing != null)
            {
                return new ResultDto
                {
                    IsSuccess = false, 
                    ResponseMessage = "請勿重複加入!"
                };
            }

            var jd = DateTime.Now;

            // 加入社團
            var result = await _unitOfWork.ClubMembers.AddMemberAsync(userId, clubId, jd);
            if(result == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "加入失敗!"
                };
            }
            return new ResultDto
            {
                IsSuccess = true,
                ResponseMessage = "加入成功!"
            };
        }

        public async Task<ResultDto> GetMemberAsync(int userId, int clubId)
        {
            var existing = await _unitOfWork.ClubMembers.GetMemberAsync(userId, clubId);
            if(existing == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "您不是本社團成員, 無法使用此操作!"
                };
            }
            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public async Task<ResultDto> QuitClubAsync(int userId, int clubId)
        {
            var existing = await _unitOfWork.ClubMembers
                .GetMemberAsync(userId, clubId);
            if(existing == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "找不到指定社團成員資訊!"
                };
            }
            
            // 退出社團
            var result = await _unitOfWork.ClubMembers.DeleteMemberAsync(userId, clubId);
            if (result == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    ResponseMessage = "退出失敗!"
                };
            }
            return new ResultDto
            {
                IsSuccess = true,
                ResponseMessage = "退出成功!"
            };
        }
    }
}
