using HelpDeskMVC.Models;
using HelpDeskMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskMVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // Display Create Ticket page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var isCreated = await _ticketService.CreateNewTicketAsync(ticket);

                if (isCreated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Message = "Unable to create the ticket.";
            return View(ticket);
        }

        // Display all tickets
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return View(tickets);
        }

        // Display ticket details
        public async Task<IActionResult> GetTicketDetails(int id)
        {
            var ticket = await _ticketService.ViewTicketDetailsAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // Edit Ticket
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.ViewTicketDetailsAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _ticketService.EditTicketAsync(id, ticket);

                if (isUpdated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Message = "Unable to update the ticket.";
            return View(ticket);
        }

        // Delete Ticket
        public async Task<IActionResult> Delete(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // Search tickets by status
        public async Task<IActionResult> SearchByStatus(string status)
        {
            ViewData["SearchTitle"] = status;

            var tickets = new List<Ticket>();

            if (!string.IsNullOrWhiteSpace(status))
            {
                tickets = await _ticketService.GetTicketsByStatusAsync(status);
            }

            return View(tickets);
        }
    }
}