using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;
using SportGroups.Shared.DTOs.ClubMemberDTOs;
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

        public async Task<ResultDto<MemberInfoDto>> JoinClubAsync(NewMemberDto newMemberDto)
        {
            var uId = newMemberDto.UserId;
            var cId = newMemberDto.ClubId;

            // 防止會員重複加入
            var existing = await _unitOfWork.ClubMembers.GetMemberAsync(uId, cId);
            if (existing != null)
            {
                return new ResultDto<MemberInfoDto>
                {
                    IsSuccess = false, 
                    ResponseMessage = "請勿重複加入!"
                };
            }
            
            var email = newMemberDto.Email;
            var jd = DateTime.Now;

            // 因AddMemberAsync不透過Entity操作資料沒有回傳值
            // 由此處設置例外處理以回傳ResultDto
            try
            {
                await _unitOfWork.ClubMembers.AddMemberAsync(uId, cId, email, jd);
                return new ResultDto<MemberInfoDto> 
                {
                    IsSuccess = true, 
                    ResponseMessage = "加入成功!"
                };
            }
            catch
            {
                return new ResultDto<MemberInfoDto>
                {
                    IsSuccess = false,
                    ResponseMessage = "加入失敗!"
                };
            }
        }

        public async Task<ResultDto<MemberInfoDto>> GetMemberAsync(int userId, int clubId)
        {
            var existing = await _unitOfWork.ClubMembers.GetMemberAsync(userId, clubId);
            if(existing == null)
            {
                return new ResultDto<MemberInfoDto>
                {
                    IsSuccess = false,
                    ResponseMessage = "您不是本社團成員, 無法使用此操作!"
                };
            }
            return new ResultDto<MemberInfoDto>
            {
                IsSuccess = true
            };
        }
    }
}
