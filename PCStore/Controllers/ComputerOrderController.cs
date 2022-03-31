﻿using Microsoft.AspNetCore.Mvc;
using PCStore.Core.Contracts;
using PCStore.Core.Models;

namespace PCStore.Controllers
{
    public class ComputerOrderController : Controller
    {
        private readonly IOrderService service;

        public ComputerOrderController(IOrderService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> PlaceOrder(CustomerOrder order)
        {
            try
            {
                await service.PlaceOrder(order);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            return Ok();
        }
    }
}