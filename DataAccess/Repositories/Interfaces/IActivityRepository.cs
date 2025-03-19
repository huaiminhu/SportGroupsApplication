using DataAccess.Entities;
using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IActivityRepository
    {
        Task CreateActivity(ClubActivity activity);
        List<ClubActivity> GetAllActivitiesOfClub(int clubId);
        List<ClubActivity> GetAllActivitiesOfUser(int userId);
        List<ClubActivity> GetAllActivitiesBySport(Sport sport);
        Task UpdateActivity(ClubActivity activity);
        Task DeleteActivity(int activityId);
    }
}
