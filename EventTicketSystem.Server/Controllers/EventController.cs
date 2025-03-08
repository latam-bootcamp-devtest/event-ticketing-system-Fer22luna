﻿using EventTicketSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;
using EventTicketSystem.Server.Models;

namespace EventTicketSystem.Server.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            service = _service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var employee = await _service.GetEventById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }


        [HttpPost]
        public async Task<ActionResult> AddEvent(Event e)
        {
            await _service.AddEvent(e);
            return CreatedAtAction(nameof(GetEventById), new { id = e.eventId }, e);
        }



    }
}
