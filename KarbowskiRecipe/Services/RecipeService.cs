using KarbowskiRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KarbowskiRecipe.Services
{
    /// <summary>
    /// The recipe service class to get a connection for recipes.
    /// </summary>
    public class RecipeService
    {
        HttpClient httpClient;

        /// <summary>
        /// The recipe service constructor.
        /// </summary>
        public RecipeService()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Creating a list of recipes.
        /// </summary>
        List<Recipe> recipeList = new List<Recipe>();

        /// <summary>
        /// Getting a connection to where the recipes are being stored.
        /// </summary>
        /// <returns>The recipes.</returns>
        public async Task<List<Recipe>> GetRecipes()
        {
            if (recipeList.Count > 0)
            {
                return recipeList;
            }

            var url = "https://raw.githubusercontent.com/BrettKarbowski/Recipe/refs/heads/main/recipe.json";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                recipeList = await response.Content.ReadFromJsonAsync<List<Recipe>>();
            }

            return recipeList;
        }
    }
}
