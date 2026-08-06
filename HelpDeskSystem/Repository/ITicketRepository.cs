using HelpDeskAPI.Models;

namespace HelpDeskAPI.Repository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTicketsAsync();

        Task<Ticket> GetTicketByIdAsync(int id);

        Task<int> CreateTicketAsync(Ticket t);

        Task<bool> UpdateTicketAsync(int id, Ticket tModified);

        Task<bool> DeleteTicketAsync(int id);

        Task<List<Ticket>> GetTicketsByStatusAsync(string status);
    }
}
