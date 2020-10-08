using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManagementAPI.Models;
using ContactManagementAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactManagementController : ControllerBase
    {
        private readonly IContactRepo _repo;

        public ContactManagementController(IContactRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _repo.GetAllContacts();
            return Ok(contacts);
        }

        [HttpPost("createcontact")]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            await _repo.CreateContact(contact);
            return Ok(StatusCodes.Status201Created);
        }

        [HttpPost("updatecontact")]
        public async Task<IActionResult> UpdateContact(ContactToUpdate contact)
        {
            await _repo.UpdateContact(contact);
            return NoContent();
        }
    }
}