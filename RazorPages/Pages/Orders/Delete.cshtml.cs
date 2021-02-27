using DataLibrary.Data;
using DataLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace RazorPages.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderData _orderData;

        public DeleteModel(IOrderData orderData)
        {
            _orderData = orderData;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public OrderModel Order { get; set; }

        public async Task OnGet()
        {
            Order = await _orderData.GetOderById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _orderData.DeleteOrder(Id);

            return RedirectToPage("./Create");
        }
    }
}
