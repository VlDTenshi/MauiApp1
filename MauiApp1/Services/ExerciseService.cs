using MauiApp1.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SQLite;

namespace MauiApp1.Services
{
    public class ExerciseService
    {
        private SQLiteAsyncConnection _database;

        public event Action ExercisesChanged;
        public ExerciseService(string exercisePath)
        {
            _database = new SQLiteAsyncConnection(exercisePath);
            _database.CreateTableAsync<Exercise>().Wait();
        }

        protected virtual void OnExercisesChanged()
        {
            ExercisesChanged?.Invoke();
        }
        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _database.Table<Exercise>().ToListAsync();
        }

        public Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return _database.Table<Exercise>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveExerciseAsync(Exercise exercise)
        {
            int result;
            if (exercise.Id != 0)
            {
                result = await _database.UpdateAsync(exercise);
            }
            else
            {
                result = await _database.InsertAsync(exercise);
            }

            OnExercisesChanged();
            return result;
        }

        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            var result = _database.DeleteAsync(exercise);

            OnExercisesChanged();
            return result;
        }
    }
}
