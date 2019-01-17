using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using uMediaBotAPI.DAL.Entities;
using uMediaBotAPI.DAL.Interfaces;
using uMediaBotAPI.DAL.Repositories;

namespace uMediaBotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public FoldersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<Folder> folders = _unitOfWork.FoldersRepository.GetAllEntities().Result;
            return (from folder in folders select folder.Name).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            List<Folder> folders = _unitOfWork.FoldersRepository.GetAllEntities().Result;
            return (from folder in folders where id == folder.UserId select folder.Name).ToArray();
        }

        [HttpPost("create")]
        public string Create(FolderJsonStructure folderData)
        {
            var result = _unitOfWork.FoldersRepository.Create(folderData.ToEntity());
            _unitOfWork.Save();
            return result.Id.ToString();
        }

        [HttpPost("update/{id}")]
        public string Update(int id, FolderJsonStructure folderData)
        {
            folderData.Id = id;
            var result = _unitOfWork.FoldersRepository.Update(folderData.ToEntity());
            _unitOfWork.Save();
            return result.Id.ToString();
        }

        [HttpDelete("delete/{id}")]
        public string Delete(int id)
        {
            var result = _unitOfWork.FoldersRepository.Delete(id);
            _unitOfWork.Save();
            return result ? "true" : "false";
        }
    }
}
