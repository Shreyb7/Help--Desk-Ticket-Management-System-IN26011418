using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _context;

        public TicketRepository(TicketDbContext context)
        {
            _context = context;
        }

        // Retrieve all tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            var tickets = await _context.Ticket.ToListAsync();
            return tickets;
        }

        // Retrieve ticket by ID
        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            return ticket;
        }

        // Create a new ticket
        public async Task<int> CreateTicketAsync(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket.Id;
        }

        // Update ticket details
        public async Task<bool> UpdateTicketAsync(int id, Ticket updatedTicket)
        {
            var existingTicket = await _context.Ticket.FindAsync(id);

            if (existingTicket == null)
            {
                return false;
            }

            existingTicket.Title = updatedTicket.Title;
            existingTicket.Description = updatedTicket.Description;
            existingTicket.Priority = updatedTicket.Priority;
            existingTicket.Status = updatedTicket.Status;

            await _context.SaveChangesAsync();

            return true;
        }

        // Delete a ticket
        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return false;
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return true;
        }

        // Retrieve tickets based on status
        public async Task<List<Ticket>> GetTicketsByStatusAsync(string status)
        {
            var tickets = await _context.Ticket
                                        .Where(ticket => ticket.Status == status)
                                        .ToListAsync();

            return tickets;
        }
    }
}