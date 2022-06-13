using AutoMapper;
using JNVAdmin.API.ViewModels.Snack;
using JNVAdmin.Application.Dtos;
using JNVAdmin.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JNVAdmin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnacksController : ControllerBase
    {
        private readonly ISnackService _snackService;
        private readonly IMapper _mapper;

        public SnacksController(ISnackService snackService, IMapper mapper)
        {
            _snackService = snackService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SnackDTO>>> Get()
        {
            var snacks = await _snackService.GetSnacksAsync();
            if (snacks == null)
            {
                return NotFound("Snacks not found");
            }
            return Ok(snacks);
        }

        [HttpGet("{id:guid}", Name = "GetSnack")]
        public async Task<ActionResult<SnackDTO>> Get(Guid id)
        {
            var snack = await _snackService.GetByIdAsync(id);
            if (snack == null)
            {
                return NotFound("Snack not found");
            }
            return Ok(snack);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SnackCreate snackCreate)
        {
            if (snackCreate == null)
                return BadRequest("Invalid Data");

            var snack = await _snackService.AddAsync(_mapper.Map<SnackDTO>(snackCreate));

            return Ok(snack);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guid id, [FromBody] SnackUpdate snackUpdate)
        {
            var snack = _mapper.Map<SnackDTO>(snackUpdate);

            await _snackService.UpdateAsync(id, snack);

            return Ok(snackUpdate);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SnackDTO>> Delete(Guid id)
        {
            var snack = await _snackService.GetByIdAsync(id);
            if (snack == null)
            {
                return NotFound("Snack not found");
            }

            await _snackService.RemoveAsync(id);

            return Ok(snack);

        }
    }
}
