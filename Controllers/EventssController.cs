using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.Models;
using TMSApi.Models.Dto;
using TMSApi.Repositories;

namespace TMSApi.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventssController : ControllerBase
    {

        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EventssController> _logger;

        public EventssController(IEventRepository eventRepository, IMapper mapper, ILogger<EventssController> logger)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]

        public ActionResult<List<EventssDto>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var dtoEvents = events.Select(e => new EventssDto()
            {
                EventId = e.EventId,
                EventDescription = e.EventDescription,
                EventName = e.EventName,
                EventType = e.EventType?.EventTypeName ?? string.Empty,
                Venue = e.Venue?.LocationName ?? string.Empty
            });
           
            return Ok(dtoEvents);
        }

        [HttpGet]

        public async Task<ActionResult<EventssDto>> GetById(int id)
        {
                var @event = await _eventRepository.GetById(id);

                var dtoEvent = _mapper.Map<EventssDto>(@event);

                return Ok(dtoEvent);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatchDto)
        {
            if (eventPatchDto == null) throw new ArgumentNullException(nameof(eventPatchDto));

            var eventEntity = await _eventRepository.GetById(eventPatchDto.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(eventPatchDto, eventEntity);
            _eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }
      
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if(eventEntity == null)
            {
                return NotFound();
            }

            _eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}
