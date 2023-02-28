namespace TelegramTestBot.DAL.DTOs
{
    public class TypeOfQuestionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeOfQuestionDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TypeOfQuestionDTO))
            {
                flag = false;
            }

            TypeOfQuestionDTO typeOfQuestionDTO = (TypeOfQuestionDTO)obj!;

            if (typeOfQuestionDTO.Id != this.Id ||
                typeOfQuestionDTO.Name != this.Name)            
            {
                flag = false;
            }

            return flag;
        }
    }
}
