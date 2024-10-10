using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ContactService
    {
        private SQLiteAsyncConnection _database;

        public event Action ContactsChanged;
        public ContactService(string contactPath)
        {
            _database = new SQLiteAsyncConnection(contactPath);
            _database.CreateTableAsync<ContactU>().Wait();
        }

        protected virtual void OnContactsChanged()
        {
            ContactsChanged?.Invoke();
        }
        public Task<List<ContactU>> GetContactsAsync()
        {
            return _database.Table<ContactU>().ToListAsync();
        }

        public Task<ContactU> GetContactByIdAsync(int id)
        {
            return _database.Table<ContactU>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveContactAsync(ContactU contact)
        {
            int result;
            if (contact.Id != 0)
            {
                result = await _database.UpdateAsync(contact);
            }
            else
            {
                result = await _database.InsertAsync(contact);
            }

            OnContactsChanged();
            return result;
        }

        public Task<int> DeleteContactAsync(ContactU contact)
        {
            var result = _database.DeleteAsync(contact);

            OnContactsChanged();
            return result;
        }
    }
}
