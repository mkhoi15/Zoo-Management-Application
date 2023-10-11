﻿using Entities.Models;
using ServiceContracts.DTO.FoodDTO;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO.MealDTO
{
	/// <summary>
	/// Represents DTO class that is used as return type of most methods of AnimalFood service
	/// </summary>
	public class MealResponse
	{
		[Required]
		public long AnimalId { get; set; }
		public string? Note { get; set; }
		[Required]
		public TimeSpan FeedingTime { get; set; }

		public List<FoodResponse> Food { get; set; } = new List<FoodResponse>();
	}

	public static class MealResponseExtensionMethods
	{
		/// <summary>
		/// An extension method to convert an object of AnimalFood class into MealResponse class
		/// </summary>
		/// <param name="meal">The AnimalFood object to convert</param>
		/// /// <returns>Returns the converted MealResponse object</returns>
		public static MealResponse MapToResponse(this AnimalFood meal)
		{
			return new MealResponse()
			{
				AnimalId = meal.AnimalId,
				Note = meal.Note,
				FeedingTime = meal.FeedingTime
			};
		}
	}

}
