using System;
namespace VacationHireInc.Domain.DataTransferObjects
{
	public class PaginatedResponse<T>
		where T : class
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public int TotalItemCount { get; set; }
		public ICollection<T> Results { get; set; } = new List<T>();
	}
}

