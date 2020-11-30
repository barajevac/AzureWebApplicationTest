using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;

namespace AzureWebApiApplication.Models
{
	public class Organization : Item
	{
		public string PostalCode { get; set; }
		public string Name { get; set; }
		public ICollection<Student> Students { get; set; }
	}
}