﻿using Entities.Models;
using System.Linq.Expressions;

namespace RepositoryContracts
{
	/// <summary>
	/// Represents data access logic for managing Area entity
	/// </summary>
	public interface IAreaRepositories
	{
		/// <summary>
		/// Adds a Area object to the data store
		/// </summary>
		/// <param name="area">The area to add</param>
		/// <returns>Area obj after adding</returns>
		Task<Area> Add(Area area);

		/// <summary>
		/// Get all the area in the dataset
		/// </summary>
		/// <returns>A list of Area obj</returns>
		Task<List<Area>> GetAllArea();

		/// <summary>
		/// Get area by id in the dataset
		/// </summary>
		/// <param name="areaId">The id of the area</param>
		/// <returns>Matching Area</returns>
		Task<Area?> GetAreaById(int? areaId);

		/// <summary>
		/// Get area by name in the dataset
		/// </summary>
		/// <param name="areaName">a character or a name </param>
		/// <returns>Matching Area </returns>
		Task<Area?> GetAreaByName(string areaName);

		/// <summary>
		/// Updates a Area obj based on the given AreaId 
		/// </summary>
		/// <param name="area">Area obj to update </param>
		/// <returns>Returns the updated area object</returns>
		Task<Area> UpdateArea(Area area);

		/// <summary>
		/// Deletes a Area obj based on the given AreaId
		/// </summary>
		/// <param name="area">Area ID to delete</param>
		/// <returns>Returns true if the deletion is successful otherwise false</returns>
		Task<bool> DeleteArea(int AreaId);

		/// <summary>
		/// Returns all area obj base on the given expression
		/// </summary>
		/// <param name="predicate">Linq expression to check</param>
		/// <returns>All matching areas with the given condition</returns>
		Task<List<Area>> GetFilteredArea(Expression<Func<Area, bool>> predicate);
	}
}
