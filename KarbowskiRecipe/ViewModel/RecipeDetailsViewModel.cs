using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KarbowskiRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarbowskiRecipe.ViewModel
{
    /// <summary>
    /// The recipe details view model that inherits from the base model.
    /// </summary>
    [QueryProperty("Recipe", "Recipe")]
    public partial class RecipeDetailsViewModel : BaseViewModel
    {
        /// <summary>
        /// The recipe details constructor.
        /// </summary>
        public RecipeDetailsViewModel()
        {
        }

        /// <summary>
        /// A recipe for the view model.
        /// </summary>
        [ObservableProperty]
        Recipe recipe;
    }
}
