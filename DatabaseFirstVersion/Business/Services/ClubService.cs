using AutoMapper;
using SportGroups.Business.Services.IServices;
using SportGroups.Data.Entities;
using SportGroups.Data.Repositories.Interfaces;
using SportGroups.Shared.DTOs.ClubDTOs;

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

        public async Task<int?> CreateClubAsync(int userId, NewClubDto newClubDto)
        {
            var newClub = _mapper.Map<Club>(newClubDto);
            newClub.EstablishedDate = DateTime.Now;

            // 把社團管理員(創社)加入社團成員
            newClub.ClubMembers.Add(new ClubMember
            {
                UserId = userId,
                JoinedDate = newClub.EstablishedDate
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

        public async Task<ClubInfoDto?> GetClubByIdAsync(int clubId)
        {
            var club = await _unitOfWork.Clubs.GetClubByIdAsync(clubId);
            return _mapper.Map<ClubInfoDto>(club);
        }

        public async Task<List<ClubInfoDto>> SearchClubsAsync(ClubsQueryConditions condition)
        {
            var clubs = await _unitOfWork.Clubs.GetClubsByConditionAsync(condition);
            return _mapper.Map<List<ClubInfoDto>>(clubs);
        }
    }
}
