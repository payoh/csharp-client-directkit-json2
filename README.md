# LemonWay [.NET Core](https://www.microsoft.com/net/core) tutorial

This is a console application developed and tested on a Linux machine using the [.NET Core platform](https://www.microsoft.com/net/core).

It calls the [GetWalletDetails service](http://documentation.lemonway.fr/api-en/directkit/manage-wallets/getwalletdetails-getting-detailed-wallet-data)
and display the details information of the wallet `sc`.

It is a very basic application, to demonstrate how easy to access to the LemonWay service. However, in real project you should use the [`LemonWayService` library](https://github.com/lemonwaysas/aspdotnet-client-directkit-json2/tree/master/src/LemonWayService)

>ASP.NET MVC developer might interested in
>
>https://github.com/lemonwaysas/aspdotnet-client-directkit-json2
>
>There, you will also find the [`LemonWayService` library](https://github.com/lemonwaysas/aspdotnet-client-directkit-json2#lemonwayservice-project-library) - a more advance `LwService` helper than the one used here.

# How to run

1. Edit the `LwService.cs`. Put your `DIRECTKIT_URL` (json2), `LOGIN` and `PASSWORD`
2. Run the example:
```
dotnet run
```

# Time to play!

The example is only the basic, you can play with our API by calling other services. For example:

- [Create a new wallet](http://documentation.lemonway.fr/api-en/directkit/manage-wallets/registerwallet-creating-a-new-wallet)
- [Create a payment link to credit a wallet](http://documentation.lemonway.fr/api-en/directkit/money-in-credit-a-wallet/by-card/moneyinwebinit-indirect-mode-money-in-by-card-crediting-a-wallet)
- [Credit the wallet without 3D secure](http://documentation.lemonway.fr/api-en/directkit/money-in-credit-a-wallet/by-card/moneyin-credit-a-wallet-with-a-non-3d-secure-card-payment)
- [Credit the wallet with 3D secure](http://documentation.lemonway.fr/api-en/directkit/money-in-credit-a-wallet/by-card/moneyin3dinit-direct-mode-3d-secure-payment-init-to-credit-a-wallet)
- [Create a payment form to credit a wallet](http://documentation.lemonway.fr/api-en/directkit/money-in-credit-a-wallet/payment-form)
- [Register a Credit card to the wallet](http://documentation.lemonway.fr/api-en/directkit/money-in-credit-a-wallet/by-card/registercard-linking-a-card-number-to-a-wallet-for-one-click-payment-or-rebill)
- [Register an IBAN to the wallet](http://documentation.lemonway.fr/api-en/directkit/money-out-debit-a-wallet-and-credit-a-bank-account/registeriban-link-an-iban-to-a-wallet)
- [Transfer money from wallet to a bank account](http://documentation.lemonway.fr/api-en/directkit/money-out-debit-a-wallet-and-credit-a-bank-account/moneyout-external-fund-transfer-from-a-wallet-to-a-bank-account)
- [Transfer money from wallet to other wallet](http://documentation.lemonway.fr/api-en/directkit/p2p-transfer-between-wallets/sendpayment-on-us-payment-between-wallets)


# Side notes

* You can only call the LemonWay service from your server which has been whitelisted.
* It is not the only way to access to our API, feel free to use your own library.

# For Windows User
## Update 2007-01-03
- For some reason, dotnet Core for Linux is 1.1.0 but dotnet core for Windows is 1.0.3 So you will have to change the `project.json` to use 1.0.3 instead
```
"Microsoft.NETCore.App": {
    "type": "platform",
    "version": "1.0.3"
}
```
- And then restore the `project.lock.json` which we didn't commit with:
```
dotnet restore
```
