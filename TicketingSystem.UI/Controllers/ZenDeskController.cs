using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Business.Entities;
using TicketingSystem.ZenDesk;

namespace TicketingSystem.UI.Controllers
{
    public class ZenDeskController : Controller
    {
        public void CreateZenDeskTicket(Request request)
        {
            ZenDeskTicket zenDeskTicket = new ZenDeskTicket();
            zenDeskTicket.TicketNumber = request.RequestUId;
            zenDeskTicket.ResourceId = request.RequestResourceId;
            zenDeskTicket.TicketStatus = request.TicketStatus;
            // Web API call to post data
        }
    }
}