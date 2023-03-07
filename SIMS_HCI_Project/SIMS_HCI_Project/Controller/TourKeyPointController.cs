﻿using SIMS_HCI_Project.FileHandler;
using SIMS_HCI_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SIMS_HCI_Project.Controller
{
    public class TourKeyPointController
    {
        private TourKeyPointFileHandler _fileHandler;

        private readonly List<TourKeyPoint> _tourKeyPoints;

        public TourKeyPointController()
        {
            _fileHandler = new TourKeyPointFileHandler();
            _tourKeyPoints = _fileHandler.Load();
        }

        public List<TourKeyPoint> GetAll()
        {
            return _tourKeyPoints;
        }

        public TourKeyPoint Save(TourKeyPoint tourKeyPoint)
        {
            TourKeyPoint foundTourKeyPoint = FindByTitle(tourKeyPoint.Title);
            if (foundTourKeyPoint == null)
            {
                tourKeyPoint.Id = GenerateNextId();
                _tourKeyPoints.Add(tourKeyPoint);
                _fileHandler.Save(_tourKeyPoints);
                return tourKeyPoint;
            }
            else
            {
                return foundTourKeyPoint;
            }
        }

        public TourKeyPoint FindByTitle(string title)
        {
            return _tourKeyPoints.FirstOrDefault(kp => kp.Title.ToLower() == title.ToLower());
        }

        private int GenerateNextId()
        {
            if (_tourKeyPoints.Count == 0) return 1;
            return _tourKeyPoints[_tourKeyPoints.Count - 1].Id + 1;
        }
    }
}
