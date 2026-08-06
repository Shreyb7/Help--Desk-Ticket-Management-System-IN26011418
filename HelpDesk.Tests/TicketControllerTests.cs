using Moq;
using HelpDeskAPI.Controllers;
using HelpDeskAPI.Models;
using HelpDeskAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace HelpDeskTests
{
    public class TicketApiControllerTests
    {
        List<Ticket> tickets = new List<Ticket> {
            new Ticket {
                Id = 1,
                Title = "Network Outage",
                Description = "Cannot connect to VPN",
                Priority = "High",
                Status = "Open",
                RaisedBy = "Alice",
                CreatedDate = DateTime.Now
            },
            new Ticket {
                Id = 2,
                Title = "Keyboard broken",
                Description = "Spacebar is stuck",
                Priority = "Low",
                Status = "In Progress",
                RaisedBy = "Bob",
                CreatedDate = DateTime.Now
            }
        };

        [Fact]
        public async Task GetAllTickets_ReturnsOkResult_WhenTicketsExist()
        {
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(x => x.GetAllTicketsAsync()).ReturnsAsync(tickets);
            var controller = new TicketController(mockRepo.Object);


            var result = await controller.GetAllTickets();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<Ticket>>(okResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetTicketById_ReturnsOkResult_WhenTicketExists()
        {
            var mockRepo = new Mock<ITicketRepository>();
            var singleTicket = tickets[0];
            mockRepo.Setup(x => x.GetTicketByIdAsync(1)).ReturnsAsync(singleTicket);
            var controller = new TicketController(mockRepo.Object);

            var result = await controller.ViewDetails(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Ticket>(okResult.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("Network Outage", model.Title);
        }

        [Fact]
        public async Task GetTicketById_ReturnsNotFound_WhenTicketDoesNotExist()
        {
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(x => x.GetTicketByIdAsync(99)).ReturnsAsync((Ticket)null);
            var controller = new TicketController(mockRepo.Object);

            var result = await controller.ViewDetails(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateTicket_ReturnsOkResult_WhenTicketIsCreatedSuccessfully()
        {
            var mockRepo = new Mock<ITicketRepository>();
            var newTicket = new Ticket
            {
                Id = 3,
                Title = "Monitor not turning on",
                Description = "Check power cable",
                Priority = "Medium",
                Status = "Open",
                RaisedBy = "Charlie",
                CreatedDate = DateTime.Now
            };

            mockRepo.Setup(x => x.CreateTicketAsync(newTicket)).ReturnsAsync(3);
            var controller = new TicketController(mockRepo.Object);

            var result = await controller.CreateTicket(newTicket);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateTicket_ReturnsBadRequest_WhenTicketIsNull()
        {
            var mockRepo = new Mock<ITicketRepository>();
            var controller = new TicketController(mockRepo.Object);

            var result = await controller.CreateTicket(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetTicketsByStatus_ReturnsOkResult_WhenMatchingTicketsExist()
        {
            var mockRepo = new Mock<ITicketRepository>();
            string searchStatus = "Open";

            var openTickets = tickets.Where(t => t.Status == searchStatus).ToList();

            mockRepo.Setup(x => x.GetTicketsByStatusAsync(searchStatus)).ReturnsAsync(openTickets);
            var controller = new TicketController(mockRepo.Object);

            var result = await controller.GetTicketsByStatus(searchStatus);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<Ticket>>(okResult.Value);

            Assert.Single(model);
            Assert.Equal(searchStatus, model[0].Status);
        }
    }
}