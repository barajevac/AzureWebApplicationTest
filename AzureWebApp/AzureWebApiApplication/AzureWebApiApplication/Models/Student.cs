using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Azure.CosmosRepository;

namespace AzureWebApiApplication.Models
{
	public class Student : Item
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Organization Organizations { get; set; }
	}
}