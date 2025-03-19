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
        Task AddMedia(Media media);
        Media GetMedia(int mediaId);
        Task UpdateMedia(Media media);
        Task DeleteMedia(int mediaId);
    }
}
