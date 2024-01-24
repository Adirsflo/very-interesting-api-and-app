namespace VeryInterestingAPIAndApp.Models
{
	public class User
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		public string? FullName { get { return $"{FirstName} {LastName}".Trim(); } }
		public string? Gender { get; set; }
		public DateTime BirthDate { get; set; }
		public string? BloodStatus { get; set; }
		public string? House { get; set; }
		public string? Profession { get; set; }
		public List<string>? Affiliations { get; set; }

	}
}
