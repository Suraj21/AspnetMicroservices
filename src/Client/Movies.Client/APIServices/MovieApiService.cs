using IdentityModel.Client;
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
            //1 - Get Token from Identity server
            //2. Send Request to protected API
            //3. Deserialize object to MovieList

            //1 . 
            var apiClientCredentails = new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:5001/connect/token",

                ClientId = "moviesClient",
                ClientSecret = "secret",
                Scope = "moviesAPI"
            };

            //Create a new HttpClient to talk to Identity Server
            var client = new HttpClient();

            var discovery = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if(discovery.IsError)
            {
                return null;
            }

            //2. Authenticate and get an access token from Identity Server
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredentails);
            if(tokenResponse.IsError)
            {
                return null;
            }

            //2/ Send Request to protected API
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("http://localhost:5000/api/movies");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            return movies;

            //var movieList = new List<Movie>();
            //movieList.Add(new Movie
            //{
            //    Id = 1,
            //    Name = "Movie1"
            //});
            //return await Task.FromResult(movieList);
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
