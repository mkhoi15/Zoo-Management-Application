﻿using Entities.Models;
using ServiceContracts.DTO.UserDTO;

namespace ServiceContracts
{
    public interface IUserServices
	{
		/// <summary>
		/// Use to check the login user
		/// </summary>
		/// <param name="userName">The userName to login</param>
		/// <param name="password">The password</param>
		/// <returns>A mitching user or null</returns>
		Task<UserResponse?> LoginUser(string userName, string password);

		/// <summary>
		/// Adding the new User into the User table
		/// </summary>
		/// <param name="userAddRequest">The user to add</param>
		/// <returns>UserResponse object base on the user adding</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		Task<UserResponse> AddUser(UserAddRequest? userAddRequest);

		/// <summary>
		/// Get All the User having ZooTrainer role in User table
		/// </summary>
		/// <returns>A list of User object as UserResponse</returns>
		Task<List<UserResponse>> GetAllZooTrainer();

		/// <summary>
		/// Get All the User having Staff role in User table
		/// </summary>
		/// <returns>A list of User object as UserResponse</returns>
		Task<List<UserResponse>> GetAllStaff();

		/// <summary>
		/// Returns all staff objects that matches with the given 
		/// search field and search string
		/// </summary>
		/// <param name="searchBy">Search field to search</param>
		/// <param name="searchString">Search string to search</param>
		/// <returns>Returns all matching staff base on given search field 
		/// and search string</returns>
		Task<List<UserResponse>> GetFiteredStaff(string searchBy, string? searchString);

		/// <summary>
		/// Returns all zoo trainer objects that matches with the given 
		/// search field and search string
		/// </summary>
		/// <param name="searchBy">Search field to search</param>
		/// <param name="searchString">Search string to search</param>
		/// <returns>Returns all matching zoo trainer base on given search field 
		/// and search string</returns>
		Task<List<UserResponse>> GetFiteredZooTrainer(string searchBy, string? searchString);


		/// <summary>
		/// Get a Staff by Id
		/// </summary>
		/// <param name="staffId">The staff Id to get</param>
		/// <returns>Matching user object as UserResponse type</returns>
		Task<UserResponse?> GetStaffById(long staffId);

		/// <summary>
		/// Get a zooTrainer by Id
		/// </summary>
		/// <param name="zooTrainerId">The zooTrainer Id to get</param>
		/// <returns>Matching user object as UserResponse type</returns>
		Task<UserResponse?> GetZooTrainerById(long zooTrainerId);

		/// <summary>
		/// Updates the specified user details based on the given user ID
		/// </summary>
		/// <param name="userUpdateRequest">User details to update</param>
		/// <returns>Returns the person response object updated</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		Task<UserResponse> UpdateUser(UserUpdateRequest? userUpdateRequest);

		/// <summary>
		/// Delete User by id
		/// </summary>
		/// <param name="userId">The user id to delete</param>
		/// <returns>True if delete success, else False</returns>
		Task<bool> DeleteUser(long userId);

		/// <summary>
		/// Change the password of an user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		Task<UserResponse> ChangePassword(long userId, string oldPassword, string newPassword);

		/// <summary>
		/// Get the user by Id
		/// </summary>
		/// <param name="userId">The userId to search</param>
		/// <returns>The matching user as userResponse</returns>
		Task<UserResponse?> GetUserById(long userId);
	}
}
