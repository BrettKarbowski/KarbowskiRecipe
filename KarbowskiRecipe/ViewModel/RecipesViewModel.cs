using KarbowskiRecipe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarbowskiRecipe.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using KarbowskiRecipe.View;
using CommunityToolkit.Mvvm.ComponentModel;

namespace KarbowskiRecipe.ViewModel
{
    /// <summary>
    /// The recipes view model.
    /// </summary>
    public partial class RecipesViewModel : BaseViewModel
    {
        /// <summary>
        /// The recipe service to get my recipes.
        /// </summary>
        RecipeService recipeService;

        /// <summary>
        /// Creating a list of recipes to store.
        /// </summary>
        public ObservableCollection<Recipe> Recipes { get; } = new ();

        /// <summary>
        /// Creating a list of saved recipes to store.
        /// </summary>
        public ObservableCollection<Recipe> SavedRecipes { get; } = new();

        /// <summary>
        /// The recipes view model constructor.
        /// </summary>
        /// <param name="recipeService">Where my recipes are being kept.</param>
        public RecipesViewModel(RecipeService recipeService)
        {
            Title = "Recipe";
            this.recipeService = recipeService;
        }

        /// <summary>
        /// The button task to see the details on a recipe.
        /// </summary>
        /// <param name="recipe">The recipe that was clicked.</param>
        /// <returns>The recipe details page for the recipe clicked.</returns>
        [ICommand]
        async Task GoToDetailsAsync(Recipe recipe)
        {
            if(recipe is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, new Dictionary<string, object>
            {
                {"Recipe", recipe}
            });
        }

        /// <summary>
        /// The task for when the button is clicked to go to the liked recipe page.
        /// </summary>
        /// <returns>The liked recipe page.</returns>
        [ICommand]
        async Task GoToLikedRecipesAsync()
        {
            await Shell.Current.GoToAsync(nameof(LikedRecipesPage));
        }

        // booling for checking if page is refreshing
        [ObservableProperty]
        bool isRefreshing;

        /// <summary>
        /// Checking to see if connection was made for getting recipes.
        /// </summary>
        /// <returns>Returns the recipes.</returns>
        [ICommand]
        async Task GetRecipesAsync()
        {
            if(IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var recipes = await recipeService.GetRecipes();
                var random = new Random();
                var shuffledRecipes = recipes.OrderBy(x => random.Next()).ToList();

                if (Recipes.Count != 0 )
                {
                    Recipes.Clear();
                }

                // Going through the recipe list and shuffling it, displaying 15 at a time.
                foreach(var recipe in shuffledRecipes.Take(15))
                {
                    Recipes.Add(recipe);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get recipes: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        /// <summary>
        /// The command to save a recipe and alert the user that it was saved, or to tell the user that they already saved it..
        /// </summary>
        /// <param name="recipe">The recipe being saved.</param>
        /// <returns>A saved recipe with a message.</returns>
        [ICommand]
        async Task SaveRecipeAsync(Recipe recipe)
        {
            if (recipe is null)
                return;

            if (!SavedRecipes.Contains(recipe))
            {
                SavedRecipes.Add(recipe);
                Debug.WriteLine($"Saved recipe: {recipe.Name}");
                await Shell.Current.DisplayAlert("Saved", $"Recipe '{recipe.Name}' saved!", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Already Saved", $"Recipe '{recipe.Name}' is already saved.", "OK");
            }
        }

        /// <summary>
        /// The command to remove a liked recipe.
        /// </summary>
        /// <param name="recipe">The recipe to be removed.</param>
        /// <returns>A deleted liked recipe, and a message.</returns>
        [ICommand]
        async Task RemoveLikedRecipeAsync(Recipe recipe)
        {
            if (recipe is null)
                return;

            SavedRecipes.Remove(recipe);
            await Shell.Current.DisplayAlert("Removed", $"Recipe '{recipe.Name}' has been removed from liked recipes.", "OK");
        }

    }
}
