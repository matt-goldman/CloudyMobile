using CloudyMobile.Maui.Services.Abstractions;

namespace CloudyMobile.Maui.ViewModels
{
    public class BatchesViewModel : BaseViewModel
    {
        private readonly IBatchService service;

        public BatchesViewModel(IBatchService service)
        {
            this.service = service;
        }
    }
}
