using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> JoinClubAsync(NewMemberDto newMemberDto)
        {
            var uId = newMemberDto.UserId;
            var cId = newMemberDto.ClubId;
            var email = newMemberDto.Email;
            var jd = DateTime.Now;
            await _unitOfWork.ClubMembers.AddMemberAsync(uId, cId, email, jd);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
