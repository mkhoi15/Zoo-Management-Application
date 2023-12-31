﻿using ServiceContracts.DTO.NewsDTO;

namespace ServiceContracts
{
	public interface INewsServices
	{
		/// <summary>
		/// Adding the new News into the News table
		/// </summary>
		/// <param name="newsAddRequest">The news to add</param>
		/// <returns>NewsResponse object base on the news adding</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		Task<NewsResponse> AddNews(NewsAddrequest? newsAddRequest);

		/// <summary>
		/// Get All the News in the News table
		/// </summary>
		/// <returns>A list of News object as NewsResponse</returns>
		Task<List<NewsResponse>> GetAllNews();

		/// <summary>
		/// Get a News by Id
		/// </summary>
		/// <param name="newsId">The Id of news to get</param>
		/// <returns>Matching news object as NewsResponse type</returns>
		Task<NewsResponse?> GetNewsById(int newsId);

		/// <summary>
		/// Updates the specified news details based on the given news ID
		/// </summary>
		/// <param name="newsUpdateRequest">News details to update</param>
		/// <returns>Returns the news response object updated</returns>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		Task<NewsResponse> UpdateNews(NewsUpdateRequest? newsUpdateRequest);

		/// <summary>
		/// Delete exsiting news by news id
		/// </summary>
		/// <param name="newsId">The news id to delete</param>
		/// <returns>Returns true if delete success,otherwise return false</returns>
		Task<bool> DeleteNews(int newsId);

		/// <summary>
		/// Returns all news obj that matches with the given
		/// </summary>
		/// <param name="searchBy">Search field to search</param>
		/// <param name="searchString">Search string to search</param>
		/// <returns>Returns all matching news base on the given search field and search string</returns>
		Task<List<NewsResponse>> GetFiteredNews(string searchBy, string? searchString);

		/// <summary>
		/// Get 3 newest news of the zoo
		/// </summary>
		/// <returns>Return a list of news</returns>
		Task<List<NewsResponse>> GetTop3News();

		/// <summary>
		/// Recovery a deleted news by id
		/// </summary>
		/// <param name="newsId">The id of the deleted news</param>
		/// <returns>Returns true if recovery successfully, else return false</returns>
		Task<bool> RecoveryNews(int newsId);

		/// <summary>
		/// Get all deleted news
		/// </summary>
		/// <returns>Return a list of NewResponse</returns>
		Task<List<NewsResponse>> GetAllDeletedNews();

		/// <summary>
		/// Get 3 reletive news
		/// </summary>
		/// <returns>Returns a list of NewsResponse</returns>
		Task<List<NewsResponse>> Get3ReletiveNews(int CategoryId);

		/// <summary>
		/// Returns all news obj that matches with the given
		/// </summary>
		/// <param name="searchBy">Search field to search</param>
		/// <param name="searchString">Search string to search</param>
		/// <returns>Returns all matching news base on the given search field and search string</returns>
		Task<List<NewsResponse>> GetCustomerSiteNews(string searchBy, string? searchString);
	}
}
