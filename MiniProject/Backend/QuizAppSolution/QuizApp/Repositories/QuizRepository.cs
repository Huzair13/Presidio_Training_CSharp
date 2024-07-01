﻿using Microsoft.EntityFrameworkCore;
using QuizApp.Contexts;
using QuizApp.Exceptions;
using QuizApp.Interfaces;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuizRepository : IRepository<int, Quiz>
    {
        private readonly QuizAppContext _context; 

        public QuizRepository(QuizAppContext context)
        {
            _context = context;
        }

        public async Task<Quiz> Add(Quiz item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Quiz> Delete(int quizId)
        {
            var quiz = await Get(quizId);
            _context.Remove(quiz);
            await _context.SaveChangesAsync(true);
            return quiz;
        }

        public async Task<Quiz> Get(int quizId)
        {
            var quiz = await _context.Quizzes.Include(q => q.QuizQuestions).ThenInclude(qq => qq.Question)
                                    .FirstOrDefaultAsync(q => q.Id == quizId);
            if (quiz != null)
            {
                return quiz;
            }
            throw new NoSuchQuizException(quizId);
        }

        public async Task<IEnumerable<Quiz>> Get()
        {
            var quizzes = await _context.Quizzes.Include(q=>q.QuizQuestions).ThenInclude(qq=>qq.Question).ToListAsync();
            if (quizzes.Count != 0)
            {
                return quizzes;
            }
            throw new NoSuchQuizException();
        }

        public async Task<Quiz> Update(Quiz quiz)
        {
            var existingQuiz = await Get(quiz.Id);
            _context.Update(quiz);
            await _context.SaveChangesAsync();
            return existingQuiz;
        }
    }
}
