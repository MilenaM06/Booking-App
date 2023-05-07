﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS_HCI_Project.Domain.DTOs;
using SIMS_HCI_Project.Domain.Models;
using SIMS_HCI_Project.Domain.RepositoryInterfaces;
using SIMS_HCI_Project.Repositories;

namespace SIMS_HCI_Project.Applications.Services
{
    public class RegularTourRequestService
    {
        private readonly IRegularTourRequestRepository _regularTourRequestRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly ITourRepository _tourRepository;
        private readonly ITourTimeRepository _tourTimeRepository;

        public RegularTourRequestService()
        {
            _regularTourRequestRepository = Injector.Injector.CreateInstance<IRegularTourRequestRepository>();
            _locationRepository = Injector.Injector.CreateInstance<ILocationRepository>();
            _notificationRepository = Injector.Injector.CreateInstance<INotificationRepository>();
            _tourRepository = Injector.Injector.CreateInstance<ITourRepository>();
            _tourTimeRepository = Injector.Injector.CreateInstance<ITourTimeRepository>();
        }

        public RegularTourRequest GetById(int id)
        {
            return _regularTourRequestRepository.GetById(id);
        }

        public List<RegularTourRequest> GetAll()
        {
            return _regularTourRequestRepository.GetAll();
        }

        public List<RegularTourRequest> GetAllByGuestId(int id)
        {
            return _regularTourRequestRepository.GetAllByGuestId(id);
        }

        public List<RegularTourRequest> GetAllByGuestIdNotPartOfComplex(int guestId)
        {
            return _regularTourRequestRepository.GetAllByGuestIdNotPartOfComplex(guestId);
        }

        public List<RegularTourRequest> GetByGuestIdAndStatus(int ig, RegularRequestStatus status)
        {
            return _regularTourRequestRepository.GetByGuestIdAndStatus(ig, status);
        }

        public List<RegularTourRequest> GetValidByParams(Location location, int guestNumber, string language, DateRange dateRange)
        {
            return _regularTourRequestRepository.GetValidByParams(location, guestNumber, language, dateRange);
        }

        public void EditStatus(int requestId, RegularRequestStatus status)
        {
            _regularTourRequestRepository.EditStatus(requestId, status);
        }

        public void Add(RegularTourRequest request)
        {
            request.Location = _locationRepository.GetOrAdd(request.Location);
            request.LocationId = request.Location.Id;

            _regularTourRequestRepository.Add(request);
        }

        public Tour AcceptRequest(RegularTourRequest request, int guideId, DateTime departureTime)
        {
            request.Status = RegularRequestStatus.ACCEPTED;
            _regularTourRequestRepository.Update(request);

            Tour tourFromRequest = new Tour()
                                        {
                                            Title = "Requested Tour by request " + request.Id.ToString(),
                                            Language = request.Language,
                                            Location = request.Location,
                                            LocationId = request.LocationId,
                                            Description = request.Description,
                                            MaxGuests = request.GuestNumber,
                                            Duration = 2,
                                            GuideId = guideId
                                        };
            _tourRepository.Add(tourFromRequest);

            TourTime choosenTourTime = new TourTime(tourFromRequest.Id, departureTime);
            _tourTimeRepository.Add(choosenTourTime);
            tourFromRequest.DepartureTimes.Add(choosenTourTime);

            Notification notification = new Notification("Your request number for tour was accepted. Departure time: " + departureTime.ToShortDateString() + ". Created tour number: [" + tourFromRequest.Id.ToString() + "].", request.GuestId, false, NotificationType.TOUR_REQUEST_ACCEPTED);
            _notificationRepository.Add(notification);

            return tourFromRequest;
        }
    }
}
