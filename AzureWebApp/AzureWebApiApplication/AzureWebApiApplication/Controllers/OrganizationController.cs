using AzureWebApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AzureWebApiApplication.Repository;

namespace AzureWebApiApplication.Controllers
{
	public class OrganizationController : ApiController
	{
		GenericRepository<Organization> GenericRepository = new GenericRepository<Organization>();

		// GET: api/Organization
		public IHttpActionResult Get()
		{
			List<Organization> getAllOrganization = GenericRepository.GetAll();
			return Ok(getAllOrganization);  
		}

		public IHttpActionResult Get(Guid id)
		{
			var organization = GenericRepository.Get(id);
			return Ok(organization);
		}

		public async Task<IHttpActionResult> Post([FromBody]Organization value)
		{
			await GenericRepository.Add(value);
			return Ok();
		}

		public async Task<IHttpActionResult> Put(Guid id, [FromBody]Organization value)
		{
			await GenericRepository.Update(id, value);
			return Ok();
		}

		public async Task<IHttpActionResult> Delete(Guid id)
		{
			await GenericRepository.Delete(id);
			return Ok();
		}
	}
}
