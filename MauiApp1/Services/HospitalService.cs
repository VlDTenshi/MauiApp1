using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class HospitalService
    {
        private SQLiteAsyncConnection _database;

        public event Action HospitalsChanged;
        public HospitalService(string hospitalPath)
        {
            _database = new SQLiteAsyncConnection(hospitalPath);
            _database.CreateTableAsync<Hospital>().Wait();
        }

        protected virtual void OnHospitalsChanged()
        {
            HospitalsChanged?.Invoke();
        }
        public Task<List<Hospital>> GetHospitalsAsync()
        {
            return _database.Table<Hospital>().ToListAsync();
        }

        public Task<Hospital> GetHospitalByIdAsync(int id)
        {
            return _database.Table<Hospital>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveHospitalAsync(Hospital hospital)
        {
            int result;
            if (hospital.Id != 0)
            {
                result = await _database.UpdateAsync(hospital);
            }
            else
            {
                result = await _database.InsertAsync(hospital);
            }

            OnHospitalsChanged();
            return result;
        }

        public Task<int> DeleteHospitalAsync(Hospital hospital)
        {
            var result = _database.DeleteAsync(hospital);

            OnHospitalsChanged();
            return result;
        }
    }
}
