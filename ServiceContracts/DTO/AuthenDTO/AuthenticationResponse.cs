﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO.AuthenDTO
{
	public class AuthenticationResponse
	{
		public long UserId { get; set; }
		public string UserName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Role { get; set; } = string.Empty;

		public string? Token { get; set; } = string.Empty;

		public DateTime Expiration { get; set; }
	}
}
