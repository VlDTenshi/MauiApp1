using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.DbContext
{
    public class ExercisesDBContext
    {
        private readonly SQLiteAsyncConnection _database;

        public ExercisesDBContext(string exercisePath)
        {
            _database = new SQLiteAsyncConnection(exercisePath);
            _database.CreateTableAsync<Exercise>().Wait();  // Создаем таблицу для модели Exercise
        }

        // Получение всех упражнений
        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _database.Table<Exercise>().ToListAsync();
        }

        // Добавление или обновление упражнения
        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.Id != 0)
            {
                return _database.UpdateAsync(exercise);
            }
            else
            {
                return _database.InsertAsync(exercise);
            }
        }

        // Удаление упражнения
        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            return _database.DeleteAsync(exercise);
        }
    }
}
