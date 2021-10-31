using CloudyMobile.Client;
using DevHops.Maui.Services.Abstractions;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevHops.Maui.ViewModels
{
    public class AddSampleViewModel : BaseViewModel
    {
        public AddSampleViewModel(IBatchService batchService)
        {
            BatchService = batchService;
            AddSampleCommand = new Command(async () => await AddSample());
        }

        public IBatchService BatchService { get; }

        public ICommand AddSampleCommand { get; set; }

        public int BatchId { get; set; }
        public float Gravity { get; set; }
        public long Temp { get; set; }

        public async Task AddSample()
        {
            await BatchService.SampleBatch(new SampleDto
            {
                BatchId = BatchId,
                Gravity = Gravity,
                SampleDate = DateTime.Now,
                Temperature = Temp,
            });
        }
    }
}
