namespace T2301EAssignment.Models.DTOs
{
	public class EmployeeDTO
	{
		public int Id { get; set; }
		public string? EmployeeName { get; set; }
		public string? EmployeeCode { get; set; }
		public string? Rank { get; set; }

		public int DepartmentId { get; set; }
	}
}
