using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace perf_test02.Controllers
{
    public class ThreadTestApiController : ApiController
    {
        [HttpGet]
        [Route("api/threadtest/perform/{sleepTimer}")]
        public int Perform(int sleepTimer)
        {
            Thread.Sleep(sleepTimer);
            return 1;
        }

        [HttpGet]
        [Route("api/threadtest/performasync/{sleepTimer}")]
        public async Task<int> PerformAsync(int sleepTimer)
        {
            await Task.Delay(sleepTimer);
            return 1;
        }

        [HttpGet]
        [Route("api/threadtest/CreateThreads/{count}")]
        public IHttpActionResult CreateThreads(int count)
        {
            var cnt = 0;
            for (int i = 0; i < count; i++)
            {
                Task.Run(() =>
                {
                    cnt++;
                    Thread.Sleep(10000);
                });
            }
            return Ok($"Cnt set to : {cnt}");
        }
    }
}