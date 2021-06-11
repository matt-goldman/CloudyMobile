using CloudyMobile.Maui.Services;

namespace CloudyMobile.Maui.ViewModels
{
    public class BatchesViewModel : BaseViewModel
    {
        private readonly BatchesService service;

        public BatchesViewModel(BatchesService service)
        {
            this.service = service;
        }
    }
}
