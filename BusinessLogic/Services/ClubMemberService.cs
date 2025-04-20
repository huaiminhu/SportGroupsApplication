using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using SportGroups.Shared.Entities;
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
        private readonly IMapper _mapper;
        public ClubMemberService(IClubMemberRepository clubMemberRepository, IMapper mapper)
        {
            _clubMemberRepository = clubMemberRepository;
            _mapper = mapper;
        }

        public async Task<List<ClubInfoDto>> GetAllClubsOfUserAsync(int userId)
        {
            var clubs = await _clubMemberRepository.GetAllClubsOfUserAsync(userId);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }

        public async Task<bool> JoinClubAsync(NewMemberDto newMemberDto)
        {
            var uId = newMemberDto.UserId;
            var cId = newMemberDto.ClubId;
            var email = newMemberDto.Email;
            var jd = DateTime.Now;
            return await _clubMemberRepository.AddMemberAsync(uId, cId, email, jd);
        }
    }
}
