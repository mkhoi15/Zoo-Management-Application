﻿

using Entities.Models;
using System.Linq.Expressions;

namespace RepositoryContracts
{
	/// <summary>
	/// Represents data access logic for managing AnimalFood entity
	/// </summary>
	public interface IMealRepositories
	{
		/// <summary>
		/// Adds a AnimalFood object to the data store
		/// </summary>
		/// <param name="animalFood">The meal to add</param>
		/// <returns>AnimalFood obj after adding</returns>
		Task<AnimalFood> Add(AnimalFood animalFood);

		/// <summary>
		/// Get all meal of an animal base on animal id and zoo trainer id
		/// </summary>
		/// <param name="id">The AnimalUser ID </param>
		/// <returns>List of meals or list of AnimalFood obj</returns>
		Task<List<IGrouping<TimeSpan, AnimalFood>>> GetAnimalMealById(long id);

		/// <summary>
		/// Get all meal of animals
		/// </summary>
		/// <returns>List of meals or list of AnimalFood obj</returns>
		Task<List<IGrouping<TimeSpan, AnimalFood>>> GetAllMeal();

		/// <summary>
		/// Update an existed meal
		/// </summary>
		/// <param name="animalFood">The AnimalFood obj to be Update</param>
		/// <returns>AnimalFood obj after Updated</returns>
		Task<AnimalFood> UpdateMeal(AnimalFood animalFood);

		/// <summary>
		/// Delete a food in an existed meal in a specified time
		/// </summary>
		/// <param name="animalFood">The AnimalFood obj to be delete</param>
		/// <returns>Returns true if delete is successful, otherwise returns false</returns>
		Task<bool> DeleteFoodInAMeal(AnimalFood animalFood);

		/// <summary>
		/// Get Animal Meal in a specified time base on the the specified Zoo Trainer
		/// </summary>
		/// <param name="AnimalUserId">The Id of the AnimalUser</param>
		/// <param name="feedingTime">The feeding time</param>
		/// <returns>Returns all the food of the animal at a specified feeding time</returns>
		Task<List<AnimalFood>> GetAnimalMealInASpecifiedTime(long AnimalUserId, TimeSpan feedingTime);

		/// <summary>
		/// Delete all food in a meal in a specified time
		/// </summary>
		/// <param name="animalUserId">The AnimalUser ID</param>
		/// <param name="feedingTime">The specified time</param>
		/// <returns>Returns true if delete success, otherwise returns false</returns>
		Task<bool> DeleteAMeal(long animalUserId, TimeSpan feedingTime);

		/// <summary>
		/// Get a food in a meal by animal id, user id,food id and feeding time
		/// </summary>
		/// <param name="animalFood">The id of animal, food, and feeding time</param>
		/// <returns>Returns the matching AnimalFood obj</returns>
		Task<AnimalFood?> GetSingleFoodInAnimalMeal(AnimalFood animalFood);

		
	}
}
