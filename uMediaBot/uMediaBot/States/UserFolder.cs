using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot.States
{
    class UserFolder : BaseFolder
    {
        public override string Name => throw new NotImplementedException();
        public override string CommandToEnterFolder => $"/{_name}";
        private string _name;

        public UserFolder(int id, int previousFolderId, string name) : base(id, previousFolderId)
        {
            _name = name;
        }

        public override Message[] MessgagesAfterOpened()
        {
            return new Message[] {new Message(){ Text = $"You are in {_name} folder"} };
        }

        public override Message ReciveStringData(string data)
        {
            return new Message{Text = $"Not implemented"};
        }
    }
}
