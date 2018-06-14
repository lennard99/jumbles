using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SymJumbles.Models;

using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace SymJumbles.Controllers
{    

    public class JumblesController : Controller
    {
        private readonly SymJumblesContext _context;
        
        public JumblesController(SymJumblesContext context)
        {
            _context = context;
        }      
       

        // GET: Jumbles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jumble.ToListAsync());
        }

        // GET: Jumbles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumble = await _context.Jumble
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jumble == null)
            {
                return NotFound();
            }

            return View(jumble);
        }

        // GET: Jumbles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jumbles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MessageIn,MessageOut,NumberTo,NumberFrom,TimeStamp")] Jumble jumble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jumble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jumble);
        }

        // GET: Jumbles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumble = await _context.Jumble.SingleOrDefaultAsync(m => m.ID == id);
            if (jumble == null)
            {
                return NotFound();
            }
            return View(jumble);
        }

        // POST: Jumbles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MessageIn,MessageOut,NumberTo,NumberFrom,TimeStamp")] Jumble jumble)
        {
            if (id != jumble.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jumble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JumbleExists(jumble.ID))
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
            return View(jumble);
        }

        // GET: Jumbles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumble = await _context.Jumble
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jumble == null)
            {
                return NotFound();
            }

            return View(jumble);
        }

        // POST: Jumbles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jumble = await _context.Jumble.SingleOrDefaultAsync(m => m.ID == id);
            _context.Jumble.Remove(jumble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JumbleExists(int id)
        {
            return _context.Jumble.Any(e => e.ID == id);
        }
    }
}
