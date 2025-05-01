using AutoMapper;
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

        public async Task<bool> ChangeDescrptionAsync(int clubId, string newDescription)
        {
            return await _unitOfWork.Clubs.UpdateDescrptionAsync(clubId, newDescription);
        }

        public async Task<bool> ChangeEmailAsync(int clubId, string newEmail)
        {
            return await _unitOfWork.Clubs.UpdateEmailAsync(clubId, newEmail);
        }

        public async Task<bool> ChangeNameAsync(int clubId, string newName)
        {
            return await _unitOfWork.Clubs.UpdateNameAsync(clubId, newName);
        }

        public async Task<bool> ChangePhoneAsync(int clubId, string newPhoneNum)
        {
            return await _unitOfWork.Clubs.UpdatePhoneAsync(clubId, newPhoneNum);
        }

        public async Task<bool> CreateClubAsync(NewClubDto newClubDto)
        {
            var newClub = _mapper.Map<Club>(newClubDto);
            newClub.establishedDate = DateTime.Now;
            return await _unitOfWork.Clubs.CreateClubAsync(newClub);
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            return await _unitOfWork.Clubs.DeleteClubAsync(clubId);
        }

        public async Task<ClubInfoDto?> GetClubInfoAsync(int clubId)
        {
            var club = await _unitOfWork.Clubs.GetClubByIdAsync(clubId);
            return _mapper.Map<ClubInfoDto>(club);
        }

        public async Task<List<ClubInfoDto>> GetClubsByKeywordAsync(string keyword)
        {
            var clubs = await _unitOfWork.Clubs.GetAllClubsByKeywordAsync(keyword);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }

        public async Task<List<ClubInfoDto>> GetClubsBySportAsync(Sport sport)
        {
            var clubs = await _unitOfWork.Clubs.GetAllClubsBySportAsync(sport);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }
    }
}
