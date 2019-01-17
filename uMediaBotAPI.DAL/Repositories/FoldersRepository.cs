using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using uMediaBotAPI.DAL.Data;
using uMediaBotAPI.DAL.Entities;

namespace uMediaBotAPI.DAL.Repositories
{
    public class FoldersRepository : GenericRepository<Folder>
    {
        public FoldersRepository(MediaBotDbContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
