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

        public Task<bool> ChangeDescrptionAsync(int clubId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeEmailAsync(int clubId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeNameAsync(int clubId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangePhoneAsync(int clubId, string newPhoneNum)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateClubAsync(ClubDto clubDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteClubAsync(int clubId)
        {
            throw new NotImplementedException();
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
