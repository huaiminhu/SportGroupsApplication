using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IMediaRepository
    {
        Task<bool> AddMediaAsync(Media media);
        Task<Media?> GetMediaAsync(int mediaId);
        Task<bool> UpdateUrlAsync(int mediaId, string newUrl);
        Task<bool> DeleteMediaAsync(int mediaId);
    }
}
