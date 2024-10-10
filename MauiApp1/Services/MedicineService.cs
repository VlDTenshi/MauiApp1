using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class MedicineService
    {
        private SQLiteAsyncConnection _database;

        public event Action MedicinesChanged;
        public MedicineService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Medicine>().Wait();
        }

        protected virtual void OnMedicinesChanged()
        {
            MedicinesChanged?.Invoke();
        }
        public Task<List<Medicine>> GetMedicinesAsync()
        {
            return _database.Table<Medicine>().ToListAsync();
        }

        public Task<Medicine> GetMedicineByIdAsync(int id)
        {
            return _database.Table<Medicine>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveMedicineAsync(Medicine medicine)
        {
            int result;
            if (medicine.Id != 0)
            {
                result = await _database.UpdateAsync(medicine);
            }
            else
            {
                result = await _database.InsertAsync(medicine);
            }

            OnMedicinesChanged();
            return result;
        }

        public Task<int> DeleteMedicineAsync(Medicine medicine)
        {
            var result = _database.DeleteAsync(medicine);

            OnMedicinesChanged();
            return result;
        }
    }
}
