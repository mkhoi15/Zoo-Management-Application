﻿using Entities.Models;
using ServiceContracts.DTO.UserDTO;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO.AnimalDTO
{
	/// <summary>
	/// Act as a DTO class for adding new Animal
	/// </summary>
	public class AnimalAddRequest
	{
		[Required(ErrorMessage = "AnimalSpecies Can not be blank!")]
		public int SpeciesId { get; set; }

		[Required(ErrorMessage = "AnimalName Can not be blank!")]
		public string? AnimalName { get; set; }

		[Required(ErrorMessage = "DateArrive can not be blank!")]
		public DateTime DateArrive { get; set; }

		[Required(ErrorMessage = "Status can not be blank!")]
		public string? Status { get; set; }

		[Required(ErrorMessage = "Zoo Trainer ID Can not be blank!")]
		public long userId { get; set; }

		[Required(ErrorMessage = "Cage ID Can not be blank!")]
		public int cageId { get; set; }

		/// <summary>
		/// Converts the current object of AnimalUserUpdateRequest into a new object of AnimalUser type
		/// </summary>
		/// <returns>Returns AnimalUser object</returns>
		public Animal MapToAnimal()
		{
			return new Animal()
			{
				AnimalName = AnimalName,
				DateArrive = DateArrive,
				Status = Status,
				SpeciesId = SpeciesId,
			};
		}
	}
}
