using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.MessageDTO;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessagesList()
        {
            var values = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(values));
        }
        [HttpPost]
        public IActionResult CreateMessages(CreateMessageDTO createMessageDTO)
        {
            var value = _mapper.Map<Message>(createMessageDTO);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteMessages(int id)
        {
            var values = _context.Messages.Find(id);
            _context.Messages.Remove(values!);
            _context.SaveChanges();
            return Ok("Başarılı Bir Şekilde Silindi");
        }
        [HttpGet("GetByMessage")]
        public IActionResult GetMessages(int id)
        {
            var values = _context.Messages.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateMessages(UpdateMessageDTO updateMessageDTO)
        {
            var values = _mapper.Map<Message>(updateMessageDTO);
            _context.Messages.Update(values);
            _context.SaveChanges();
            return Ok("Başarılı Bir Şekilde Güncellendi.!");
        }
    }
}
