using demoApi.context;
using demoApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[EnableCors("MyPolicy")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly databaseContext context;

		public EmployeeController(databaseContext context)
		{
			this.context = context;
		}

		// GET: api/<EmployeeController>
		[HttpGet]
		public async Task<IEnumerable<Employee>> Get()
		{
			return await context.employees.ToListAsync();
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployee([FromBody] Employee model)
		{
			if (model.id == 0)
			{
				context.employees.Add(model);
			}
			else
			{
				context.employees.Update(model);
			}
			
			await context.SaveChangesAsync();
			return Ok();
		}

		public async Task<IActionResult> DeleteEmployee(int id)
		{
			context.employees.Remove(context.employees.Find(id));
			await context.SaveChangesAsync();
			return Ok();
		}

		// GET api/<EmployeeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<EmployeeController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<EmployeeController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EmployeeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
