using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarbowskiRecipe.Model
{
    /// <summary>
    /// The recipe class.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image of the recipe.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the description of the recipe.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the time of the recipe.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the list of ingredients for the recipe.
        /// </summary>
        public List<string> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the directions of the recipe.
        /// </summary>
        public List<string> Directions { get; set; }
    }
}
