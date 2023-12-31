﻿using Entities.AppDbContext;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repositories
{
	public class NewsRepositories : INewsRepositories
	{
		// private field
		private readonly ApplicationDbContext _dbContext;
		private readonly INewsCategoriesRepositories _newsCategoriesRepositories;
		

		// constructor
		public NewsRepositories(ApplicationDbContext dbContext, INewsCategoriesRepositories newsCategoriesRepositories)
		{
			_dbContext = dbContext;
			_newsCategoriesRepositories = newsCategoriesRepositories;
		
		}

		public async Task<News> Add(News news)
		{
			var cate = await _newsCategoriesRepositories.GetCategoryById(news.CategoryId.Value);

			if(cate == null)
			{
				throw new ArgumentException("The category is not exist!");
			}

			if(news is null) throw new ArgumentNullException(nameof(news));

			_dbContext.News.Add(news);

			await _dbContext.SaveChangesAsync();

			news.NewsCategories = cate;

			return news;
		}

		public async Task<bool> DeleteNews(int newsId)
		{
			var deleteNews = await _dbContext.News.Where
							(n => n.NewsId == newsId).FirstAsync();

			if (deleteNews is null)
			{
				return false;
			}

			if(deleteNews.IsActive == false)
			{
				return false;
			}

			deleteNews.IsActive = false; 

			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<List<News>> GetAllDeleteNews()
		{
			var listNews = await _dbContext.News.Where(n => n.IsActive == false)
									.Include(cate => cate.NewsCategories)
									.Include(user => user.User)
									.ToListAsync();

			return listNews;
		}

		public async Task<List<News>> GetAllNews()
		{
			var listNews = await _dbContext.News.Where(n => n.IsActive == true)
									.Include(cate => cate.NewsCategories)
									.Include(user => user.User)
									.ToListAsync();

			return listNews;
		}

		public async Task<List<News>> GetAllNewsStaffSite()
		{
			var listNews = await _dbContext.News
									.Include(cate => cate.NewsCategories)
									.Include(user => user.User)
									.ToListAsync();
			return listNews;
		}

		public async Task<List<News>> GetCustomerSiteNews(Expression<Func<News, bool>> predicate)
		{
			return await _dbContext.News.Where(news => news.IsActive == true)
								  .Include(news => news.NewsCategories)
								  .Include(user => user.User)
								  .Where(predicate).ToListAsync();
		}

		public async Task<List<News>> GetFilteredNews(Expression<Func<News, bool>> predicate)
		{
			return await _dbContext.News.Include(news => news.NewsCategories)
								  .Include(user => user.User)	
								  .Where(predicate).ToListAsync();
		}

		public async Task<News?> GetNewsById(int id)
		{
			var news = await _dbContext.News
								.Include(cate => cate.NewsCategories)
								.Include(user => user.User)
								.Where(n => n.NewsId == id)
								.FirstOrDefaultAsync();

			return news;
		}

		public async Task<News?> GetNewsByTitle(string title)
		{
			var news = await _dbContext.News.Where(n => n.Title == title).FirstOrDefaultAsync();

			return news;
		}

		public async Task<bool> RecoveryNews(int newsId)
		{
			var recoveryNews = await _dbContext.News.Where
							(n => n.NewsId == newsId).FirstAsync();

			if (recoveryNews is null)
			{
				return false;
			}

			if(recoveryNews.IsActive == true)
			{
				return false;
			}

			recoveryNews.IsActive = true;

			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<News> UpdateNews(News news)
		{
			News? updateNews = await _dbContext.News.Where
						(n => n.NewsId == news.NewsId).FirstOrDefaultAsync();

			if (updateNews is null) return news;

			updateNews.Author = news.Author;
			updateNews.Title = news.Title;
			updateNews.Content = news.Content;
			updateNews.Thumnail = news.Thumnail;
			updateNews.CategoryId = news.CategoryId;
			updateNews.Image = news.Image;
			updateNews.ReleaseDate = news.ReleaseDate;
			updateNews.UserId = news.UserId;

			int countUpdated = await _dbContext.SaveChangesAsync();

			return countUpdated > 0 ? updateNews : news;
		}
	}
}
