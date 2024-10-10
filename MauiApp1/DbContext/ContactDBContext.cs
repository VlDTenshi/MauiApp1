using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.DbContext
{
    public class ContactDBContext
    {
        private readonly SQLiteAsyncConnection _database;

        public ContactDBContext(string contactPath)
        {
            _database = new SQLiteAsyncConnection(contactPath);
            _database.CreateTableAsync<ContactU>().Wait();  // Создаем таблицу для модели Exercise
        }

        // Получение всех упражнений
        public Task<List<ContactU>> GetContactsAsync()
        {
            return _database.Table<ContactU>().ToListAsync();
        }

        // Добавление или обновление упражнения
        public Task<int> SaveContactAsync(ContactU contact)
        {
            if (contact.Id != 0)
            {
                return _database.UpdateAsync(contact);
            }
            else
            {
                return _database.InsertAsync(contact);
            }
        }

        // Удаление упражнения
        public Task<int> DeleteContactAsync(ContactU contact)
        {
            return _database.DeleteAsync(contact);
        }
    }
}
