using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
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
        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
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

        public Task<bool> CreateClubAsync(ClubDto clubDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            return await _clubRepository.DeleteClubAsync(clubId);
        }

        public Task<ClubDto?> GetClubInfoAsync(int clubId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubDto>> GetClubsByKeywordAsync(string keyword)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClubDto>> GetClubsBySportAsync(Sport sport)
        {
            throw new NotImplementedException();
        }
    }
}
