﻿using SIMS_HCI_Project.Domain.Models;
using SIMS_HCI_Project.WPF.ViewModels.Guest2ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS_HCI_Project.WPF.Views.Guest2Views
{
    /// <summary>
    /// Interaction logic for TourRatingView.xaml
    /// </summary>
    public partial class TourRatingView : Page
    {
        public TourRatingView(Guest2 guest2, NavigationService navigationService)
        {
            InitializeComponent();
            
            this.DataContext = new TourRatingViewModel(this, guest2, navigationService, RateReservationFrame);
        }
    }
}
