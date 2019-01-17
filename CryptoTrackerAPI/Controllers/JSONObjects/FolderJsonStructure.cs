using Newtonsoft.Json;
using uMediaBotAPI.DAL.Entities;

namespace uMediaBotAPI.Controllers
{
    public class FolderJsonStructure
    {
        public int Id {get; set;}
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("name")]
        public string Name {get; set;}
        [JsonProperty("previousFolderId")]
        public string PreviousFolderId {get; set;}

        public Folder ToEntity()
        {
            if(PreviousFolderId == null)
                PreviousFolderId = "0";
            return new Folder(){Id = Id, UserId = int.Parse(UserId), Name = Name,
                PreviousFolderId = int.Parse(PreviousFolderId)};
        }
    }
}