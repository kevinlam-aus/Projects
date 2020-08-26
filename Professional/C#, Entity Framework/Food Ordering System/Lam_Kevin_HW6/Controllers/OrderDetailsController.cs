using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lam_Kevin_HW6.DAL;
using Lam_Kevin_HW6.Models;

namespace Lam_Kevin_HW6.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public IActionResult Index(Int32 orderID)
        {
            List<OrderDetail> ods = _context.OrderDetails
                .Include(od => od.Product)
                .Where(o => o.Order.OrderID == orderID).ToList();
            return View(ods);
        }

        // GET: OrderDetails/Create
        public IActionResult Create(Int32 orderID)
        {

            OrderDetail od = new OrderDetail();

            od.Order = _context.Orders.Find(orderID);
            ViewBag.AllProducts = GetAllProducts();

            return View(od);
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailID, ProductQuantity ,Order")] OrderDetail orderDetail, int SelectedProduct)
        {

            //Find the product that the person wants to buy:
            Product product = _context.Products.Find(SelectedProduct);
            //Then set it equal to the orderDetail Product property.
            orderDetail.Product = product;


            //Finding the correct order
            Order ord = _context.Orders.Find(orderDetail.Order.OrderID);
            orderDetail.Order = ord;

            //Now we set the price to the product price. After saving this in the database, this will stay constant (won't change if the price changes)
            orderDetail.ProductPrice = product.ProductPrice;

            //The extended price is the price of the product times how much they are buying.
            orderDetail.ExtendedProductPrice = product.ProductPrice * orderDetail.ProductQuantity;


            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Orders", new { id = orderDetail.Order.OrderID });
            }

            ViewBag.AllProducts = GetAllProducts();
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderDetailID,ProductQuantity,ProductPrice,ExtendedPrice")] OrderDetail orderDetail)
        {
            //find the existing registration detail in the database
            //include both registration and course
            OrderDetail dbOD = _context.OrderDetails
                 .Include(rd => rd.Product)
                 .Include(rd => rd.Order)
                 .FirstOrDefault(r => r.OrderDetailID == orderDetail.OrderDetailID);

            //update the scalar properties
            dbOD.ProductPrice = dbOD.Product.ProductPrice;
            dbOD.ProductQuantity = orderDetail.ProductQuantity;
            dbOD.ExtendedProductPrice = dbOD.ProductPrice * dbOD.ProductQuantity;

            if (ModelState.IsValid)
            {
                _context.Update(dbOD);
                _context.SaveChanges();
                return RedirectToAction("Details", "Orders", new { id = dbOD.Order.OrderID });
            }

            return View(dbOD);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //update this query to include registration so you can redirect to the
            //correct registration page
            OrderDetail orderDetail = _context.OrderDetails
                .Include(ord => ord.Order)
                .FirstOrDefault(o => o.OrderDetailID == id);
            Order or = orderDetail.Order;
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();

            //update this redirect statement to send user back to details
            return RedirectToAction("Details", "Orders", new { id = or.OrderID });
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }

        private SelectList GetAllProducts()
        {
            //get a list of all products from the database
            List<Product> AllProducts = _context.Products.ToList();

            //convert this to a select list
            //note that ProductID and ProductName are the names of fields in the Course model class
            SelectList products = new SelectList(AllProducts, "ProductID", "ProductName");

            //return the select list
            return products;

        }
    }
}
