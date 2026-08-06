using HelpDeskAPI.Models;
using HelpDeskAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // Create a new ticket
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }

            var ticketId = await _ticketRepository.CreateTicketAsync(ticket);

            return Ok($"Ticket created successfully. ID: {ticketId}");
        }

        // Retrieve all tickets
        [HttpGet("All")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketRepository.GetAllTicketsAsync();

            return Ok(tickets);
        }

        // Retrieve ticket details
        [HttpGet("{id}")]
        public async Task<IActionResult> ViewDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var ticket = await _ticketRepository.GetTicketByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // Update ticket
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket updatedTicket)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var isUpdated = await _ticketRepository.UpdateTicketAsync(id, updatedTicket);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok("Ticket updated successfully.");
        }

        // Delete ticket
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var isDeleted = await _ticketRepository.DeleteTicketAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok("Ticket deleted successfully.");
        }

        // Retrieve tickets by status
        [HttpGet("Status/{status}")]
        public async Task<IActionResult> GetTicketsByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return BadRequest();
            }

            var tickets = await _ticketRepository.GetTicketsByStatusAsync(status);

            return Ok(tickets);
        }
    }
}