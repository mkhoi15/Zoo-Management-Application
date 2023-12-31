﻿using Entities.Models;
using ServiceContracts.DTO.SkillDTO;
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.DTO.UserDTO
{
    /// <summary>
    /// Represents DTO class that is used as return type of most methods of User service
    /// </summary>
    public class UserResponse
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "UserName Can not be blank!")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email can not be blank!")]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string? Email { get; set; }

        public string? FullName { get; set; }

        [Required(ErrorMessage = "Phone number can not be blank!")]
        [Phone(ErrorMessage = "Invalid phone number!")]
        [StringLength(12)]
        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Date of birth can not be blank!")]
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public List<SkillResponse> skills { get; set; } = new List<SkillResponse>();
    }

    public static class UserExtension
    {
        /// <summary>
        /// A method to Convert User To UserResponse
        /// </summary>
        /// <param name="user">User to convert</param>
        /// <returns>UserResponse object base on the user</returns>
        public static UserResponse ToUserResponse(this User user)
        {
            return new UserResponse()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId,
                Role = user.Role,
                Gender = user.Gender,
                skills = user.Skills.Select(s => s.ToSkillResponse()).ToList()
            };
        }
    }
}