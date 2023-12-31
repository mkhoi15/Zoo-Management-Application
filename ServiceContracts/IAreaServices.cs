﻿using ServiceContracts.DTO.AreaDTO;

namespace ServiceContracts
{
    public interface IAreaServices
	{
		/// <summary>
		/// Adding the new Area into the Area table
		/// </summary>
		/// <param name="areaAddRequest">The area to add</param>
		/// <returns>AreaResponse obj base on the area adding</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>"
		Task<AreaResponse> AddArea(AreaAddRequest? areaAddRequest);

		/// <summary>
		/// Get All the Area in Area table
		/// </summary>
		/// <returns>A list of Area obj as AreaResponse</returns>
		Task<List<AreaResponse>> GetAllArea();

		/// <summary>
		/// Get Area by Id
		/// </summary>
		/// <param name="id">Area ID</param>
		/// <returns>The matching Area</returns>
		Task<AreaResponse?> GetAreaById(int? id);

		/// <summary>
		/// Deletes an Area obj based on the given AreaId
		/// </summary>
		/// <param name="id">AreaId to delete</param>
		/// <returns>Returns true if the deletion is successful, otherwise false</returns>
		Task<bool> DeleteArea(int? id);

		/// <summary>
		/// Updates the specified Area details based on the given areaId
		/// </summary>
		/// <param name="areaUpdateRequest">Area details to update, including Area ID</param>
		/// <returns>Returns the Area response obj after updation</returns>
		Task<AreaResponse> UpdateArea(AreaUpdateRequest? areaUpdateRequest);

		/// <summary>
		/// Returns all area objects that matches with the given search field and search string 
		/// </summary>
		/// <param name="searchBy">The field to search</param>
		/// <param name="searchString">The string to search</param>
		/// <returns>Returns all matching areas base on the given field</returns>
		Task<List<AreaResponse>> GetFilteredArea(string searchBy, string? searchString);
	}
}
