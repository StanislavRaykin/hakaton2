using AutoMapper;
using hakaton2.dataAccess.Entities;
using hakaton2.dataAccess.Interfaces;
using hakaton2.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hakaton2.dataAccess.dataAccess
{
    public class BlogManager : IBlogManager
    {
        private hakatonContext _context;
        private IMapper mapper;
        public BlogManager(hakatonContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        public async Task<List<BlogViewModel>> GetAll()
        {
            var blogs = await _context.Blogs.Take(100).ToListAsync();
            return mapper.Map<List<BlogViewModel>>(blogs);
        }

        public Task<BlogViewModel> GetOne()
        {
            throw new NotImplementedException();
        }
    }
}
