using DevHops.Maui.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        private readonly IRecipeService recipeService;

        public RecipeViewModel(IRecipeService recipeService)        {
            this.recipeService = recipeService;
        }
    }
}
