using System;
using System.Collections.Generic;
using System.Text;

namespace uMediaBot.States
{
    public abstract class BaseFolder
    {
        public int Id {get; private set;}
        public int PreviousFolderId {get; private set;}

        public BaseFolder(int id, int previousFolderId)
        {
            Id = id;
            PreviousFolderId = previousFolderId;
        }

        public abstract string Name {get;}

        public Dictionary<string, BaseFolder> PossibleTransitions {get; private set;} = new Dictionary<string, BaseFolder>();

        public abstract Message[] MessgagesAfterOpened();

        public abstract Message ReciveStringData(string data);

        public abstract string CommandToEnterFolder {get;}
        public string CommandToReturnFromFolder {get; private set;} = "/back";

        public void AddTransition(string command, BaseFolder folder)
        {
            PossibleTransitions.Add(command, folder);
        }
    }
}
