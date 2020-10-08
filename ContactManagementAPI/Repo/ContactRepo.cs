using AutoMapper;
using ContactManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagementAPI.Repo
{
    public class ContactRepo : IContactRepo
    {
        private readonly ApplicationDBContext _dBContext;
        private readonly IMapper _mapper;

        public ContactRepo(ApplicationDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task CreateContact(Contact contact)
        {
            await _dBContext.AddAsync<Contact>(contact);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _dBContext.Contacts.ToListAsync();
        }

        public async Task UpdateContact(ContactToUpdate contact)
        {
            var contactToUpdate = await _dBContext.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);
            _mapper.Map(contact, contactToUpdate);
            var c = await _dBContext.SaveChangesAsync();
        }
    }
}
