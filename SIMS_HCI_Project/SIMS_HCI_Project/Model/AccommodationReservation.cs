﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SIMS_HCI_Project.Serializer;

namespace SIMS_HCI_Project.Model
{
    public enum ReservationStatus { RESERVED, CANCELLED, RESCHEDULED, COMPLETED };
    public class AccommodationReservation : ISerializable
    {
        public int Id { get; set; }
        public int AccommodationId { get; set; }
        public string GuestId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int GuestNumber { get; set; }
        public ReservationStatus Status { get; set; }
        

        public AccommodationReservation(){ }
        public AccommodationReservation(int id, int accommodationId, string guestId, DateTime start, DateTime end, int guestNumber, ReservationStatus status)
        {
            Id = id;
            AccommodationId = accommodationId;
            GuestId = guestId;
            Start = start;
            End = end;
            GuestNumber = guestNumber;
            Status = status;
        }

        public AccommodationReservation(int accommodationId, string guestId, DateTime start, DateTime end, int guestNumber)
        {
            Id = -1;
            AccommodationId = accommodationId;
            GuestId = guestId;
            Start = start;
            End = end;
            GuestNumber = guestNumber;
            Status = ReservationStatus.RESERVED;
        }

        public AccommodationReservation(AccommodationReservation temp)
        {
            Id = temp.Id;
            AccommodationId = temp.AccommodationId;
            GuestId = temp.GuestId;
            Start = temp.Start;
            End = temp.End;
            GuestNumber = temp.GuestNumber;
            Status = temp.Status;

        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                AccommodationId.ToString(),
                GuestId,
                Start.ToString("MM/dd/yyyy"),
                End.ToString("MM/dd/yyyy"),
                GuestNumber.ToString(),
                Status.ToString()
                
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            AccommodationId = int.Parse(values[1]);
            GuestId = values[2];
            Start = DateTime.ParseExact(values[3], "MM/dd/yyyy", null);
            End = DateTime.ParseExact(values[4], "MM/dd/yyyy", null);
            GuestNumber = int.Parse(values[5]);
            Enum.TryParse(values[6], out ReservationStatus status);
            Status = status;

        }

    }
}