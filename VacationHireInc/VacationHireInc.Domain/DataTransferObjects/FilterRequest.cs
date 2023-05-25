using System;
namespace VacationHireInc.Domain.DataTransferObjects
{
	public class FilterRequest
	{
		public int Page { get; set; } = 1;
		public int PageSize { get; set; } = 10;

		// Can be improved with sorting and filtering
	}
}

