﻿using SIMS_HCI_Project.Domain.Models;
using System.Collections.Generic;

namespace SIMS_HCI_Project.Domain.RepositoryInterfaces
{
    public interface IGuestTourAttendanceRepository
    {
        void Load();
        void Save();
        GuestTourAttendance GetById(int id);
        List<GuestTourAttendance> GetAll();
        List<GuestTourAttendance> GetAllByTourId(int id);
        int GenerateId();
        void Add(GuestTourAttendance guestTourAttendance);
    }
}