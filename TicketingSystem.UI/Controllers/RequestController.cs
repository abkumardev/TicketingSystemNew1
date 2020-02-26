using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingSystem.Business.Entities;
using TicketingSystem.ZenDesk;

namespace TicketingSystem.UI.Controllers
{
    public class RequestController : Controller
    {
        //IMapperService<ZenDeskTicket> mapperService;
        //public RequestController(IMapperService<ZenDeskTicket> _mapperService)
        //{

        //}
        public IActionResult Index()
        {
            var enumData = from TicketSystemTypeEnum e in Enum.GetValues(typeof(TicketSystemTypeEnum))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            ViewBag.EnumList = new SelectList(enumData, "ID", "Name");
            return View(ViewBag);
        }

        [HttpPost]
        public IActionResult ReDirectToTicketSystem(TicketSystemTypeEnum ticketSystemType)
        {
            //TicketSystemTypeEnum ticketSystemTypeEnum = (TicketSystemTypeEnum)ticketSystemType;
            Request request = new Request();
            request.RequestUId = Guid.NewGuid();
            request.RequestId = Guid.NewGuid();
            request.TicketStatus = StatusEnum.Active;
            request.RequestResourceId = Guid.NewGuid();
            request.TicketSystemType = TicketSystemTypeEnum.DeskPro;
            request.CreatedDate = DateTime.Now;
            if (ticketSystemType == TicketSystemTypeEnum.DeskPro)
            {
                return RedirectToAction("CreateDeskProTicket", "DeskPro", new { Request = request });
            }
            else if (ticketSystemType == TicketSystemTypeEnum.ZenDesk)
            {
                return RedirectToAction("CreateZenDeskTicket", "ZenDesk", new { Request = request });
            }
            else
                return View("Index");

        }


    }
}