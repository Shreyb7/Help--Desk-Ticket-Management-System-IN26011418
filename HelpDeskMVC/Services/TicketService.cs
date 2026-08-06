using HelpDeskMVC.Models;

namespace HelpDeskMVC.Services
{
    public class TicketService
    {
        private readonly HttpClient _httpClient;

        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Create a new ticket
        public async Task<bool> CreateNewTicketAsync(Ticket ticket)
        {
            var response = await _httpClient.PostAsJsonAsync("", ticket);
            return response.IsSuccessStatusCode;
        }

        // Retrieve all tickets
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Ticket>>("All");
        }

        // Retrieve ticket details
        public async Task<Ticket?> ViewTicketDetailsAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ticket>($"{id}");
        }

        // Update ticket information
        public async Task<bool> EditTicketAsync(int id, Ticket updatedTicket)
        {
            var response = await _httpClient.PutAsJsonAsync($"{id}", updatedTicket);
            return response.IsSuccessStatusCode;
        }

        // Delete a ticket
        public async Task<bool> DeleteTicketAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            return response.IsSuccessStatusCode;
        }

        // Retrieve tickets by status
        public async Task<List<Ticket>> GetTicketsByStatusAsync(string status)
        {
            var response = await _httpClient.GetAsync($"Status/{status}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Ticket>>();
            }

            return new List<Ticket>();
        }
    }
}