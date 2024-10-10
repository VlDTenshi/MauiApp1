using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{

    // Service class to manage data operations related to medicines
    public class MedicineService
    {

        // SQLite database connection instance
        private SQLiteAsyncConnection _database;

        // Event triggered when the medicines collection changes
        public event Action MedicinesChanged;

        // Constructor to initialize the SQLite connection and create the Medicines table if it doesn't exist
        public MedicineService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath); // Initialize the SQLite connection with the provided database path
            _database.CreateTableAsync<Medicine>().Wait(); // Create the Medicine table asynchronously
        }

        // Method to raise the MedicinesChanged event
        protected virtual void OnMedicinesChanged()
        {
            MedicinesChanged?.Invoke(); // Invoke the event if there are subscribers
        }

        // Method to get a list of all medicines from the database
        public Task<List<Medicine>> GetMedicinesAsync()
        {
            // Retrieve all records from the Medicine table
            return _database.Table<Medicine>().ToListAsync();
        }

        // Method to get a specific medicine by its ID
        public Task<Medicine> GetMedicineByIdAsync(int id)
        {
            // Retrieve the medicine with the specified ID
            return _database.Table<Medicine>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        // Method to save (insert or update) a medicine in the database
        public async Task<int> SaveMedicineAsync(Medicine medicine)
        {
            int result;

            // If the medicine already exists (has an ID), update it
            if (medicine.Id != 0)
            {
                result = await _database.UpdateAsync(medicine);
            }
            else
            {
                result = await _database.InsertAsync(medicine); // If the medicine doesn't exist (ID is 0), insert it as a new record
            }

            // Raise the MedicinesChanged event after the database operation
            OnMedicinesChanged();
            return result;
        }
        // Method to delete a medicine from the database
        public Task<int> DeleteMedicineAsync(Medicine medicine)
        {
            var result = _database.DeleteAsync(medicine); // Delete the specified medicine

            // Raise the MedicinesChanged event after the deletion
            OnMedicinesChanged();
            return result; // Return the result of the deletion operation
        }
    }
}
