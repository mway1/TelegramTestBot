namespace TelegramTestBot.DAL
{
    public class StoredProcedures
    {
        public const string Answer_Add = "Answer_Add";
        public const string Answer_DeleteById = "Answer_DeleteById";
        public const string Answer_GetAll = "Answer_GetAll";
        public const string Answer_GetById = "Answer_GetById";
        public const string Answer_GetByQuestionId = "Answer_GetByQuestionId";
        public const string Answer_UpdateById = "Answer_UpdateById";

        public const string Group_Add = "Group_Add";
        public const string Group_DeleteById = "Group_DeleteById";
        public const string Group_GetAll = "Group_GetAll";
        public const string Group_GetById = "Group_GetById";
        public const string Group_GetByEnteredText = "Group_GetByEnteredText";
        public const string Group_UpdateById = "Group_UpdateById";

        public const string Question_Add = "Question_Add";
        public const string Question_DeleteById = "Question_DeleteById";
        public const string Question_GetAll = "Question_GetAll";
        public const string Question_GetById = "Question_GetById";
        public const string Question_GetByTestId = "Question_GetByTestId";
        public const string Question_GetLastAdded = "Question_GetLastAdded";
        public const string Question_UpdateById = "Question_UpdateById";

        public const string Student_Add = "Student_Add";
        public const string Student_DeleteById = "Student_DeleteById";
        public const string Student_GetAll = "Student_GetAll";
        public const string Student_GetById = "Student_GetById";
        public const string Student_GetByGroupId = "Student_GetByGroupId";
        public const string Student_GetByChatId = "Student_GetByChatId";
        public const string Student_GetStudentsByGroupId = "Student_GetStudentsByGroupId";
        public const string Student_UpdateById = "Student_UpdateById";

        public const string Teacher_Add = "Teacher_Add";
        public const string Teacher_DeleteById = "Teacher_DeleteById";
        public const string Teacher_GetAll = "Teacher_GetAll";
        public const string Teacher_GetById = "Teacher_GetById";
        public const string Teacher_GetByLogin = "Teacher_GetByLogin";
        public const string Teacher_UpdateById = "Teacher_UpdateById";

        public const string Test_Add = "Test_Add";
        public const string Test_DeleteById = "Test_DeleteById";
        public const string Test_GetAll = "Test_GetAll";
        public const string Test_GetById = "Test_GetById";
        public const string Test_GetLastAdded = "Test_GetLastAdded";
        public const string Test_GetByTeacherId = "Test_GetByTeacherId";
        public const string Test_UpdateById = "Test_UpdateById";

        public const string Testing_Add = "Testing_Add";
        public const string Testing_DeleteById = "Testing_DeleteById";
        public const string Testing_GetAll = "Testing_GetAll";
        public const string Testing_GetById = "Testing_GetById";
        public const string Testing_UpdateById = "Testing_UpdateById";

        public const string Testing_Student_Add = "Testing_Student_Add";
        public const string Testing_Student_DeleteById = "Testing_Student_DeleteById";
        public const string Testing_Student_GetAll = "Testing_Student_GetAll";
        public const string Testing_Student_GetById = "Testing_Student_GetById";
        public const string Testing_Student_UpdateById = "Testing_Student_UpdateById";

        public const string TelegramBot_Add = "TelegramBot_Add";
        public const string TelegramBot_DeleteById = "TelegramBot_DeleteById";
        public const string TelegramBot_GetById = "TelegramBot_GetById";
    }
}