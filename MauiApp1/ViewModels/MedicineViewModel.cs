using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class MedicineViewModel
    {
        public ObservableCollection<Medicine> Medicines { get; set; }

        public MedicineViewModel()
        {
            Medicines = new ObservableCollection<Medicine>
            {
                new Medicine
                {
                    Name = "Aspirin",
                    Image = "",
                    Description = ""
                }
            };
        }   
    }
}
