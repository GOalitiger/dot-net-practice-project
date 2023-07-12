using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dot_net_practice_project.Data;
using dot_net_practice_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dot_net_practice_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private ContactAPIDbContext dbContext;
        public ContactsController(ContactAPIDbContext ContactDb)
        {
            this.dbContext = ContactDb;
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult GetContacts()
        {

            return Ok(dbContext.Contacts.ToList());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContactsById(Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                return Ok(contact);
            }


            return NotFound();
        }


        //creating a contact
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactRequest requestBody)
        {
            var newContact = new Contact();
            newContact.Id = Guid.NewGuid();
            newContact.FullName = requestBody.FullName
;            newContact.Email = requestBody.Email;
            newContact.Address = requestBody.Address;
            newContact.PhoneNumber = requestBody.PhoneNumber;
            newContact.DateOfCreation = DateOnly.FromDateTime(DateTime.Now);
            dbContext.Contacts.Add(newContact);
            await dbContext.SaveChangesAsync();

            return Ok(newContact);
        }
    }
}

