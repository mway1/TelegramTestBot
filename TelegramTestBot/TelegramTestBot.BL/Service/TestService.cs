using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramTestBot.BL.Interfaces;
using TelegramTestBot.BL.Managers;
using TelegramTestBot.BL.Models;

namespace TelegramTestBot.BL.Service;

public class TestService
{
    private TestModelManager _testmodelManager = new TestModelManager();
    private QuestionModelManager _questionModelManager = new QuestionModelManager();
    private AnswerModelManager _answerModelManager = new AnswerModelManager();

    public TestService()
    {

    }

    public void CreateQuestion(int testId,List<QuestionModel> questions)
    {
        foreach (var question in questions)
        {
            question.TestId = testId;
            _questionModelManager.AddQuestion(question);
        }
    }
    
    public void CreateAnswer(int testId,List<AnswerModel> answers)
    {
        int questionId = _questionModelManager.GetLastQuestionAdded(testId);

        foreach (var answer in answers)
        {
            answer.QuestionId = questionId;
            _answerModelManager.AddAnswer(answer);
        }
    }

    public void EditQuestion(int questionId,int testId, List<QuestionModel> questions)
    {
        foreach (var question in questions)
        {
            question.Id = questionId;
            question.TestId = testId;
            _questionModelManager.UpdateQuestionById(question);
        }
    }
    public void EditAnswer(int questionId,List<AnswerModel> answers)
    {
        //int questionId = _questionModelManager.GetLastQuestionAdded(testId);

        foreach (var answer in answers)
        {
            answer.QuestionId = questionId;
            _answerModelManager.UpdateAnswerById(answer);
        }
    }


}
