using System;
using System.Collections.Generic;

namespace uMediaBotAPI.DAL.Entities
{
    public class Content : Entity
    {
        public string ContentData {get; set;}
        public DateTime UploadTime {get; set;}
    }
}
