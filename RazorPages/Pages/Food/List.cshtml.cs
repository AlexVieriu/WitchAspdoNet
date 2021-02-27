using DataLibrary.Data;
using DataLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPages.Pages.Food
{
    public class ListModel : PageModel
    {
        private readonly IFoodData _foodData;

        public ListModel(IFoodData foodData)
        {
            _foodData = foodData;
        }
        public List<FoodModel> FoodList { get; set; }

        public async Task OnGet()
        {
            FoodList = await _foodData.GetFood();                        
        }
    }
}
