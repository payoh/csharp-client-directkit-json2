using Newtonsoft.Json.Linq;

namespace com.payoh.tutorial
{
	/**
	All directkit json request is wrapped in the "p" object to prevent json-hijack issue
	*/
	public class LwRequest
	{
		public JObject p;
	}
	
	/**
	All directkit json response is wrapped in the "d" object to prevent json-hijack issue
	*/
	public class LwResponse
	{
		public JObject d;
	}
}
