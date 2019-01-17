using uMediaBotAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace uMediaBotAPI.DAL.Data
{
    public class MediaBotDbContext : DbContext
    {
        public DbSet<Folder> Folders {get; set;}
        public DbSet<Content> Contets {get; set;}

        public MediaBotDbContext(DbContextOptions<MediaBotDbContext> options) : base(options)
        {
        }
    }
}
