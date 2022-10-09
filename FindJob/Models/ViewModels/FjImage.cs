using System;
using System.ComponentModel.DataAnnotations.Schema;
using FindJob.Models.Interfaces.ViewModels;

namespace FindJob.Models.ViewModels
{
	[Table("Images")]
	public class FjImage : IIdModel, IViewModelBase<FjImage>
	{
		public Guid Id { get; set; }

		public byte[] Image { get; set; }

		public void Update(FjImage newModel)
		{
			
		}
	}
}
