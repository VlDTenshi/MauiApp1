using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.DbContext
{
    public class ApplicationDbContext
    {
        private readonly SQLiteAsyncConnection _database;

        public ApplicationDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Medicine>().Wait();  // Создаем таблицу для модели Exercise
        }

        // Получение всех упражнений
        public Task<List<Medicine>> GetMedicinesAsync()
        {
            return _database.Table<Medicine>().ToListAsync();
        }

        // Добавление или обновление упражнения
        public Task<int> SaveMedicineAsync(Medicine medicine)
        {
            if (medicine.Id != 0)
            {
                return _database.UpdateAsync(medicine);
            }
            else
            {
                return _database.InsertAsync(medicine);
            }
        }

        // Удаление упражнения
        public Task<int> DeleteMedicineAsync(Medicine medicine)
        {
            return _database.DeleteAsync(medicine);
        }
    }
}
