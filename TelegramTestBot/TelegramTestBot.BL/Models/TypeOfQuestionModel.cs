namespace TelegramTestBot.BL.Models
{
    public class TypeOfQuestionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeOfQuestionModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TypeOfQuestionModel))
            {
                flag = false;
            }
            else
            {
                TypeOfQuestionModel typeOfQuestionDTO = (TypeOfQuestionModel)obj!;

                if (typeOfQuestionDTO.Id != this.Id ||
                    typeOfQuestionDTO.Name != this.Name)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
