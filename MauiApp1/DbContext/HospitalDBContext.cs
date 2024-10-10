using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.DbContext
{
    public class HospitalDBContext
    {
        private readonly SQLiteAsyncConnection _database;

        public HospitalDBContext(string hospitalPath)
        {
            _database = new SQLiteAsyncConnection(hospitalPath);
            _database.CreateTableAsync<Hospital>().Wait();  // Создаем таблицу для модели Exercise
        }

        // Получение всех упражнений
        public Task<List<Hospital>> GetHospitalsAsync()
        {
            return _database.Table<Hospital>().ToListAsync();
        }

        // Добавление или обновление упражнения
        public Task<int> SaveHospitalAsync(Hospital hospital)
        {
            if (hospital.Id != 0)
            {
                return _database.UpdateAsync(hospital);
            }
            else
            {
                return _database.InsertAsync(hospital);
            }
        }

        // Удаление упражнения
        public Task<int> DeleteHospitalAsync(Hospital hospital)
        {
            return _database.DeleteAsync(hospital);
        }
    }
}
