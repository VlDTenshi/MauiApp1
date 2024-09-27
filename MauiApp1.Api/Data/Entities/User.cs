using System;
using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Api.Data.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(150)]
        public string Address { get; set; }

        [Required, MaxLength(20)]
        public string Salt { get; set; }

        [Required, MaxLength(100)]
        public string Hash { get; set; }
    }
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [Required, MaxLength(100)]
        public string Image { get; set; }

        public ICollection<MedicineOption> Option { get; set; }

    }
    public class MedicineOption
    {
        public int MedicineId { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; }
        //public string Solid { get; set; }

        //[Required, MaxLength(50)]
        //public string Soft { get; set; }

        //[Required, MaxLength(50)]
        //public string Liquid { get; set; }

        //[Required, MaxLength(50)]
        //public string Gaseous { get; set; }

        public virtual Medicine Medicine { get; set; }
    }

    public class Order
    {
        [Key]
        public long Id { get; set; }

        public DateTime OrderdAt { get; set; } = DateTime.Now;

        public Guid CustomerId { get; set; }

        [Required, MaxLength(30)]
        public Guid CustomerName { get; set; }

        [Required, MaxLength(100)]
        public Guid CustomerEmail { get; set; }

        [Required, MaxLength(150)]
        public Guid CustomerAddress { get; set; }

        [Range(0.1, double.MaxValue)]
        public double TotalPrice { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }

        public long OrderId { get; set; }

        public int MedicineId { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; }
        //[Required, MaxLength(50)]
        //public string Solid { get; set; }

        //[Required, MaxLength(50)]
        //public string Soft { get; set; }

        //[Required, MaxLength(50)]
        //public string Liquid { get; set; }

        //[Required, MaxLength(50)]
        //public string Gaseous { get; set; }

        [Range(0.1, double.MaxValue)]
        public double TotalPrice { get; set; }

        public virtual Order Order { get; set; }

    }
}