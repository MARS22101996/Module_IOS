using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Interfaces;

namespace VTSClient.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private const string TokenHeaderName = "token";

		private readonly string _loginUri;
		private readonly HttpClient _httpClient;

		public UserRepository()
		{
			_loginUri = "http://localhost:5000/vts/signin";
			_httpClient = new HttpClient();
		}

		public async Task<string> Login(User user)
		{
			string loginJson = JsonConvert.SerializeObject(user);
			var content = new StringContent(loginJson, Encoding.UTF8, "application/json");

			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri(_loginUri),
				Method = HttpMethod.Post,
				Content = content
			};

			HttpResponseMessage response =  _httpClient.SendAsync(request).Result;

			IEnumerable<string> headerValues;
			bool isTokenExist = response.Headers.TryGetValues(TokenHeaderName, out headerValues);
			string token = null;

			if (isTokenExist)
			{
				token = headerValues.FirstOrDefault();
			}

			return token;
		}
	}
}
