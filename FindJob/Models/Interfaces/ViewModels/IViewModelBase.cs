using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJob.Models.Interfaces.ViewModels
{
	interface IViewModelBase<T>
	{
		void Update(T newModel);
	}
}
