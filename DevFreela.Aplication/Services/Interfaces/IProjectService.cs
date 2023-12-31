﻿using DevFreela.Aplication.InputModel;
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
        ProjectDetailsViewModel GetByID(int id);
        void Start(int id);
        void Finish(int id);
    }
}
