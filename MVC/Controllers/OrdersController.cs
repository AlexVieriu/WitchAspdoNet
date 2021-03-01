﻿using DataLibrary.Data;
using DataLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public OrdersController(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var food = await _foodData.GetFood();

            OrderCreateModel model = new();

            food.ForEach(x =>
            {
                model.FoodItems.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Description });
            });

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var food = await _foodData.GetFood();

            order.Total = order.Quantity * food.Where(x => x.Id == order.FoodId).First().Price;

            int id = await _orderData.CreareOrder(order);

            return RedirectToAction("Display", new { id});
        }

        [HttpGet]
        public async Task<IActionResult> Display(int id)
        {
            OrderDisplayModel displayOrder = new();
            displayOrder.Order = await _orderData.GetOderById(id);

            if (displayOrder.Order != null)
            {
                var food = await _foodData.GetFood();

                displayOrder.ItemPurchased = food.Where(x =>
                                            x.Id == displayOrder.Order.FoodId).FirstOrDefault()?.Title;
            }

            return View(displayOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string orderName)
        {
            await _orderData.UpdateOrderName(id, orderName);

            return RedirectToAction("Display", new { id });
        }


        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderData.GetOderById(id);
            
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrderModel order)
        {
            await _orderData.DeleteOrder(order.Id);

            return RedirectToAction("Create");
        }
    }
}
