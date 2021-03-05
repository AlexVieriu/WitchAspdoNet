using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorClient.Models
{
    public class OrderUpdateModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The name need to be max 20 char and min 3 characters", MinimumLength = 3)]
        [DisplayName("Name for the Order")]
        public string OrderName { get; set; }
    }
}
