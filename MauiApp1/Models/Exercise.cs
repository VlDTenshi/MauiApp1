using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Exercise
    {
            [PrimaryKey,AutoIncrement]
            public int Id {  get; set; }
            [Required]
            public string? Name { get; set; }
            [Required]
            public string? Description { get; set; }
            [Required]
            public string? Repetition { get; set; }
            public string? ImageWEB { get; set; }
            //public double ImageHeight { get; private set; }
            //public double ImageWidth { get; private set; }
            public string? ImagePath { get; set; }

        //public string GetImageSource()
        //{
        //    if (!string.IsNullOrEmpty(ImageWEB))
        //    {
        //        return ImageWEB; // Возвращаем URL для динамической картинки
        //    }

        //    if (!string.IsNullOrEmpty(ImagePath))
        //    {
        //        return ImagePath; // Возвращаем путь для статичной картинки
        //    }

        //    return "default_image.png"; // Картинка по умолчанию, если ничего не выбрано
        //}
        //public void SetImageDimensions(double width, double height)
        //{
        //    ImageWidth = width;
        //    ImageHeight = height;
        //}
    }
}
