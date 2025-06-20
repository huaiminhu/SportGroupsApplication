﻿using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportGroups.Data.Repositories;
using SportGroups.Shared.DTOs.ClubMemberDTOs;

namespace SportGroups.Business.Services
{
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClubService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> UpdateClubAsync(int clubId, ClubUpdateDto clubUpdateDto)
        {
            var existing = await _unitOfWork.Clubs.GetClubByIdAsync(clubId);
            if(existing == null)
            {
                return false;
            }
            _mapper.Map(clubUpdateDto, existing);
            _unitOfWork.Clubs.UpdateClub(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        //public async Task<bool> ChangeDescrptionAsync(int clubId, string newDescription)
        //{
        //    return await _unitOfWork.Clubs.UpdateDescrptionAsync(clubId, newDescription);
        //}

        //public async Task<bool> ChangeEmailAsync(int clubId, string newEmail)
        //{
        //    return await _unitOfWork.Clubs.UpdateEmailAsync(clubId, newEmail);
        //}

        //public async Task<bool> ChangeNameAsync(int clubId, string newName)
        //{
        //    return await _unitOfWork.Clubs.UpdateNameAsync(clubId, newName);
        //}

        //public async Task<bool> ChangePhoneAsync(int clubId, string newPhoneNum)
        //{
        //    return await _unitOfWork.Clubs.UpdatePhoneAsync(clubId, newPhoneNum);
        //}

        public async Task<int?> CreateClubAsync(int userId, NewClubDto newClubDto)
        {
            var newClub = _mapper.Map<Club>(newClubDto);
            newClub.establishedDate = DateTime.Now;
            newClub.Members.Add(new ClubMember
            {
                UserId = userId,
                JoinTime = newClub.establishedDate
            });
            await _unitOfWork.Clubs.CreateClubAsync(newClub);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0 ? newClub.ClubId : null;
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            var existing = await _unitOfWork.Clubs.GetClubByIdAsync(clubId);
            if(existing == null)
            {
                return false;
            }
            _unitOfWork.Clubs.DeleteClub(existing);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<ClubInfoDto?> GetClubInfoAsync(int clubId)
        {
            var club = await _unitOfWork.Clubs.GetClubByIdAsync(clubId);
            return _mapper.Map<ClubInfoDto>(club);
        }

        public async Task<List<ClubInfoDto>> GetClubsByConditionAsync(ClubsQueryConditions condition)
        {
            var clubs = await _unitOfWork.Clubs.GetClubsByConditionAsync(condition);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }

        //public async Task<List<ClubInfoDto>> GetAllClubsByKeywordAsync(string keyword)
        //{
        //    var clubs = await _unitOfWork.Clubs.GetAllClubsByKeywordAsync(keyword);
        //    return _mapper.Map<List<ClubInfoDto>>(clubs);
        //}

        //public async Task<List<ClubInfoDto>> GetAllClubsBySportAsync(Sport sport)
        //{
        //    var clubs = await _unitOfWork.Clubs.GetAllClubsBySportAsync(sport);
        //    return _mapper.Map<List<ClubInfoDto>>(clubs);
        //}
    }
}
