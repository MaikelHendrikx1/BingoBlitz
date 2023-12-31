﻿using BingoBlitz_CommunityHub.Data.Interfaces;
using BingoBlitz_CommunityHub.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using static BingoBlitz_CommunityHub.Models.IterableObjectiveCollectionData;

namespace BingoBlitz_CommunityHub.Data
{
    /// <summary>
    /// Implements ObjectiveData storage using CosmosDB
    /// </summary>
    public class CosmosObjectiveData : IObjectiveData
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosObjectiveData(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("CommunityHub", "ObjectiveCollection");
        }

        public async Task<IterableObjectiveCollectionData> QueryCollectionsByPage(int pageSize, string? continuationToken = null, string filter = "", string? userid = null)
        {
            QueryRequestOptions requestOptions = new()
            {
                MaxItemCount = pageSize
            };

            QueryDefinition queryDefinition = 
                userid == null
                ? //if userid is null:
                new QueryDefinition("SELECT c.id, c.Name, c.UserId, c.UserName, ARRAY_LENGTH(c.Objectives) AS ObjectiveCount FROM c WHERE CONTAINS(c.Name, @filter)")
                    .WithParameter("@filter", filter)

                : //if userid is not null:
                new QueryDefinition("SELECT c.id, c.Name, c.UserId, c.UserName, ARRAY_LENGTH(c.Objectives) AS ObjectiveCount FROM c WHERE CONTAINS(c.Name, @filter) AND c.UserId = @userid")
                    .WithParameter("@filter", filter)
                    .WithParameter("@userid", userid);

            FeedIterator<ObjectiveCollectionData> feedIterator = _container.GetItemQueryIterator<ObjectiveCollectionData>(queryDefinition, continuationToken, requestOptions);

            FeedResponse<ObjectiveCollectionData> result = await feedIterator.ReadNextAsync();

            return new IterableObjectiveCollectionData(result.Resource.ToList(), result.ContinuationToken);
        }

        public async Task<ObjectiveCollection> GetObjectiveCollectionById(string id)
        {
            ItemResponse<ObjectiveCollection> collection = await _container.ReadItemAsync<ObjectiveCollection>(id, PartitionKey.None);

            return collection.Resource;
        }

        public async Task<string> SaveObjectiveCollection(ObjectiveCollection collection)
        {
            collection.Id = Guid.NewGuid().ToString();

            ItemResponse<ObjectiveCollection> response = await _container.CreateItemAsync(collection);

            return response.Resource.Id;
        }
    }
}
