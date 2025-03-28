using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values=_context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Başarılı Bir Şekilde Kayıt Edildi.!");
        }
        [HttpDelete]

        //Deneme
        //Deneme Yapıldı
        public IActionResult DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }
        [HttpGet]
        public IActionResult deneme()
        {
            return Ok();
        }
    }
}
