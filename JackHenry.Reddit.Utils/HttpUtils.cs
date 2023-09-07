using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;

namespace JackHenry.Reddit.Utils
{
	public class HttpUtils
	{
		public static int TimeOutValue = 10;

		public static async Task<T> Get<T>(string url, List<(string, string)> headers = null) 
		{
			using (var client = new HttpClient())
			{
				client.Timeout = TimeSpan.FromMinutes(5);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				headers?.ForEach(header => client.DefaultRequestHeaders.Add(header.Item1, header.Item2));

				var response = await client.GetAsync(url).ConfigureAwait(false);
				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<T>(content);
				else throw new Exception($"{response.ReasonPhrase} {response.Content}");
			}
		}

		public static async Task<T> Post<T>(string url, object data, List<(string, string)> headers = null)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

			using (var client = new HttpClient())
			{
				client.Timeout = TimeSpan.FromMinutes(5);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				headers.ForEach(header => client.DefaultRequestHeaders.Add(header.Item1, header.Item2));

				System.Diagnostics.Debug.WriteLine(json);

				var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);
				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<T>(content);
				else throw new Exception($"{response.ReasonPhrase} {response.Content}");
			}
		}

		public static async Task<T> Put<T>(string url, object data, List<(string, string)> headers = null)
		{
			var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

			using (var client = new HttpClient())
			{
				client.Timeout = TimeSpan.FromMinutes(5);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				headers.ForEach(header => client.DefaultRequestHeaders.Add(header.Item1, header.Item2));

				var response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				if (response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<T>(content);
				else throw new Exception($"{response.ReasonPhrase} {response.Content}");
			}
		}

		public static async Task Delete(string url, List<(string, string)> headers = null)
		{
			using (var client = new HttpClient())
			{
				client.Timeout = TimeSpan.FromMinutes(5);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				headers.ForEach(header => client.DefaultRequestHeaders.Add(header.Item1, header.Item2));

				var response = await client.DeleteAsync(url).ConfigureAwait(false);

				if (response.IsSuccessStatusCode) return;
				else throw new Exception($"{response.ReasonPhrase} {response.Content}");
			}
		}

	}
}