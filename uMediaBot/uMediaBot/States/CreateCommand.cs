using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot.States
{
    class CreateCommand : BaseFolder
    {
        public override string Name => "Create";

        public override string CommandToEnterFolder => "/create";

        private Client _client;
        private BaseFolder _currentFolder;

        public CreateCommand(Client client, BaseFolder currentFolder) : base(999, currentFolder.Id)
        {
            _client = client;
            _currentFolder = currentFolder;
        }

        public override Message[] MessgagesAfterOpened()
        {
            return new Message[]{new Message(){ Text = "Type name of the folder you want to create"} };
        }

        public override Message ReciveStringData(string data)
        {
            var folder = new Entities.Folder(){UserId = _client.ChatId, Name = data,
                PreviousFolderId = PreviousFolderId };
            int folderID = _client.AspNetAPI.CreateUserFolder(folder).Result;
            BaseFolder newFolder = new UserFolder(folderID, _currentFolder.Id, folder.Name);
            // TODO create a folder factory
            newFolder.AddTransition("/create", new CreateCommand(_client, newFolder));
            newFolder.AddTransition(newFolder.CommandToReturnFromFolder, _currentFolder);
            _currentFolder.AddTransition($"/{folder.Name}", newFolder);
            _client.SetFolder(_currentFolder);
            return new Message() {Text = "Folder created"};
        }
    }
}
