using KarbowskiRecipe.ViewModel;

namespace KarbowskiRecipe
{
    /// <summary>
    /// The main page.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The main page's constructor. Utilizing the Recipes view model.
        /// </summary>
        /// <param name="viewModel">the view model.</param>
        public MainPage(RecipesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
