﻿namespace TelegramTestBot.DAL.DTOs
{
    public class TestingDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int TestId { get; set; }
        public TestDTO Test { get; set; }

        public TestingDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is TestingDTO))
            {
                flag = false;
            }

            TestingDTO testingDTO = (TestingDTO)obj!;

            if (testingDTO.Id != this.Id ||
                testingDTO.Date != this.Date ||
                testingDTO.Test!.Id != this.Test!.Id)
            {
                flag = false;
            }

            return flag;
        }
    }
}
