using System;
using System.Collections.Generic;
using System.Text;
using uMediaBot.Entities;
using uMediaBot.States;

namespace uMediaBot
{
    public class Client
    {
        public BaseFolder currentFolder {get; private set;}

        public long ChatId {get; private set;}

        public AspNetAPI AspNetAPI {get; private set;}
        private Renderer _renderer;

        public Client(long chatId, AspNetAPI aspNetAPI, Renderer renderer)
        {
            ChatId = chatId;
            AspNetAPI = aspNetAPI;
            _renderer = renderer;
            StartUp();
        }

        private void StartUp()
        {
            List<BaseFolder> userStates = GetUserFolders();
            currentFolder = new Menu(0, 0, "menu"); // all null previousFolderId will be converted to 0. It means that menu is their previous folder
            AddTransitionsToFolderAndNestedFolders(currentFolder, userStates);
            AddDefaultFolders(currentFolder);
            _renderer.Render(currentFolder, ChatId);

            List<BaseFolder> GetUserFolders()
            {
                List<Folder> usersFolders = AspNetAPI.GetUserFolders(ChatId).Result;
                List<BaseFolder> botStates = new List<BaseFolder>();
                foreach(Folder folder in usersFolders)
                    botStates.Add(CreateFolder(folder));
                return botStates;


                BaseFolder CreateFolder(Folder folder)
                {
                    return new UserFolder(folder.Id, folder.PreviousFolderId, folder.Name);
                }
            } 
            void AddTransitionsToFolderAndNestedFolders(BaseFolder folder, List<BaseFolder> allFolders){
                foreach(BaseFolder nestedFolder in allFolders)
                    if(folder.Id == nestedFolder.PreviousFolderId){
                        folder.AddTransition(nestedFolder.CommandToEnterFolder, nestedFolder);
                        nestedFolder.AddTransition(nestedFolder.CommandToReturnFromFolder, folder);
                        AddDefaultFolders(nestedFolder);
                        AddTransitionsToFolderAndNestedFolders(nestedFolder, allFolders);
                    }
            }
            void AddDefaultFolders(BaseFolder baseFolder)
                {
                    baseFolder.AddTransition("/create", new CreateCommand(this, baseFolder));
                }
        }

        public void HandleMessage(string message)
        {
            if (IsCommand(message) &&  CanBeExecuted(message))
                    ExecuteCommand(message);
            else {
                Message reply = currentFolder.ReciveStringData(message);
                _renderer.SendMessage(reply, ChatId);
            }


            bool IsCommand(string mes)
            {
                return mes[0] == '/';
            }
            bool CanBeExecuted(string mes)
            {
                foreach(string command in currentFolder.PossibleTransitions.Keys)
                    if(command == mes) 
                        return true;
                return false;
            }
            void ExecuteCommand(string mes)
            {
                foreach(string command in currentFolder.PossibleTransitions.Keys)
                    if(command == mes) 
                        SetFolder(currentFolder.PossibleTransitions[command]);
            }
        }

        public void SetFolder(BaseFolder folder)
        {
            currentFolder = folder;
            _renderer.Render(currentFolder, ChatId);
        }
    }
}
