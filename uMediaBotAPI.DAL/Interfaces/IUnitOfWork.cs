using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using uMediaBotAPI.DAL.Repositories;

namespace uMediaBotAPI.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        bool Save();

        FoldersRepository FoldersRepository { get; }
    }
}
