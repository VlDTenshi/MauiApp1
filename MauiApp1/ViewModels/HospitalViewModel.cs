using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class HospitalViewModel
    {
        public ObservableCollection<Hospital> Hospitals { get; set; }

        public HospitalViewModel() 
        {
            Hospitals = new ObservableCollection<Hospital>
            {
                new Hospital
                {
                    Name="RegionaalHaigla",
                    Image="",
                    Address="Mustamäe",
                    Description=""
                }
            };
        }
    }
}
