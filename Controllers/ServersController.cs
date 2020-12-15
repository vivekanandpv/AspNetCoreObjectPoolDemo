using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreObjectPoolDemo.Models;
using Microsoft.Extensions.ObjectPool;

namespace AspNetCoreObjectPoolDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly ObjectPool<AppConfig> _appConfigObjectPool;

        public ServersController(ObjectPool<AppConfig> appConfigObjectPool)
        {
            _appConfigObjectPool = appConfigObjectPool;
        }

        public ActionResult<ServerViewModel> Get()
        {
            var config = _appConfigObjectPool.Get();

            var viewModel = new ServerViewModel
            {
                Name = config.Name,
                Threshold = config.Threshold,
                Load = config.Load,
                Connections = config.Connections,
                BlockId = config.BlockId,
                Id = config.BlockId + 3
            };

            _appConfigObjectPool.Return(config);

            return Ok(viewModel);
        }

        [HttpGet("{id:int}")]
        public ActionResult<AppConfig> Get(int id)
        {
            var config = _appConfigObjectPool.Get();

            var viewModel = new ServerViewModel
            {
                Name = config.Name,
                Threshold = config.Threshold,
                Load = config.Load,
                Connections = config.Connections,
                BlockId = config.BlockId,
                Id = id
            };

            _appConfigObjectPool.Return(config);

            return Ok(viewModel);
        }
    }
}
