﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Sdl.Web.IQQuery.API;
using Sdl.Web.IQQuery.RestClient;
using Sdl.Web.HttpClient.Auth;

namespace Sdl.Web.IQQuery.Client
{
    /// <summary>
    /// Default IQ search client implementation
    /// </summary>
    public class IQSearchClient<T,R> : ISearcherApi<T,R> where T : IQueryResultData<R> where R : IQueryResult
    {
        private readonly IQueryClient<T,R> _client;       
        public string IndexName { get; set; }
        public IResultFilter ResultFilter { get; set; }

        public IQSearchClient(Uri endpoint, IAuthentication auth, string indexName = "udp-index")
        {
            // get our query client defaulting to the rest query client
            _client = new RestQueryClient<T, R>(endpoint, auth, indexName);
        }
        
        public ISearcherApi<T,R> WithResultFilter(IResultFilter filter)
        {
            ResultFilter = filter;
            return this;
        }

        public ISearcherApi<T,R> WithIndexName(string indexName)
        {
            IndexName = indexName;
            return this;
        }    

        public T Search(ICriteria criteria) 
            => _client.SearchWithCriteria(IndexName, criteria, ResultFilter);

        public async Task<T> SearchAsync(ICriteria criteria, CancellationToken cancellationToken = default(CancellationToken))
            => await _client.SearchWithCriteriaAsync(IndexName, criteria, ResultFilter, cancellationToken);        

        public T Search(string query) 
            => _client.SearchWithCriteria(IndexName, query, ResultFilter);

        public async Task<T> SearchAsync(string query, CancellationToken cancellationToken = default(CancellationToken)) 
            => await _client.SearchWithCriteriaAsync(IndexName, query, ResultFilter, cancellationToken);

        public T SearchById(string index, string id)
            => _client.SearchById(index, id);
    }
}
