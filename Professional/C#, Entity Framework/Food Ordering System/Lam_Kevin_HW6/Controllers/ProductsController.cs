using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lam_Kevin_HW6.DAL;
using Lam_Kevin_HW6.Models;
using Microsoft.AspNetCore.Authorization;

namespace Lam_Kevin_HW6.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
            .Include(ps => ps.ProductSuppliers)
            .ThenInclude(ps => ps.Supplier)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.AllSuppliers = GetAllSuppliers();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductID,ProductName,ProductDescription,ProductPrice")] Product product, int[] SelectedSuppliers)
        {
            //Get the next product number from the database.  This code lives in class in a folder called 'Utilities'
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();

                //add navigational data
                //find the product with the same product number as the one we just created
                Product dbProduct = _context.Products.FirstOrDefault(c => c.ProductID == product.ProductID);

                //loop through the selected departments
                foreach (int s in SelectedSuppliers)
                {
                    //find the department specified by the int
                    Supplier supp = _context.Suppliers.Find(s);

                    //create a new instance of the bridge table class
                    ProductSupplier ps = new ProductSupplier();
                    ps.Product = dbProduct;
                    ps.Supplier = supp;

                    //add the new record to the database
                    _context.ProductSuppliers.Add(ps);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            //re-populate the Viewbag in case there is an error
            ViewBag.AllSuppliers = GetAllSuppliers();
            return View(product);
        }




        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.AllSuppliers = GetAllSuppliers(product.ProductID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductID,ProductName,ProductDescription,ProductPrice")] Product product, int[] SelectedSuppliers)
        {
            if (ModelState.IsValid)
            {
                Product dbProduct = _context.Products
                    .Include(ps => ps.ProductSuppliers).ThenInclude(ps => ps.Supplier)
                    .FirstOrDefault(p => p.ProductID == product.ProductID);

                //create a list of Suppliers to remove
                List<ProductSupplier> SuppliersToRemove = new List<ProductSupplier>();

                //find Suppliers that should no longer be there
                foreach (ProductSupplier ps in dbProduct.ProductSuppliers)
                {
                    if (SelectedSuppliers.Contains(ps.Supplier.SupplierID) == false)  //this Supplier is not on the new list
                    {
                        SuppliersToRemove.Add(ps);
                    }
                }

                //remove Suppliers you found in the list above - this has to be 2 separate steps because you can't 
                //iterate over a list you are removing things from
                foreach (ProductSupplier ps in SuppliersToRemove)
                {
                    _context.ProductSuppliers.Remove(ps);
                    _context.SaveChanges();
                }

                //add Suppliers that aren't already there
                foreach (int i in SelectedSuppliers)
                {
                    if (dbProduct.ProductSuppliers.Any(s => s.Supplier.SupplierID == i) == false) //Supplier is not already connect to this Product
                    {
                        //create a new instance of the bridge table class
                        ProductSupplier ps = new ProductSupplier();
                        ps.Supplier = _context.Suppliers.Find(i);
                        ps.Product = dbProduct;

                        //add the new instance to the database
                        _context.ProductSuppliers.Add(ps);
                        _context.SaveChanges();
                    }
                }

                //update the scalar properties
                dbProduct.ProductPrice = product.ProductPrice;
                dbProduct.ProductName = product.ProductName;
                dbProduct.ProductDescription = product.ProductDescription;

                //save changes
                _context.Products.Update(dbProduct);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.AllSuppliers = GetAllSuppliers(product.ProductID);
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }

        private MultiSelectList GetAllSuppliers()
        {
            List<Supplier> Suppliers = _context.Suppliers.ToList();
            MultiSelectList AllSuppliers = new MultiSelectList(Suppliers, "SupplierID", "SupplierName");
            return AllSuppliers;
        }


        private MultiSelectList GetAllSuppliers(Int32 productID)
        {
            //make a new list of all the Suppliers
            List<Supplier> Suppliers = _context.Suppliers.ToList();

            //get the list of Suppliers for this Product
            List<ProductSupplier> productSuppliers = _context.ProductSuppliers.Where(ps => ps.Product.ProductID == productID).ToList();

            //loop through this list to convert to a list of integers
            List<Int32> selectedSuppliers = new List<Int32>();

            foreach (ProductSupplier ps in productSuppliers)
            {
                selectedSuppliers.Add(ps.Supplier.SupplierID);
            }

            MultiSelectList AllSuppliers = new MultiSelectList(Suppliers, "SupplierID", "SupplierName", selectedSuppliers);

            //return the multiselect list
            return AllSuppliers;
        }

    }
}