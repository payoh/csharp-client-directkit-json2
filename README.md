# Payoh [.NET Core](https://www.microsoft.com/net/core) tutorial

This is a console application developed and tested on a Linux machine using the [.NET Core platform](https://www.microsoft.com/net/core).

It calls the [GetWalletDetails service](https://payoh.me/documentazione/api/directkit.wallets.get-details)
and display the details information of the wallet `sc`.

It is a very basic application, to demonstrate how easy to access to the Payoh service. However, in real project you should use the [`PayohService` library](https://github.com/payoh/aspdotnet-client-directkit-json2/tree/master/src/PayohService)

>ASP.NET MVC developer might interested in
>
>https://github.com/payoh/aspdotnet-client-directkit-json2
>
>There, you will also find the [`PayohService` library](https://github.com/payoh/aspdotnet-client-directkit-json2#payohservice-project-library) - a more advance `LwService` helper than the one used here.

# How to run

1. Edit the `LwService.cs`. Put your `DIRECTKIT_URL` (json2), `LOGIN` and `PASSWORD`
2. Run the example:
```
dotnet run
```

# Time to play!

The example is only the basic, you can play with our API by calling other services. For example:

- [Create a new wallet](https://payoh.me/documentazione/api/directkit.wallets.register)
- [Create a payment link to credit a wallet](https://payoh.me/documentazione/api/directkit.moneyin.card.mi-web-initialize)
- [Credit the wallet without 3D secure](https://payoh.me/documentazione/api/directkit.moneyin.card.mi-credit-wallet)
- [Credit the wallet with 3D secure](https://payoh.me/documentazione/api/directkit.moneyin.card.mi-3d-initialize)
- [Create a payment form to credit a wallet](https://payoh.me/documentazione/api/directkit.moneyin.payment-form)
- [Register a Credit card to the wallet](https://payoh.me/documentazione/api/directkit.moneyin.card.mi-register-card)
- [Register an IBAN to the wallet](https://payoh.me/documentazione/api/directkit.moneyout.registeriban)
- [Transfer money from wallet to a bank account](https://payoh.me/documentazione/api/directkit.moneyout.moneyout)
- [Transfer money from wallet to other wallet](https://payoh.me/documentazione/api/directkit.p2p.sendpayment)


# Side notes

* You can only call the Payoh service from your server which has been whitelisted.
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
