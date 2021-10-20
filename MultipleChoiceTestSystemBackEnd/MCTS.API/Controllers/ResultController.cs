using AutoMapper;
using MCTS.API.Objects.Mappers.Dtos;
using MCTS.API.Services.Abstract;
using MCTS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MCTS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService resultService;
        private readonly IMapper mapper;

        public ResultController(IResultService resultService, IMapper mapper)
        {
            this.resultService = resultService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddResult([FromBody] ResultCreateDTO resultCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await resultService.AddResultAsync(mapper.Map<Result>(resultCreateDTO));
                var resultDTO = mapper.Map<ResultDTO>(result);
                return Ok(resultDTO);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResult([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var result = await resultService.GetResultAsync(id);
                var resultDTO = mapper.Map<ResultDTO>(result);
                return Ok(resultDTO);
            }
            return BadRequest();
        }
    }
}
