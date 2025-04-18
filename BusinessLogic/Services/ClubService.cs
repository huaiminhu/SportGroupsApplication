using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Shared.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;
        public ClubService(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<bool> ChangeDescrptionAsync(int clubId, string newDescription)
        {
            return await _clubRepository.UpdateDescrptionAsync(clubId, newDescription);
        }

        public async Task<bool> ChangeEmailAsync(int clubId, string newEmail)
        {
            return await _clubRepository.UpdateEmailAsync(clubId, newEmail);
        }

        public async Task<bool> ChangeNameAsync(int clubId, string newName)
        {
            return await _clubRepository.UpdateNameAsync(clubId, newName);
        }

        public async Task<bool> ChangePhoneAsync(int clubId, string newPhoneNum)
        {
            return await _clubRepository.UpdatePhoneAsync(clubId, newPhoneNum);
        }

        public async Task<bool> CreateClubAsync(NewClubDto newClubDto)
        {
            var newClub = _mapper.Map<Club>(newClubDto);
            newClub.establishedDate = DateTime.Now;
            return await _clubRepository.CreateClubAsync(newClub);
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            return await _clubRepository.DeleteClubAsync(clubId);
        }

        public async Task<ClubInfoDto?> GetClubInfoAsync(int clubId)
        {
            var club = await _clubRepository.GetClubByIdAsync(clubId);
            return _mapper.Map<ClubInfoDto>(club);
        }

        public async Task<List<ClubInfoDto>> GetClubsByKeywordAsync(string keyword)
        {
            var clubs = await _clubRepository.GetAllClubsByKeywordAsync(keyword);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }

        public async Task<List<ClubInfoDto>> GetClubsBySportAsync(Sport sport)
        {
            var clubs = await _clubRepository.GetAllClubsBySportAsync(sport);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }
    }
}
