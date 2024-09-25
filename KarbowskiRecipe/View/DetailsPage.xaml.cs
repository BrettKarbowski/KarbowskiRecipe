using KarbowskiRecipe.ViewModel;

namespace KarbowskiRecipe.View;

/// <summary>
/// The Recipe details page.
/// </summary>
public partial class DetailsPage : ContentPage
{
	/// <summary>
	/// The recipe details page constructor.
	/// </summary>
	/// <param name="viewModel"></param>
	public DetailsPage(RecipeDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	/// <summary>
	/// Creating navigations for the details page.
	/// </summary>
	/// <param name="args">The event arguments.</param>
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}