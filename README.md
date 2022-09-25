<h6 align="center">
    <img src="https://larecipe.saleem.dev/images/logo.svg"/>
</h6>

<h2 align="center">
    LaRecipe (very early stage) | .Net ❤️
</h2>


<h6 align="center">
    Write gorgeous documentations for your products using Markdown inside your dotnet apps.
</h6>
    

<p align="center">
<a href="https://github.com/larecipe/larecipe-dotnet"><img src="https://img.shields.io/packagist/dt/binarytorch/larecipe.svg" alt="License"></a>
<a title="MadeWithVueJs.com Shield" href="https://madewithvuejs.com/p/larecipe/shield-link"> <img src="https://madewithvuejs.com/storage/repo-shields/1087-shield.svg"/></a>
<a href="https://github.com/larecipe/larecipe-dotnet"><img src="https://img.shields.io/github/release/larecipe/larecipe-dotnet.svg" alt="Release"></a>
<a href="https://github.com/larecipe/larecipe-dotnet"><img src="https://poser.pugx.org/laravel/framework/license.svg" alt="License"></a>
 <a href="#sponsors" alt="Sponsors on Open Collective"><img src="https://opencollective.com/larecipe/sponsors/badge.svg" /></a> 
</p>
<br/><br/>

# LaRecipe 🍪

**LaRecipe** is simply a code-driven package provides an easy way to create beautiful documentation for your product or application inside your **.Net** apps.

Note: LaRecipe was originally built to work with Laravel framework and now we're expanding the scope to integrate it with dotnet core applications. Check out the [Laravel integration version](https://github.com/saleem-hadad/larecipe)

![LaRecipe Screenshot](https://larecipe.saleem.dev/images/screenshot.png#)


## Getting Started

1. Install the standard Nuget package into your ASP.NET Core application.

> LaRecipe for dotnet is still in a very early stage (alpha), use it carefully in production.

```bash
# Package manager
Install-Package LaRecipe -Version 0.0.14-alpha

# CLI
dotnet add package LaRecipe --version 0.0.14-alpha
```

2. Register LaRecipe as a service and use the middleware

This middleware will be used only when the request path starts with `/docs`, this is to insure not having any performance hit for the rest of your application. 

> Minimal API

```
using LaRecipe.Extensions;

..

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLaRecipe() // <- add LaRecipe

...
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    ...
    app.UseLaRecipe() // <- Use in development only, but feel free to use it in other/all environments.
}
```


3. Add the markdown documentation files, you can use the LaRecipe CLI to help you with that or you can create them manually if you like:

> Check the [provided example](https://github.com/larecipe/larecipe-dotnet/tree/main/tests/LaRecipe.Example/Documentation) for more information


```
# run these commands in the root of your application
dotnet new tool-manifest # if you are setting up this repo
dotnet tool install --local LaRecipe.Cli --version 0.0.2-alpha
dotnet larecipe install
```

The above CLI command will generate the initial docs files as follow:

```
.(root)
├─ Documentation
|  │─ index.md
│  └─ overview.md
```

4. If you're using docker image to build and deploy your application, make sure to include the documentation files in the published image. Add this configuration to your application `xxx.csproj` 

```
<ItemGroup>
    <Content Include="Documentation\**\*" CopyToPublishDirectory="Always" />
</ItemGroup>
```


Finally, run the app and visit `/docs` endpoint. Enjoy documenting.

#### See [full documentation](https://larecipe.saleem.dev/)


## Used by

* [Zino](https://zino.binarytorch.com.my/1.0/installation) - 🤖 Custom Arduino library made for humans.
* [Blogged](https://blogged.binarytorch.com.my/docs/1.0/overview) - Blogged is a package provides an easy way to create beautiful blog inside your Laravel projects.
* [WooSignal](https://woosignal.com/docs/api/1.0/overview) - Fastest WooCommerce
App Templates.
* [AddChat](https://addchat-docs.classiebit.com/docs/1.0/introduction) - All-in-one multi-purpose Chat Widget For Laravel & Codeigniter websites.
* [RoadLeagues](https://roadleagues.com/docs/1.0/overview) - A cycling league management system with an API to allow data distrubution externally.
* [Raileo](https://raileo.com/docs/1.0/overview) - Raileo helps you to monitor your website's uptime, performance and SEO
* Put your docs here 😍👌



## Sponsors

Support this project by becoming a sponsor. Your logo will show up here with a link to your website. [[Become a sponsor](https://github.com/sponsors/saleem-hadad)]

## JetBrains
Thank you, JetBrains for sponsoring the license ❤️

<a href="https://www.jetbrains.com/community/opensource/#support" target="__blank">
<img src="https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.png?_gl=1*18f1z4q*_ga*MTI4MDYwODYzNy4xNjUyMzU3ODM3*_ga_9J976DJZ68*MTY2MTg3NDM2NC4xMi4xLjE2NjE4NzUxNTAuMC4wLjA.&_ga=2.85008921.1685901777.1661797034-1280608637.1652357837" width="250px" />
</a>

## Contributors

This project exists thanks to all the people who contribute. [[Contribute](CONTRIBUTING.md)].
<a href="https://github.com/saleem-hadad/larecipe/graphs/contributors"><img src="https://opencollective.com/larecipe/contributors.svg?width=890&button=false" /></a>

## License

This library is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details.
