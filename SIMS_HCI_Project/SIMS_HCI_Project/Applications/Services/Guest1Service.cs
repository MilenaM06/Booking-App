﻿using SIMS_HCI_Project.Domain.Models;
using SIMS_HCI_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_HCI_Project.Applications.Services
{
    public class Guest1Service
    {
        private readonly IGuest1Repository _guest1Repository;

        public Guest1Service()
        {
            _guest1Repository = Injector.Injector.CreateInstance<IGuest1Repository>();
        }

        public Guest1 GetById(int id)
        {
            return _guest1Repository.GetById(id);
        }

        public List<Guest1> GetAll()
        {
            return _guest1Repository.GetAll();
        }

    }
}
