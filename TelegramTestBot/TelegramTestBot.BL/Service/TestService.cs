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
    private readonly ITestModelManager _testmodelManager;
    private readonly IQuestionModelManager _questionModelManager;
    private readonly IAnswerModelManager _answerModelManager;

    public TestService(ITestModelManager testmodelManager, IQuestionModelManager questionModelManager, IAnswerModelManager answerModelManager)
    {
        _testmodelManager = testmodelManager;
        _questionModelManager = questionModelManager;
        _answerModelManager = answerModelManager;
    }

    public TestModel CreateTest(string name,int teacherId,List<QuestionModel> questions)
    {
        var test = new TestModel { Name = name, TeacherId = teacherId };
        _testmodelManager.AddTest(test);

        foreach(var question in questions)
        {
            question.TestId = test.Id;
            _questionModelManager.AddQuestion(question);
        }
        return test;

    }
    
    

    public QuestionModel CreaateQuestion(string text, List<AnswerModel> answers,bool isCorrectAnswer)
    {
        var question=new QuestionModel { Content = text };
        _questionModelManager.AddQuestion(question);

        foreach (var answer in answers)
        {
            answer.Content = text;
            answer.QuestionId = question.Id;
            answer.IsCorrect=isCorrectAnswer;
            _answerModelManager.AddAnswer(answer);
        }
        return question;
    }

}
