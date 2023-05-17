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
    
    public QuestionModel CreateQuestion(string text)
    {
        var question=new QuestionModel { Content = text };
        _questionModelManager.AddQuestion(question);

        //foreach (var answer in answers)
        //{
        //    answer.QuestionId = question.Id;
        //    answer.IsCorrect=isCorrectAnswer;
        //    _answerModelManager.AddAnswer(answer);
        //}
        return question;
    }

    public void CreateAnswer(string text,bool isCorrectAnswer ,List<AnswerModel> answers)
    {
        foreach (var answer in answers)
        {
            answer.Content = text;
            answer.IsCorrect = isCorrectAnswer;
            _answerModelManager.AddAnswer(answer);
        }
    }



}
