using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;

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

            // 因AddMemberAsync不透過Entity操作資料沒有回傳值
            // 由此處設置例外處理以回傳Boolean Value
            try
            {
                await _unitOfWork.ClubMembers.AddMemberAsync(uId, cId, email, jd);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
