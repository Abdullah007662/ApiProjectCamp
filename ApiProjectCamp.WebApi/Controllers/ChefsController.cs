using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateChefs(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef Başarılı Bir Şekilde Kayıt Edildi");
        }
        [HttpDelete]
        public IActionResult DeleteChefs(int id)
        {
            var values = _context.Chefs.Find(id);
            _context.Chefs.Remove(values!);
            _context.SaveChanges();
            return Ok("Şef Başarılı Bir Şekilde Silindi.!");
        }
        [HttpGet("{id}")]
        public IActionResult GetChefs(int id)
        {
            var values = _context.Chefs.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateChefs(Chef chef)
        {
            var values = _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef Başarılı Bir Şekilde Güncellendi.!");
        }
    }
}
