using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationJwtAuth.Models;
using WebApplicationJwtAuth.Security;

namespace WebApplicationJwtAuth.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IJwtManagerRepository _jWTManager;

		public UsersController(IJwtManagerRepository jWTManager)
		{
			this._jWTManager = jWTManager;
		}

		[HttpGet]
		public List<string> Get()
		{
			var users = new List<string>
		{
			"Satinder Singh",
			"Amit Sarna",
			"Davin Jon"
		};

			return users;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("authenticate")]
		public IActionResult Authenticate(User usersdata)
		{
			var token = _jWTManager.Authenticate(usersdata);

			if (token == null)
			{
				return Unauthorized();
			}

			return Ok(token);
		}
	}
}
