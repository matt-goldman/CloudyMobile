using CloudyMobile.Maui.Services;

namespace CloudyMobile.Maui.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        private readonly RecipeService service;

        public RecipesViewModel(RecipeService service)
        {
            this.service = service;
        }
    }
}
