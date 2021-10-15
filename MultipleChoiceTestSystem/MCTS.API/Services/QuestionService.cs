using MCTS.API.Services.ServiceAbstractions;
using MCTS.Core.Models;
using MCTS.Core.RepositoryAbstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCTS.API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Question> AddNewQuestionAsync(Question question)
        {
            var addedQuestion = await unitOfWork.Questions.AddNewQuestionAsync(question);
            await unitOfWork.SaveAsync();
            return await unitOfWork.Questions.GetSingleQuestionAsync(addedQuestion.ID);
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await unitOfWork.Questions.GetAllQuestionsAsync();
        }

        public async Task<List<Question>> GetQuestionsForTestAsync()
        {
            return await unitOfWork.Questions.GetRandomQuestionsForTestAsync();
        }

        public async Task<Question> GetSingleQuestionAsync(Guid id)
        {
            return await unitOfWork.Questions.GetSingleQuestionAsync(id);
        }

    }
}
