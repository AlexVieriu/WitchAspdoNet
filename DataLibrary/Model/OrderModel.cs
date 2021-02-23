using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Model
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The name need to be max 20 char and min 3 characters", MinimumLength = 3)]
        [DisplayName("Name for the Order")]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        public int FoodId { get; set; }

        [Required]
        [Range(1,10,ErrorMessage ="You can select up to 10 meals")]
        public int Quatity { get; set; }

        public decimal Total { get; set; }
    }
}
