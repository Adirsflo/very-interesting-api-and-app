using Microsoft.AspNetCore.Mvc;
using VeryInterestingAPIAndApp.Models;

namespace VeryInterestingAPIAndApp.Controllers
{
	[ApiController]
	[Route("v1/[controller]")]
	public class UsersController : Controller
	{
		// All users

		public static List<User> Users { get; set; } = new()
		{
			new User
		{
				Id = 1,
				FirstName = "Harry",
				LastName = "Potter",
				Gender = "Male",
				BirthDate = new DateTime(1980, 7, 31),
				BloodStatus = "Half-Blood",
				House = "Gryffindor",
				Profession = "Auror",
				Affiliations = new List<string> { "Dumbledore's Army", "Order of the Phoenix", "Hogwarts School of Witchcraft and Wizardry" }
		},
		new User
		{
				Id = 2,
				FirstName = "Hermione",
				LastName = "Granger",
				Gender = "Female",
				BirthDate = new DateTime(1979, 9, 19),
				BloodStatus = "Muggle-born",
				House = "Gryffindor",
				Profession = "Ministry of Magic Official",
				Affiliations = new List<string> { "Dumbledore's Army", "Order of the Phoenix", "Ministry of Magic" }
		},
		new User
		{
				Id = 3,
				FirstName = "Ron",
				LastName = "Weasley",
				Gender = "Male",
				BirthDate = new DateTime(1980, 3, 1),
				BloodStatus = "Pure-Blood",
				House = "Gryffindor",
				Profession = "Auror",
				Affiliations = new List<string> { "Dumbledore's Army", "Order of the Phoenix", "Weasley Family" }
		},
		new User
		{
				Id = 4,
				FirstName = "Albus",
				LastName = "Dumbledore",
				Gender = "Male",
				BirthDate = new DateTime(1881, 8, 1),
				BloodStatus = "Half-Blood",
				House = "Gryffindor",
				Profession = "Hogwarts Headmaster",
				Affiliations = new List<string> { "Order of the Phoenix", "Hogwarts School of Witchcraft and Wizardry" }
		},
		new User
		{
				Id = 5,
				FirstName = "Lord",
				LastName = "Voldemort",
				Gender = "Male",
				BirthDate = new DateTime(1926, 12, 31),
				BloodStatus = "Half-Blood",
				House = "",
				Profession = "Dark Lord",
				Affiliations = new List<string> { "Death Eaters" }
		},
		new User
		{
				Id = 6,
				FirstName = "Severus",
				LastName = "Snape",
				Gender = "Male",
				BirthDate = new DateTime(1960, 1, 9),
				BloodStatus = "Half-Blood",
				House = "Slytherin",
				Profession = "Hogwarts Potions Master",
				Affiliations = new List<string> { "Death Eaters", "Order of the Phoenix", "Hogwarts School of Witchcraft and Wizardry" }
		},
		new User
		{
				Id = 7,
				FirstName = "Luna",
				LastName = "Lovegood",
				Gender = "Female",
				BirthDate = new DateTime(1981, 2, 13),
				BloodStatus = "Pure-Blood",
				House = "Ravenclaw",
				Profession = "Magizoologist",
				Affiliations = new List<string> { "Dumbledore's Army", "The Quibbler" }
		},
		new User
		{
				Id = 8,
				FirstName = "Neville",
				LastName = "Longbottom",
				Gender = "Male",
				BirthDate = new DateTime(1980, 7, 30),
				BloodStatus = "Pure-Blood",
				House = "Gryffindor",
				Profession = "Herbology Professor",
				Affiliations = new List<string> { "Dumbledore's Army", "Herbology Club", "Hogwarts School of Witchcraft and Wizardry" }
		},
		new User
		{
				Id = 9,
				FirstName = "Minerva",
				LastName = "McGonagall",
				Gender = "Female",
				BirthDate = new DateTime(1935, 10, 4),
				BloodStatus = "Half-Blood",
				House = "Gryffindor",
				Profession = "Hogwarts Transfiguration Professor",
				Affiliations = new List<string> { "Order of the Phoenix", "Hogwarts School of Witchcraft and Wizardry" }
		},
		new User
		{
				Id = 10,
				FirstName = "Sirius",
				LastName = "Black",
				Gender = "Male",
				BirthDate = new DateTime(1959, 11, 3),
				BloodStatus = "Pure-Blood",
				House = "Gryffindor",
				Profession = "Order of the Phoenix Member",
				Affiliations = new List<string> { "Order of the Phoenix", "Azkaban Escapee" }
		},
		new User
		{
				Id = 11,
				FirstName = "Bellatrix",
				LastName = "Lestrange",
				Gender = "Female",
				BirthDate = new DateTime(1951, 2, 12),
				BloodStatus = "Pure-Blood",
				House = "Slytherin",
				Profession = "",
				Affiliations = new List<string> { "Death Eaters", "Azkaban Escapee" }
		},
		new User
		{
				Id = 12,
				FirstName = "Rubeus",
				LastName = "Hagrid",
				Gender = "Male",
				BirthDate = new DateTime(1928, 12, 6),
				BloodStatus = "Half-Giant",
				House = "Gryffindor",
				Profession = "Keeper of Keys and Grounds at Hogwarts",
				Affiliations = new List<string> { "Order of the Phoenix", "Hogwarts School of Witchcraft and Wizardry" }
		},
};

		// Gets all users

		[HttpGet]
		public ActionResult<List<User>> Get()
		{
			if (Users != null && Users.Any())
			{
				return Ok(Users);
			}

			return NotFound("Could not find users");
		}

		// Searches for User ID

		[HttpGet]
		[Route("{id}")]
		public ActionResult<User?> Get(int id)
		{
			User? user = Users.FirstOrDefault(u => u.Id == id);

			if (user == null)
			{
				return NotFound("Could not find user with that ID");
			}

			return Ok(user);
		}

		// Adds user to API

		[HttpPost]
		public ActionResult Post(User user)
		{
			if (user == null || string.IsNullOrEmpty(user.FullName))
			{
				return BadRequest("Could not add user. Chech your JSON and try again!");
			}

			Users.Add(user);
			return Ok("User added!");
		}

		// Updates user in API

		[HttpPut]
		[Route("{id}")]
		public ActionResult Put(int id, User updatedUser)
		{
			if (updatedUser == null || string.IsNullOrEmpty(updatedUser.FullName))
			{
				return BadRequest("Could not update user. Check your JSON and try again!");
			}

			User? selectedUser = Users.FirstOrDefault(u => u.Id == id);

			if (selectedUser == null)
			{
				return NotFound("Could not find user with that ID");
			}

			// Updates the selected user
			selectedUser.FirstName = updatedUser.FirstName;
			selectedUser.LastName = updatedUser.LastName;
			selectedUser.Gender = updatedUser.Gender;
			selectedUser.BirthDate = updatedUser.BirthDate;
			selectedUser.BloodStatus = updatedUser.BloodStatus;
			selectedUser.House = updatedUser.House;
			selectedUser.Profession = updatedUser.Profession;
			selectedUser.Affiliations = updatedUser.Affiliations;

			return Ok("User updated!");
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult Delete(int id)
		{
			User? userToRemove = Users.FirstOrDefault(u => u.Id == id);
			if (userToRemove == null)
			{
				return NotFound("Could not find user with that ID");
			}

			Users.Remove(userToRemove);
			return Ok("User deleted!");
		}
	}
}
