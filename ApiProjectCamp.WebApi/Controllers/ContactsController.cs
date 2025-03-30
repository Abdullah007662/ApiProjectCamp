using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDTO;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            Contact contact = new Contact();
            contact.Email= createContactDTO.Email;
            contact.Address= createContactDTO.Address;
            contact.PhoneNumber= createContactDTO.PhoneNumber;
            contact.OpenHours= createContactDTO.OpenHours;
            contact.MapLocation= createContactDTO.MapLocation;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Adres Başarılı Bir Şekilde Kayıt Edildi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _context.Contacts.Find(id);
            _context.Remove(values!);
            _context.SaveChanges();
            return Ok("Adres Başarılı Bir Şekilde Silindi.!");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values= _context.Contacts.Find(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO update)
        {
            Contact contact= new Contact();
            contact.ContactID= update.ContactID;
            contact.Email= update.Email;
            contact.Address= update.Address;
            contact.PhoneNumber= update.PhoneNumber;
            contact.OpenHours = update.OpenHours;
            contact.MapLocation = update.MapLocation;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Adres Başarılı Bir Şekilde Güncellendi.!");
            
        }
    }
}
