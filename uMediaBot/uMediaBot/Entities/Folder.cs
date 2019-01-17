using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot.Entities
{
    public class Folder
    {
        public int Id {get; set;}
        public long UserId {get; set;}
        public string Name {get; set;}
        public int PreviousFolderId {get; set;}
        public List<Content> content;
    }
}
