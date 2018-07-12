﻿using System.Collections.Generic;
using Sdl.Web.HttpClient;

namespace Sdl.Web.GraphQLClient.Response
{
    public class GraphQLResponse : IGraphQLResponse
    {
        public dynamic Data { get; set; }
        public List<GraphQLError> Errors { get; set; }
        public HttpHeaders Headers { get; set; }
    }
}
