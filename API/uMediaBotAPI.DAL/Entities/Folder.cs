using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBotAPI.DAL.Entities
{
    public class Folder : Entity
    {
        public int UserId {get; set;}
        public string Name {get; set;}
        public int? PreviousFolderId {get; set;}
        public List<Content> content;
    }
}
