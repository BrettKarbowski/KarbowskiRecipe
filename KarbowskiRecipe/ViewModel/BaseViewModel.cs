using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarbowskiRecipe.ViewModel
{
    /// <summary>
    /// Some basics for the view models.
    /// </summary>
    public partial class BaseViewModel : ObservableObject
    { 
        /// <summary>
        /// Base view model constructor.
        /// </summary>
        public BaseViewModel()
        {
        }

        /// <summary>
        /// Checking if the program is active.
        /// </summary>
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        private bool isBusy;

        /// <summary>
        /// The title of the current model.
        /// </summary>
        [ObservableProperty]
        private string title;

        /// <summary>
        /// Setting to the opposite of isBusy.
        /// </summary>
        public bool IsNotBusy => !isBusy;
    }
}
