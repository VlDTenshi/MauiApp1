using MauiApp1.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MauiApp1.Services
{
    public class ExerciseService
    {
        List<Exercise> exerciseList = new();

        private readonly string filePath;

        //HttpClient httpClient

        public ExerciseService()
        {
            //Path to File --> .JSON
            filePath = Path.Combine(FileSystem.AppDataDirectory, "exercisedata.json");

            //this.httpClient = new HttpClient();
        }
        public async Task<List<Exercise>> GetExercise(bool forceReload = false)
        {
            if(exerciseList.Count > 0 && !forceReload) 
            return exerciseList;

            /*var response = await httpClient.GetAsync("URL.json");
             * if (response.IsSuccessStatusCode) 
             * {
             *      exerciseList = await response.Content.ReadFromJsonAsync<List<Exercise>>();
             * }
             */
            try
            {
                //Checking does the file exist in local storage
                if (File.Exists(filePath))
                {
                    //If exists then reading a data from local storage
                    var contents = await File.ReadAllTextAsync(filePath);
                    exerciseList = JsonSerializer.Deserialize<List<Exercise>>(contents, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Exercise>();
                }
                else
                {

                    //Open JSON file from the app package
                    using var stream = await FileSystem.OpenAppPackageFileAsync("exercisedata.json");
                    using var reader = new StreamReader(stream);

                    //Read contents of file
                    var contents = await reader.ReadToEndAsync();

                    //Deserializing of JSON to list of Exercise object
                    exerciseList = JsonSerializer.Deserialize<List<Exercise>>(contents, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Exercise>();

                    //Storing data in local file to keep working with him
                    await SaveExercisesToFile();
                }

                return exerciseList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting exercises: {ex.Message}");
                return new List<Exercise>();
            }
            
        }
        public async Task AddExercise (Exercise exercise)
        {
            //Adding a new exercise to list
            exerciseList.Add(exercise);

            //Saving refreshed list to file
            await SaveExercisesToFile();
        }

        public async Task RemoveExercise(Exercise exercise)
        {
            var exercises = await GetExercise();
            var ExerciseToRemove = exerciseList.FirstOrDefault(f => f.Id == exercise.Id);

            if (ExerciseToRemove != null)
            {
                //Removing an exercise from the list
                exercises.Remove(ExerciseToRemove);

                await SaveExercisesToFile();

            }
        }

        public async Task UpdateExercise(Exercise updatedExercise)
        {
            var exerciseToUpdate = exerciseList.FirstOrDefault(e => e.Name == updatedExercise.Name);
            if (exerciseToUpdate != null)
            {
                // Обновляем свойства
                exerciseToUpdate.Description = updatedExercise.Description;
                exerciseToUpdate.Repetition = updatedExercise.Repetition;
                // Можно обновить другие свойства, если нужно

                // Сохраняем обновленный список в файл
                await SaveExercisesToFile();
            }
        }
        //Method for saving exercise list to file JSON
        private async Task SaveExercisesToFile()
        {
            try
            {
                //Serializing exercise list to JSON
                var json = JsonSerializer.Serialize(exerciseList, new JsonSerializerOptions { WriteIndented = true });

                //Saving JSON to local file
                await File.WriteAllTextAsync(filePath, json);
            }
            catch(Exception ex) 
            {
                Debug.WriteLine($"Error saving exercises to file: {ex.Message}");
            }
        }
    }
}
