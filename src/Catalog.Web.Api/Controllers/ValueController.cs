using System;
using System.Collections.Generic;
using Microservice.Value.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservice.Value.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;

        public ValueController(ILogger<ValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ResponseValueModel> Get()
        {
            var catalogs = new List<ResponseValueModel>();

            for (int i = 0; i < 10; i++)
            {
                var catalog = new ResponseValueModel()
                {
                    Id = Guid.NewGuid(),
                    Name = i.ToString(),
                    CreatedAt = DateTime.UtcNow
                };

                catalogs.Add(catalog);
            }

            return catalogs;
        }
    }
}
