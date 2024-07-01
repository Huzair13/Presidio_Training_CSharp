﻿namespace QuizApp.Models.DTOs.UserDTOs
{
    public class RegisterReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
    }
}
