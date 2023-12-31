﻿using Entities.Models;
using ServiceContracts.DTO.FoodDTO;
using ServiceContracts.DTO.MealDTO;

namespace ServiceContracts
{
	public interface IMealServices
	{
		/// <summary>
		/// Adding the new meal into the AnimalFood table
		/// </summary>
		/// <param name="mealAddRequest">The meal to add</param>
		/// <returns>MealResponse object base on the meal adding</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		Task<AnimalFoodResponse> AddMeal(List<MealAddRequest> mealAddRequest);

		/// <summary>
		/// Get All the meal in AnimalFood table base on animalUser id
		/// </summary>
		/// <param name="id">The animal id </param>
		/// <returns>All the food that belong to an specified animal</returns>
		Task<List<MealResponse>> GetAnimalMealById(long id);

		/// <summary>
		/// Get animal food base on AnimalUser id and time
		/// </summary>
		/// <param name="animalUserId">AnimalUser ID</param>
		/// <param name="time">Date</param>
		/// <returns>The specified food belong to an animal at a specified time</returns>
		Task<List<FoodResponse>> GetAnimalMealByIdAndTime(long animalUserId, TimeSpan time);

		/// <summary>
		/// Delete a meal by animal and feeding time
		/// </summary>
		/// <param name="deleteMeal">The specified meal to delete</param>
		/// <returns>Returns true if delete success, otherwise returns false</returns>
		Task<bool> DeleteAMeal(MealDeleteRequest deleteMeal);

		/// <summary>
		/// Delete a food in a meal
		/// </summary>
		/// <param name="deleteFood">The specified meal to delete</param>
		/// <returns>Returns true if delete success, otherwise returns false</returns>
		Task<bool> DeleteAFoodInAMeal(MealDeleteRequest2 deleteFood);

		/// <summary>
		/// Get all meal in AnimalFood table
		/// </summary>
		/// <returns>A list of AnimalFoob obj</returns>
		Task<List<MealResponse>> GetAllMeal();
	}
}
