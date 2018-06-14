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
using Twilio.Rest.Api.V2010.Account;

namespace SymJumbles.Controllers
{
    public class IncomingMessagesController : Controller
    {
        private readonly SymJumblesContext _context;

        public IncomingMessagesController(SymJumblesContext context)
        {
            _context = context;
        }

        // GET: IncomingMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncomingMessage.ToListAsync());
        }

        // GET: IncomingMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingMessage = await _context.IncomingMessage
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomingMessage == null)
            {
                return NotFound();
            }

            return View(incomingMessage);
        }

        // GET: IncomingMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: IncomingMessages/Api
        public async Task<IActionResult> Api()
        {
           
            return View();
        }

        // POST: IncomingMessages/Api
        [HttpPost]
        // TODO: external token/auth key - possibly 
        public async Task<IActionResult> Api([Bind("ID,From,To,Body,AccountSid,ToCountry,ToState,SmsMessageSid,NumMedia,ToCity,FromZip,SmsSid,FromState,SmsStatus,FromCity,FromCountry,ToZip,NumSegments,MessageSid,ApiVersion")] IncomingMessage incomingMessage)
        {
            // default repsonse, in case no incoming POST data can be processed
            string textMessage = "Internal error. This is default fallback message.";

            // store incoming POST data bound to model object in context
            if (ModelState.IsValid)
            {
                // add incoming data as IncomingMessage record to database
                _context.Add(incomingMessage);
                await _context.SaveChangesAsync();
                
                // new Jumble - and internally construct MessageOut
                Jumble jumble = new Jumble(incomingMessage);                
                _context.Add(jumble);
                await _context.SaveChangesAsync();

                // set response content
                textMessage = jumble.MessageOut;                
            }             
            
            // construct TwiML from to be returned message
            MessagingResponse twiml = new MessagingResponse();
            twiml.Message(textMessage);
            string twixml = twiml.ToString();
            
            // output TwiML xml or plain output format
            return Content(textMessage);
        }

        // POST: IncomingMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,From,To,Body,AccountSid,ToCountry,ToState,SmsMessageSid,NumMedia,ToCity,FromZip,SmsSid,FromState,SmsStatus,FromCity,FromCountry,ToZip,NumSegments,MessageSid,ApiVersion")] IncomingMessage incomingMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incomingMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incomingMessage);
        }

        // GET: IncomingMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingMessage = await _context.IncomingMessage.SingleOrDefaultAsync(m => m.ID == id);
            if (incomingMessage == null)
            {
                return NotFound();
            }
            return View(incomingMessage);
        }

        // POST: IncomingMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,From,To,Body,AccountSid,ToCountry,ToState,SmsMessageSid,NumMedia,ToCity,FromZip,SmsSid,FromState,SmsStatus,FromCity,FromCountry,ToZip,NumSegments,MessageSid,ApiVersion")] IncomingMessage incomingMessage)
        {
            if (id != incomingMessage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incomingMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomingMessageExists(incomingMessage.ID))
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
            return View(incomingMessage);
        }

        // GET: IncomingMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomingMessage = await _context.IncomingMessage
                .SingleOrDefaultAsync(m => m.ID == id);
            if (incomingMessage == null)
            {
                return NotFound();
            }

            return View(incomingMessage);
        }

        // POST: IncomingMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incomingMessage = await _context.IncomingMessage.SingleOrDefaultAsync(m => m.ID == id);
            _context.IncomingMessage.Remove(incomingMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomingMessageExists(int id)
        {
            return _context.IncomingMessage.Any(e => e.ID == id);
        }
    }
}
