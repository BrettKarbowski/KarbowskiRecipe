using KarbowskiRecipe.ViewModel;

namespace KarbowskiRecipe.View;

/// <summary>
/// The liked recipes page
/// </summary>
public partial class LikedRecipesPage : ContentPage
{
	/// <summary>
	/// The liked recipes constructor.
	/// </summary>
	/// <param name="viewModel">Utilizes the recipe view model.</param>
	public LikedRecipesPage(RecipesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	/// <summary>
	/// Creating navigation to the liked recipes page.
	/// </summary>
	/// <param name="args">The event arguments.</param>
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}