using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hakaton2.dataAccess.Entities;
using hakaton2.Models.Models;

namespace hakaton2.dataAccess.Interfaces
{
    public interface IBlogManager
    {
        Task<List<BlogViewModel>> GetAll();
        Task<BlogViewModel> GetOne();
    }
}
