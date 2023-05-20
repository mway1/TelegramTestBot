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

    public TestModel CreateTest(string name,int teacherId,List<QuestionModel> questions)
    {
        TestModel test = new TestModel() { Name = name, TeacherId = teacherId };
        _testmodelManager.AddTest(test);
        int testId = _testmodelManager.GetLastTestAdded(teacherId);
       
        foreach (var question in questions)
        {
            question.TestId = testId;
            _questionModelManager.AddQuestion(question);
        }

    return test;

    }
    
    public QuestionModel CreateQuestion(string text,int testId,List<AnswerModel> answers)
    {
        var question=new QuestionModel { Content = text };
        _questionModelManager.AddQuestion(question);
        int questionId = _questionModelManager.GetLastQuestionAdded(testId);

        foreach (var answer in answers)
        {
            answer.QuestionId = questionId;
            _answerModelManager.AddAnswer(answer);
        }
        return question;
    }

    public AnswerModel CreateAnswer(string text,bool isCorrect)
    {
        var answer = new AnswerModel { Content = text,IsCorrect=isCorrect};
        _answerModelManager.AddAnswer(answer);
        return answer;

    }



}
