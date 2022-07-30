using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJob.Models.ViewModels
{
	public class Result
	{
		public bool Succeeded { get; set; }

		public IEnumerable<string> Errors { get; set; } = new List<string>();

		public void AddError(string error)
		{
			Errors = Errors.Append(error);
		}

		public void AddErrors(IEnumerable<string> errors)
		{
			foreach (var error in errors)
			{
				Errors = Errors.Append(error);
			}
		}

		public static Result SuccessResult()
		{
			return new Result
			{
				Succeeded = true,				
			};
		}

		public static Result OneError(string error)
		{
			var res = new Result
			{
				Succeeded = false,				
			};
			res.AddError(error);
			return res;
		}

		public static Result ManyError(IEnumerable<string> errors)
		{
			var res = new Result
			{
				Succeeded = false,				
			};
			res.AddErrors(errors);
			return res;
		}
	}
}
