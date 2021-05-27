using CloudyMobile.Application.Batch.Commands.AddBatch;
using CloudyMobile.Application.Batch.Commands.AddBatchSample;
using CloudyMobile.Application.Batch.Common;
using CloudyMobile.Application.Batch.Queries.GetAll;
using CloudyMobile.Application.Batch.Queries.GetBatch;
using CloudyMobile.Application.Batch.Queries.Search;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudyMobile.API.Controllers
{
    public class BatchesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]BatchDto batch)
        {
            return await Mediator.Send(new AddBatchCommand { Batch = batch } );
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Sample (SampleDto sample)
        {
            return await Mediator.Send(new AddBatchSampleCommand { Sample = sample });
        }

        [HttpGet]
        public async Task<ActionResult<BatchListVm>> Get()
        {
            return await Mediator.Send(new GetAllBatchQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchDto>> Get(int id)
        {
            return await Mediator.Send(new GetBatchQuery { Id = id });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BatchListVm>> Search(SearchBatchQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
