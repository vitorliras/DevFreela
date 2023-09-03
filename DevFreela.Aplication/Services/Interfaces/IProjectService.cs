using DevFreela.Aplication.InputModel;
using DevFreela.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Aplication.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetByID(int id);
        int Create(NewProjectInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void Delete(int id);
        void CreateComment(CreatedCommentInputModel inputModel);
        void Start(int id);
        void Finish(int id);
    }
}
