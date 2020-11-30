using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AzureWebApiApplication.Models;
using AzureWebApiApplication.Repository;

namespace AzureWebApiApplication.Controllers
{
    public class StudentController : ApiController
    {
	    GenericRepository<Student> GenericRepository = new GenericRepository<Student>();

		// GET: api/Student
		public IHttpActionResult Get()
        {
			var getAllStudents = GenericRepository.GetAll();
	        return Ok(getAllStudents);
		}

		// GET: api/Student/5
		public IHttpActionResult Get(Guid id)
		{
			var student = GenericRepository.Get(id);
			return Ok(student);
		}

		// POST: api/Student
		public async Task<IHttpActionResult> Post([FromBody]Student value)
		{
			await GenericRepository.Add(value);
			return Ok();
		}

		// PUT: api/Student/5
		public async Task<IHttpActionResult> Put(Guid id, [FromBody]Student value)
		{
			await GenericRepository.Update(id, value);
			return Ok();
		}

		// DELETE: api/Student/5
		public async Task<IHttpActionResult> Delete(Guid id)
		{
			await GenericRepository.Delete(id);
			return Ok();
		}
	}
}
