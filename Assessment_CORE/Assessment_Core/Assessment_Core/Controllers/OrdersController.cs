using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment_Core.Models;

namespace Assessment_Core.Controllers
{
    public class OrdersController : Controller
    {
        private readonly NwContext _context;

        public OrdersController(NwContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var nwContext = _context.OrderDetails;
            return View(await nwContext.ToListAsync());
        }

       
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "ShipperId");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "ShipperId", order.ShipVia);
            return View(order);
        }

       public async Task<IActionResult> Orderbyid(int id)
        {
            var a=_context.OrderDetails.FirstOrDefault(a=> a.OrderId== id);
            return View(a);
        }
        public async Task<IActionResult> byorderdate(DateTime dt)
        {
            var a = _context.Orders.Where(a => a.OrderDate == dt).ToList();
            return View(a);
        }
        

    }
}
