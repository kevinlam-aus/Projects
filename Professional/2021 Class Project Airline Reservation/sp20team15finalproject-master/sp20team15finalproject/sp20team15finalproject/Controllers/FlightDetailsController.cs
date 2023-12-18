﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sp20team15finalproject.DAL;
using sp20team15finalproject.Models;

namespace sp20team15finalproject.Controllers
{
    public class FlightDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public FlightDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FlightDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.FlightDetails.ToListAsync());
        }

        // GET: FlightDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDetail = await _context.FlightDetails
                .FirstOrDefaultAsync(m => m.FlightDetailID == id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            return View(flightDetail);
        }

        // GET: FlightDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightDetailID,Date,FlightStatus")] FlightDetail flightDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightDetail);
        }

        // GET: FlightDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDetail = await _context.FlightDetails.FindAsync(id);
            if (flightDetail == null)
            {
                return NotFound();
            }
            return View(flightDetail);
        }

        // POST: FlightDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightDetailID,Date,FlightStatus")] FlightDetail flightDetail)
        {
            if (id != flightDetail.FlightDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightDetailExists(flightDetail.FlightDetailID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flightDetail);
        }

        // GET: FlightDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDetail = await _context.FlightDetails
                .FirstOrDefaultAsync(m => m.FlightDetailID == id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            return View(flightDetail);
        }

        // POST: FlightDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightDetail = await _context.FlightDetails.FindAsync(id);
            _context.FlightDetails.Remove(flightDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightDetailExists(int id)
        {
            return _context.FlightDetails.Any(e => e.FlightDetailID == id);
        }
    }
}
