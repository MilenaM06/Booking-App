﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SIMS_HCI_Project.Serializer;


namespace SIMS_HCI_Project.Model
{
    public enum AccomodationType { APARTMENT, HOUSE, HUT };

    public class Accommodation : ISerializable
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public AccomodationType Type { get; set; }

        public int MaxGuests { get; set; }
        public int MinimumReservationDays { get; set; }
        public int CancellationDeadlineInDays { get; set; }
        public List<string> Pictures { get; set; } //[Maybe] Change to URI type

        public Accommodation() 
        {
            CancellationDeadlineInDays = 1;
            Pictures = new List<string>();
        }


        //ORDER IS IMPORTANT, optional parametar at the end
       public Accommodation(int id, string ownerId, string name, int locationId, Location location, AccomodationType type, int maxGuests, int minimumReservationDays, /*List<string> pictures,*/  int cancellationDeadlineInDays = 1)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            LocationId = locationId;
            Location = location; // check if this is needed
            Type = type;
            MaxGuests = maxGuests;
            MinimumReservationDays = minimumReservationDays; // by default --> 1
            CancellationDeadlineInDays = cancellationDeadlineInDays;
          //  Pictures = new List<string>(pictures); //check if this is needed here
        }

        public Accommodation(Accommodation temp)
        {
            Id = temp.Id;
            OwnerId = temp.OwnerId;
            Name = temp.Name;
            LocationId = temp.LocationId;
            Location = temp.Location;
            Type = temp.Type;
            MaxGuests = temp.MaxGuests;
            MinimumReservationDays = temp.MinimumReservationDays;
            CancellationDeadlineInDays = temp.CancellationDeadlineInDays;
          //  Pictures = new List<string>(temp.Pictures);

        }

       
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                OwnerId,
                Name,
                LocationId.ToString(),
                ConvertAccommodationTypeToString(Type),
                MaxGuests.ToString(),
                MinimumReservationDays.ToString(),
                CancellationDeadlineInDays.ToString()
               // Pictures --> [Maybe] separate CSV files

            };
            return csvValues;
        }
        
        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            OwnerId= values[1];
            Name = values[2];
            LocationId = int.Parse(values[3]);
            Type = ConvertStringToAccommodatonType(values[4]);
            MaxGuests = int.Parse(values[5]);
            MinimumReservationDays = int.Parse(values[6]);
            CancellationDeadlineInDays = int.Parse(values[7]);
            //Pictures --> [Maybe] separate CSV files
        }


        public static string ConvertAccommodationTypeToString(AccomodationType type) 
        {
            if (type == AccomodationType.APARTMENT) {
                return "APARTMENT";
            }else if(type == AccomodationType.HOUSE) 
            {
                return "HOUSE";
            }
            else 
            {
                return "HUT";
            }
        }

        public static AccomodationType ConvertStringToAccommodatonType(string type) 
        {
            if (type.ToLower() == "apartment")
            {
                return AccomodationType.APARTMENT;
            }
            else if (type.ToLower() == "house")
            {
                return AccomodationType.HOUSE;
            }
            else
            {
                return AccomodationType.HUT;
            }
        }



    }
}
