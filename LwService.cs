using System;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.payoh.tutorial
{
	/*
	Helper to call Payoh API.
	*/
	public static class LwService
	{
		/*
		This tutorial required the Directkit json2. Please replace it with YOUR directkit URL. 
		1) Your directkit URL is sent to you by our Operation team.
		2) In order to run the tutorial, you have to ask the Operation team to whitelist your machine's IP address first. Otherwise, you cannot call any service.
		*/
		private static readonly string DIRECTKIT_URL = "https://sandbox-api.lemonway.fr/mb/demo/dev/directkitjson2/Service.asmx";

		/*
		The login and password is configurable from the Payoh backoffice (see your onboarding e-mail)
		*/
		private static readonly string LOGIN = "society";
		private static readonly string PASSWORD = "123456";

		public static async Task<LwResponse> CallAsync(string serviceName, LwRequest request) 
		{
			var serviceUrl = $"{DIRECTKIT_URL}/{serviceName}";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(serviceUrl);

				//client.DefaultRequestHeaders.Accept.Clear();
				var jsonContent = JsonConvert.SerializeObject(request);
				var postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(serviceUrl, postContent);
				if (response.IsSuccessStatusCode)
				{
					var responseJson = await response.Content.ReadAsStringAsync();
					var resu = JsonConvert.DeserializeObject<LwResponse>(responseJson);
					return resu;
				}
				throw new Exception($"Failed to call service {serviceName}: {response.StatusCode} - {response.Content}");
			}
		}

		public static LwResponse Call(string serviceName, LwRequest request) 
		{
			var t = CallAsync(serviceName, request);
			try
			{
				t.Wait();
			}
			catch (AggregateException ex)
			{
				throw ex.Flatten().InnerException;
			}
			return t.Result;
		}

		/*
		Create a LwRequest and fill some required parameters
		*/
		public static LwRequest CreateEmptyRequest() {
			var resu = new LwRequest();
			resu.p = new JObject();
			resu.Set("wlLogin", LOGIN);
			resu.Set("wlPass", PASSWORD);
			resu.Set("language", "en");
			resu.Set("version", "3.0");

			//in production, please put the address IP of your final client instead
			resu.Set("walletIp", "127.0.0.1"); 
			//in production, please put the user agent of your final client instead
			resu.Set("walletUa", "dotnetcore");
			return resu;
		}

		/*
		short-hand to set request parameter to the "p" wrapper
		*/
		public static void Set(this LwRequest r, string key, string value) 
		{
			r.p[key] = value;
		}
		/*
		short-hand to set request parameter to the "p" wrapper
		*/
		public static void Set(this LwRequest r, string key, double value) 
		{
			r.Set(key, value.ToString("0.00"));
		}
	}
}
