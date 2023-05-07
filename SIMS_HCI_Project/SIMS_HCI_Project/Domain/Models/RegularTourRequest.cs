﻿using System;
using System.Collections.Generic;
using System.Linq;
using SIMS_HCI_Project.Serializer;
using System.Text;
using System.Threading.Tasks;
using SIMS_HCI_Project.Domain.DTOs;

namespace SIMS_HCI_Project.Domain.Models
{
     public enum RegularRequestStatus { PENDING, ACCEPTED, INVALID };

    public class RegularTourRequest : ISerializable
    {
        public int Id { get; set; }
        public RegularRequestStatus Status { get; set; }
        public int GuestId { get; set; }
        public Guest2 Guest { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Language { get; set; }
        public int GuestNumber { get; set; }
        public string Description { get; set; }
        public DateRange DateRange { get; set; }
        public DateTime SubmittingDate { get; set; }
        public bool IsPartOfComplex { get; set; } //discuss if needed, how will (parts of) complex requests be stored


        public RegularTourRequest()
        {
            DateRange = new DateRange();
        }

        public RegularTourRequest(int guestId, Guest2 guest, Location location, string language, int guestNumber, string description, DateRange dateRange, bool isPartOfComplex)
        {
            GuestId = guestId;
            Guest = guest;
            Location = location;
            Language = language;
            GuestNumber = guestNumber;
            Description = description;
            DateRange = dateRange;
            IsPartOfComplex = isPartOfComplex;

            SubmittingDate = DateTime.Now;
            Status = RegularRequestStatus.PENDING;

        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Status.ToString(),
                GuestId.ToString(),
                LocationId.ToString(),
                Language.ToString(),
                GuestNumber.ToString(),
                Description.ToString(),
                DateRange.Start.ToString("MM/dd/yyyy"),
                DateRange.End.ToString("MM/dd/yyyy"),
                SubmittingDate.ToString("MM/dd/yyyy"),
                IsPartOfComplex.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Enum.TryParse(values[1], out RegularRequestStatus status);
            Status = status;
            GuestId = int.Parse(values[2]);
            LocationId = int.Parse(values[3]);
            Language = values[4];
            GuestNumber = int.Parse(values[5]);
            Description = values[6];
            DateRange.Start = DateTime.ParseExact(values[7], "MM/dd/yyyy", null);
            DateRange.End = DateTime.ParseExact(values[8], "MM/dd/yyyy", null);
            SubmittingDate = DateTime.ParseExact(values[9], "MM/dd/yyyy", null);
            IsPartOfComplex = bool.Parse(values[10]);
        }
    }
}
