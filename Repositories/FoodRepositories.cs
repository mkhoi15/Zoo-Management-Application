﻿using Entities.AppDbContext;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repositories
{
	public class FoodRepositories : IFoodRepositories
	{
		// prvate fields
		private readonly ApplicationDbContext _dbContext;

		// Constructor
		public FoodRepositories(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<Food> Add(Food food)
		{
			_dbContext.Foods.Add(food);
			await _dbContext.SaveChangesAsync();
			return food;
		}

		public async Task<bool> Delete(int foodId)
		{
			_dbContext.Foods.RemoveRange(_dbContext.Foods.Where(food => food.FoodId == foodId));
			int rowDeleted =  await _dbContext.SaveChangesAsync();
			return rowDeleted > 0;
		}

		public async Task<List<Food>> GetAllFood()
		{
			var listFoods = await _dbContext.Foods.ToListAsync();
			return listFoods;
		}

		public async Task<List<Food>> GetFiteredFood(Expression<Func<Food, bool>> predicate)
		{
			return await _dbContext.Foods.Where(predicate).ToListAsync();
		}

		public async Task<Food?> GetFoodByFoodId(int foodId)
		{
			var food = await _dbContext.Foods.Where(food => food.FoodId == foodId).FirstOrDefaultAsync();

			return food;
		}

		public async Task<Food?> GetFoodByName(string foodName)
		{
			return await _dbContext.Foods.Where(food => food.FoodName == foodName).FirstOrDefaultAsync();
		}

		public async Task<Food> Update(Food food)
		{
			Food? matchingFood = await _dbContext.Foods.FirstOrDefaultAsync(f => f.FoodId == food.FoodId);

			if(matchingFood is null) { return food; }

			matchingFood.FoodName = food.FoodName;
			await _dbContext.SaveChangesAsync();

			return matchingFood;
		}
	}
}
