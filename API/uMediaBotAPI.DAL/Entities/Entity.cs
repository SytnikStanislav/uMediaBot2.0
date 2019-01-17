using System.ComponentModel.DataAnnotations;

namespace uMediaBotAPI.DAL.Entities
{
    public class Entity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
