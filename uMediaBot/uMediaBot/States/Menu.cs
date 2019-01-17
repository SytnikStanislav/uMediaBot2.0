using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot.States
{
    class Menu : BaseFolder
    {
        public override string CommandToEnterFolder => "/menu";

        public override string Name => _name;
        private string _name;

        public Menu(int id, int previousFolderId, string name): base(id, previousFolderId)
        {
            _name = name;
        }

        public override Message ReciveStringData(string data)
        {
            return new Message(){ Text = "For saving message you need to select folder first"};
        }

        public override Message[] MessgagesAfterOpened()
        {
            return new Message[] {new Message(){ Text = "Select or create folder"} };
        }
    }
}
