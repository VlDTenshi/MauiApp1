using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Exercise
    {       
            public int Id {  get; set; }  
            public string Name { get; set; }
            public string Description { get; set; }
            public string Repetition { get; set; }
            public string ImageWEB { get; set; }
            public double ImageHeight { get; set; }
            public double ImageWidth { get; set; }
            public string ImagePath { get; set; }
    }
}
