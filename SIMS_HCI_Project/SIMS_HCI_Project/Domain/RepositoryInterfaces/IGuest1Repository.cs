﻿using SIMS_HCI_Project.Domain.Models;
using System.Collections.Generic;

namespace SIMS_HCI_Project.Repositories
{
    public interface IGuest1Repository
    {
        Guest1 GetById(int id);
        List<Guest1> GetAll();
    }
}