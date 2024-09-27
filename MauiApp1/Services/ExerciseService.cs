using MauiApp1.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ExerciseService
    {
        List<Exercise> exerciseList = new();

        //HttpClient httpClient

        public ExerciseService()
        {
            //this.httpClient = new HttpClient();
        }
        public async Task<List<Exercise>> GetExercise()
        {
            if(exerciseList.Count > 0) 
            return exerciseList;

            /*var response = await httpClient.GetAsync("URL.json");
             * if (response.IsSuccessStatusCode) 
             * {
             *      exerciseList = await response.Content.ReadFromJsonAsync<List<Exercise>>();
             * }
             */ 
            //Open JSON file from the app package
             using var stream = await FileSystem.OpenAppPackageFileAsync("exercisedata.json");
             using var reader = new StreamReader(stream);

            //Read contents of file
            var contents = await reader.ReadToEndAsync();

            //Deserializing of JSON to list of Exercise object
            exerciseList = JsonSerializer.Deserialize<List<Exercise>>(contents, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return exerciseList;
            
        }
    }
}
