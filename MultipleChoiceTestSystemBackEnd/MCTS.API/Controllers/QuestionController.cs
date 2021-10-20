using AutoMapper;
using MCTS.API.Objects.Mappers.Dtos;
using MCTS.API.Services.Abstract;
using MCTS.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCTS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await questionService.GetAllQuestionsAsync();
            var questionDTOs = mapper.Map<List<QuestionDTO>>(questions);
            return Ok(questionDTOs); ;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewQuestion([FromBody] QuestionCreateDTO questionCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var newQuestion = mapper.Map<Question>(questionCreateDTO);
                var addedQuestion = await questionService.AddNewQuestionAsync(newQuestion);
                var questionDTO = mapper.Map<QuestionDTO>(addedQuestion);

                if (addedQuestion != null)
                {
                    return CreatedAtAction("AddNewQuestion", questionDTO);
                }
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            var questions = await questionService.GetQuestionsForTestAsync();
            if (questions != null)
            {
                var questionDTOs = mapper.Map<List<QuestionDTO>>(questions);
                questionDTOs.ForEach(x =>
                {
                    x.Options.Add(new OptionDTO() { OptionText = x.RightAnswer, QuestionID = x.ID });
                    x.Options = x.Options.OrderBy(x => Guid.NewGuid()).ToList();
                });
                return Ok(questionDTOs);
            }
            return NoContent();
        }
    }
}
