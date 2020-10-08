using ContactManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagementAPI.Repo
{
    public interface IContactRepo
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task CreateContact(Contact contact);
        Task UpdateContact(ContactToUpdate contact);
    }
}
