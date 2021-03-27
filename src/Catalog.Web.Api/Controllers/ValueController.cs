using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Value.Web.Api.Models;
using Microservice.Value.Web.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservice.Value.Web.Api.Controllers
{
    [ApiController]
    [Route("api/value")]
    public class ValueController : ControllerBase
    {
        private readonly IValueService _valueService;
        private readonly ILogger<ValueController> _logger;

        public ValueController(
            IValueService valueService,
            ILogger<ValueController> logger)
        {
            _valueService = valueService;
            _logger = logger;
        }

        [HttpGet(Name = nameof(GetValues))]
        [ProducesResponseType(typeof(PagedResultDto<ResponseValueDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResultDto<ResponseValueDto>>> GetValues([FromQuery] RequestSearchTermValueDto searchRequest)
        {
            var valueResult = await _valueService.GetAsync(searchRequest);

            return Ok(valueResult);
        }

        [HttpGet("{id}", Name = nameof(GetValueById))]
        [ProducesResponseType(typeof(ResponseValueDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseValueDto>> GetValueById([FromRoute] Guid id)
        {
            var valueResult = await _valueService.GetByIdAsync(id);

            if (valueResult == null)
            {
                return NotFound(id);
            }

            return Ok(valueResult);
        }

        [HttpPost(Name = nameof(PostValue))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostValue([FromBody] RequestCreateValueDto createValue)
        {
            try
            {
                var createValueResult = await _valueService.AddAsync(createValue);

                return CreatedAtAction(nameof(GetValueById), new { id = createValueResult.Id }, createValueResult);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        [HttpPut("{id}", Name = nameof(UpdateValue))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateValue([FromRoute] Guid id, [FromBody] RequestUpdateValueDto updateValue)
        {
            try
            {
                var updateValueResult = await _valueService.UpdateAsync(id, updateValue);

                if (updateValueResult == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = nameof(DeleteValue))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteValue([FromRoute] Guid id)
        {
            try
            {
                var deleteValueResult = await _valueService.DeleteAsync(id);

                if (!deleteValueResult.HasValue)
                {
                    return NotFound(id);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }
    }
}
