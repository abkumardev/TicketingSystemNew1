using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Business.Entities;
using TicketingSystem.DeskPro;

namespace TicketingSystem.UI.Controllers
{
    public class DeskProController : Controller
    {
        public void CreateDeskProTicket(Request request)
        {
            DeskProTicket deskProTicket = new DeskProTicket();
            deskProTicket.RequestUId = request.RequestUId;
            deskProTicket.TicketId = request.RequestId;
            deskProTicket.EmployeeId = request.RequestResourceId;
            deskProTicket.DateCreated = request.CreatedDate;
            deskProTicket.TicketStatus = request.TicketStatus;
            // Web API call to post data
        }
    }
}
