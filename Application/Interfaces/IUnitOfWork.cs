using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
	/// <summary>
	/// IUnitOfWork
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		ObjectContext Context { get; set; }
		void Save();
		bool LazyLoadingEnabled { get; set; }
		bool ProxyCreationEnabled { get; set; }
		string ConnectionString { get; set; }
	}
}