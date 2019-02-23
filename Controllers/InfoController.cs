using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Plant.API.data;

namespace Plant.API.Controllers
{
    [Authorize]
    [Route ("info/[controller]")]
    [ApiController]
    public class InfoController
    {
        public IinfoRepository Repository { get; }
        public IConfiguration Config { get; }
        public InfoController(IinfoRepository repository, IConfiguration config)
        {
            Repository = repository;
            Config = config;
        }
        [HttpGet("infos")]
        public async Task<IActionResult> Get() {
            
            var info = await this.Repository.getInfos();
            return null;
        }
        
    }
}
