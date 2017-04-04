using System;

namespace com.lemonway.tutorial
{
	public class Program
	{
		/*
		This example call the GetWalletDetails service to display the wallet information
		http://documentation.lemonway.fr/api-en/directkit/manage-wallets/getwalletdetails-getting-detailed-wallet-data
		*/
		public static void Example001() 
		{
			const string walletExtId = "sc";

			var request = LwService.CreateEmptyRequest();
			request.Set("wallet", walletExtId);
			var response = LwService.Call("GetWalletDetails", request).d;

			//check if the GetWalletDetails service return error
			var err = response["E"];
			if (err.HasValues) 
			{
				Console.Error.WriteLine($"GetWalletDetails failed: error {err["Code"]} - {err["Msg"]}");
				return;
			}
			Console.WriteLine("GetWalletDetails success. The wallet info is: ");
			Console.WriteLine(response);
		}

		public static void Main(string[] args)
		{	
			Console.WriteLine("---- Application start -----------");
			try 
			{
				Example001();
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex);
			}
			Console.WriteLine("---- Application end -------------");
		}
	}
}
