using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJob.Models.ViewModels
{
	[Table("Images")]
	public class FjImage
	{
		public Guid Id { get; set; }

		public byte[] Image { get; set; }
	}
}
