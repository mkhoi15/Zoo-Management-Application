﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long UserId { get; set; }

		[StringLength(80)]
		[NotNull]
		public string? UserName { get; set; }

		[NotNull]
		[StringLength(80)]
		public string? FullName { get; set; }

		[NotNull]
		[StringLength(20)]
		public string? Password { get; set; }

		[NotNull]
		public bool IsDelete { get; set; }

		[NotNull]
		[StringLength(20)]
		public string? PhoneNumber { get; set; }

		[NotNull]
		[StringLength (80)]
		public string? Email { get; set; }

		[NotNull]
		[StringLength(15)]
		public string? Gender { get; set; }

		[NotNull]
		[Column(TypeName = "DateTime2")]
		public DateTime DateOfBirth { get; set; }

		[NotNull]
		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public virtual Role? Role { get; set; }
		public virtual List<Skill> Skills { get; set; } = new List<Skill>();
		public virtual ICollection<AnimalUser> UserAnimals { get; set; } = new List<AnimalUser>();
	}
}
