﻿using System.ComponentModel.DataAnnotations;

namespace Services.Helper
{
	public class ValidationHelper
	{
		internal static void ModelValidation(object obj)
		{
			ValidationContext validationContext = new(obj);
			List<ValidationResult> validationResults = new();

			var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
			if (!isValid)
			{
				throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
			}
		}
	}
}
