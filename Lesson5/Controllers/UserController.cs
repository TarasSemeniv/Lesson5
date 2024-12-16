using Microsoft.AspNetCore.Mvc;
using Lesson5.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Lesson5.Controllers;
[ApiController]
[Route("users")]
public class UserController : Controller
{
	[HttpGet]
	public ActionResult<List<User>> GetUsers()
	{
		var users = new List<User>()
		{
			new User()
			{
				Id = 1,
				Nickname = "Nickname",
				Password = "password",
				DateOfBirth = DateTime.Now,
				Description = "test"
			},
			new User()
			{
				Id = 1,
				Nickname = "Nickname2",
				Password = "12345678",
				DateOfBirth = DateTime.Now,
				Description = "test"
			}
		};
		return Ok(users);
	}
	[HttpGet("{nickname}")]
	public ActionResult<User> GetUserByNickname(string nickname)
	{
		var user = new User()
		{
			Id = new Random().Next(1, 100),
			Nickname = nickname,
			Password = "password",
			DateOfBirth = DateTime.Now,
			Description = "test"
		};
		return Ok(user);
	}
	[HttpPost]
	public ActionResult<User> AddUser(User user)
	{
		user.Id = new Random().Next(1, 100);
		return Created($"users/{user.Id}",user);
	}
}
