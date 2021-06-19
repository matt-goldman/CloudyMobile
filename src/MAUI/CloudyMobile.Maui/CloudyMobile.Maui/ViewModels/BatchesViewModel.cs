using CloudyMobile.Maui.Services.Concretions;

namespace CloudyMobile.Maui.ViewModels
{
    public class BatchesViewModel : BaseViewModel
    {
        private readonly BatchService service;

        public BatchesViewModel(BatchService service)
        {
            this.service = service;
        }
    }
}
