using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.App
{
	public interface IProduct
	{
		Guid Id { get;  }
		String Name { get; set; }
		int Count { get; set; }
		int UnitPrice { get; set; }
		int TotalPrice { get; }
		HealthIndex HealthIndex { get; }
	}
}
