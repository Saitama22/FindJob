using System.Collections.Generic;
using System.Linq;

namespace FindJob.Models.ParamModels
{
	public class Result
	{
		public bool Succeeded { get; set; }

		public IEnumerable<string> Errors { get; set; } = new List<string>();

		public IEnumerable<string> ResultInfo { get; set; }

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

		public static Result SuccessResult(string resultInfo)
		{
			var res = new Result
			{
				Succeeded = true,	
			};
			res.ResultInfo.Append(resultInfo);
			return res;
		}

		public static Result SuccessResult(IEnumerable<string> resultInfos)
		{
			var res = new Result
			{
				Succeeded = true,	
			};
			foreach (var resultInfo in resultInfos)
			{
				res.ResultInfo.Append(resultInfo);
			}
			return res;
		}

		public static Result ErrorResult(string error)
		{
			var res = new Result
			{
				Succeeded = false,				
			};
			res.AddError(error);
			return res;
		}

		public static Result ErrorResult(IEnumerable<string> errors)
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
