﻿using FBookRating.Models.DTOs.Event;
using FBookRating.Models.Entities;
using FBookRating.Services;
using FBookRating.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FBookRating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var eventEntity = await _eventService.GetEventByIdAsync(id);
            if (eventEntity == null) return NotFound();
            return Ok(eventEntity);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] EventCreateDTO newEventDTO)
        {
            await _eventService.AddEventAsync(newEventDTO);
            return Created("", "Event created successfully.");
        }

        [HttpPost("{eventId}/books/{bookId}")]
        public async Task<IActionResult> AddBookToEvent(Guid eventId, Guid bookId)
        {
            await _eventService.AddBookToEventAsync(eventId, bookId);
            return NoContent();
        }

        [HttpDelete("{eventId}/books/{bookId}")]
        public async Task<IActionResult> RemoveBookFromEvent(Guid eventId, Guid bookId)
        {
            await _eventService.RemoveBookFromEventAsync(eventId, bookId);
            return NoContent();
        }
    }

}
