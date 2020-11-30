using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using AzureWebApiApplication.Models;
using Microsoft.Azure.CosmosRepository;

namespace AzureWebApiApplication.Repository
{
	public class GenericRepository<T> where T : Item
	{
		private static readonly string EndpointUri = "https://vladan-cosmos-test.documents.azure.com:443/";
		private static readonly string PrimaryKey = "TOPDFcOBe6EOS0b68OXBISRN8RlMUPfgxUWoG50K8ZgC78Aotb0O3wc0gB1rFZgPTP9U0wvFOTjQKuM16HMNqg==";

		private CosmosClient cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
		private Container container;

		private string databaseId = "AzureCosmosDBTest";

		public GenericRepository()
		{
			InitContainer();
		}

		public List<T> GetAll()
		{
			var sqlQueryText = "SELECT * FROM c";
			Task<FeedResponse<T>> getFilteredItems = GetQueryResult(sqlQueryText);

			var filteredItems = getFilteredItems.Result.Resource.ToList();
			return filteredItems;
		}


		public T Get(Guid id)
		{
			var sqlQueryText = $"SELECT * FROM c WHERE c.id = '{id}'";
			Task<FeedResponse<T>> getFilteredItems = GetQueryResult(sqlQueryText);

			var filteredItems = getFilteredItems.Result.Resource.FirstOrDefault();
			return filteredItems;
		}

		public async Task Add(T item)
		{
			await container.CreateItemAsync(item);
		}

		public async Task Update(Guid id, T item)
		{
			await container.ReplaceItemAsync(item, id.ToString());
		}

		public async Task Delete(Guid id)
		{
			await container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
		}

		private void InitContainer()
		{
			var parseContainer = typeof(T).ToString().Split('.');
			var containerId = parseContainer[parseContainer.Length - 1];
			container = cosmosClient.GetContainer(databaseId, containerId);
		}

		private Task<FeedResponse<T>> GetQueryResult(string sqlQueryText)
		{
			QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
			FeedIterator<T> queryResultSetIterator = container.GetItemQueryIterator<T>(queryDefinition);
			var getFilteredItems = queryResultSetIterator.ReadNextAsync();
			getFilteredItems.Wait();
			return getFilteredItems;
		}
	}
}