using DevHops.Maui.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.ViewModels
{
    public class BatchesViewModel : BaseViewModel
    {
        private readonly IBatchService batchService;

        public BatchesViewModel(IBatchService batchService)
        {
            this.batchService = batchService;
        }
    }
}
