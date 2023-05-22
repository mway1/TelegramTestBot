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
    private List<AnswerModel> _answersForEditQuest = new List<AnswerModel>();

    public TestService()
    {

    }

    public TestModel CreateTest(string nameOfTest,int teacherId)
    {
        TestModel test = new TestModel()
        {
            Name = nameOfTest,
            TeacherId = teacherId
        };
       _testmodelManager.AddTest(test);
        return test;
    }
    public void CreateQuestion(int testId,string contentQuestion)
    {
        List<QuestionModel> questions = new List<QuestionModel>();
        questions.Add(new QuestionModel { Content = contentQuestion});
        foreach (var question in questions)
        {
            question.TestId=testId;
           _questionModelManager.AddQuestion(question);
        }
    }
    
    public void CreateAnswer(int testId,string content1Answer, string content2Answer, string content3Answer, string content4Answer,bool firstRB,bool secondRB,bool thirdRB,bool fourthRB)
    {
        int questionId = _questionModelManager.GetLastQuestionAdded(testId);
        List<AnswerModel> _allAnswer = new List<AnswerModel>();
        if (firstRB == true)
        {
            _allAnswer.Add(new AnswerModel { Content = content1Answer, IsCorrect = true });
            _allAnswer.Add(new AnswerModel { Content = content2Answer });
            _allAnswer.Add(new AnswerModel { Content = content3Answer });
            _allAnswer.Add(new AnswerModel { Content = content4Answer });
        }
        else if (secondRB == true)
        {
            _allAnswer.Add(new AnswerModel { Content = content1Answer });
            _allAnswer.Add(new AnswerModel { Content = content2Answer, IsCorrect = true });
            _allAnswer.Add(new AnswerModel { Content = content3Answer });
            _allAnswer.Add(new AnswerModel { Content = content4Answer });
        }
        else if (thirdRB == true)
        {
            _allAnswer.Add(new AnswerModel { Content = content1Answer });
            _allAnswer.Add(new AnswerModel { Content = content2Answer });
            _allAnswer.Add(new AnswerModel { Content = content3Answer, IsCorrect = true });
            _allAnswer.Add(new AnswerModel { Content = content4Answer });
        }
        else if (fourthRB == true)
        {
            _allAnswer.Add(new AnswerModel { Content = content1Answer });
            _allAnswer.Add(new AnswerModel { Content = content2Answer });
            _allAnswer.Add(new AnswerModel { Content = content3Answer });
            _allAnswer.Add(new AnswerModel { Content = content4Answer, IsCorrect = true });
        }
        List<AnswerModel> answers = _allAnswer;

        foreach (var answer in answers)
        {
            answer.QuestionId = questionId;
            _answerModelManager.AddAnswer(answer);
        }
    }

    public void EditQuestion(int questionId,int testId,string contentQuestion)
    {
        List<QuestionModel> questions = new List<QuestionModel>();
        questions.Add(new QuestionModel { Content = contentQuestion });
        foreach (var question in questions)
        {
            question.Id = questionId;
            question.TestId = testId;
            _questionModelManager.UpdateQuestionById(question);
        }
    }
    public void EditAnswer(int questionId, string content1Answer, string content2Answer, string content3Answer, string content4Answer, bool firstRB, bool secondRB, bool thirdRB, bool fourthRB)
    {
        _answersForEditQuest = _answerModelManager.GetAnswerByQuestionId(questionId);
        if (firstRB == true)
        {
            _answersForEditQuest[0].IsCorrect = true;
            _answersForEditQuest[1].IsCorrect = false;
            _answersForEditQuest[2].IsCorrect = false;
            _answersForEditQuest[3].IsCorrect = false;
            _answersForEditQuest[0].Content = content1Answer;
            _answersForEditQuest[1].Content = content2Answer;
            _answersForEditQuest[2].Content = content3Answer;
            _answersForEditQuest[3].Content = content4Answer;
        }
        else if (secondRB == true)
        {
            _answersForEditQuest[0].IsCorrect = false;
            _answersForEditQuest[1].IsCorrect = true;
            _answersForEditQuest[2].IsCorrect = false;
            _answersForEditQuest[3].IsCorrect = false;
            _answersForEditQuest[0].Content = content1Answer;
            _answersForEditQuest[1].Content = content2Answer;
            _answersForEditQuest[2].Content = content3Answer;
            _answersForEditQuest[3].Content = content4Answer;
        }
        else if (thirdRB == true)
        {
            _answersForEditQuest[0].IsCorrect = false;
            _answersForEditQuest[1].IsCorrect = false;
            _answersForEditQuest[2].IsCorrect = true;
            _answersForEditQuest[3].IsCorrect = false;
            _answersForEditQuest[0].Content = content1Answer;
            _answersForEditQuest[1].Content = content2Answer;
            _answersForEditQuest[2].Content = content3Answer;
            _answersForEditQuest[3].Content = content4Answer;
        }
        else if (fourthRB == true)
        {
            _answersForEditQuest[0].IsCorrect = false;
            _answersForEditQuest[1].IsCorrect = false;
            _answersForEditQuest[2].IsCorrect = false;
            _answersForEditQuest[3].IsCorrect = true;
            _answersForEditQuest[0].Content = content1Answer;
            _answersForEditQuest[1].Content = content2Answer;
            _answersForEditQuest[2].Content = content3Answer;
            _answersForEditQuest[3].Content = content4Answer;
        }
        List<AnswerModel> answers = _answersForEditQuest;
        foreach (var answer in answers)
        {
        _answerModelManager.UpdateAnswerById(new AnswerModel { Id = answer.Id, QuestionId = questionId, Content = answer.Content,IsCorrect=answer.IsCorrect});
        }
    }


}
