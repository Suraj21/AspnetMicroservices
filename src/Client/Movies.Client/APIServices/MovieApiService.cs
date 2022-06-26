﻿using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.APIServices
{
    public class MovieApiService : IMovieApiService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MovieApiService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            ///Way 1
            var httpClient = httpClientFactory.CreateClient("MoviesAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/movies");
            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<List<Movie>>(content);

            ///Way 2
            //1 - Get Token from Identity server
            //2. Send Request to protected API
            //3. Deserialize object to MovieList

            //1 . 
            //var apiClientCredentails = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5001/connect/token",

            //    ClientId = "moviesClient",
            //    ClientSecret = "secret",
            //    Scope = "moviesAPI"
            //};

            ////Create a new HttpClient to talk to Identity Server
            //var client = new HttpClient();

            //var discovery = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            //if(discovery.IsError)
            //{
            //    return null;
            //}

            ////2. Authenticate and get an access token from Identity Server
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentails);
            //if(tokenResponse.IsError)
            //{
            //    return null;
            //}

            ////2/ Send Request to protected API
            //var apiClient = new HttpClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            //var response = await apiClient.GetAsync("http://localhost:5000/api/movies");
            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();

            //List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            return movies;
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
