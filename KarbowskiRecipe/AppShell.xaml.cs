using KarbowskiRecipe.View;

namespace KarbowskiRecipe
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(LikedRecipesPage), typeof(LikedRecipesPage));
        }
    }
}
