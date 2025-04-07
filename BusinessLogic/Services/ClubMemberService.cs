using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Business.Services
{
    public class ClubMemberService : IClubMemberService
    {
        private readonly IClubMemberRepository _clubMemberRepository;
        public ClubMemberService(IClubMemberRepository clubMemberRepository)
        {
            _clubMemberRepository = clubMemberRepository;
        }

        public Task<List<ClubDto>> GetAllClubsOfUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> JoinClubAsync(ClubMemberDto clubMemberDto)
        {
            throw new NotImplementedException();
        }
    }
}
