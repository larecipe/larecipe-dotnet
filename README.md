<h6 align="center">
    <img src="https://larecipe.saleem.dev/images/logo.svg"/>
</h6>

<h1 align="center">
    LaRecipe (very early stage) | .Net ❤️
</h1>


<h6 align="center">
    Write and ship beautiful documentation with your dotnet projects using MarkDown
</h6>

<p align="center">
<a href="https://github.com/larecipe/larecipe-dotnet"><img src="https://img.shields.io/packagist/dt/binarytorch/larecipe.svg" alt="License"></a>
<a title="MadeWithVueJs.com Shield" href="https://madewithvuejs.com/p/larecipe/shield-link"> <img src="https://madewithvuejs.com/storage/repo-shields/1087-shield.svg"/></a>
<a href="https://github.com/larecipe/larecipe-dotnet"><img src="https://img.shields.io/github/release/larecipe/larecipe-dotnet.svg" alt="Release"></a>
<a href="https://github.com/larecipe/larecipe-dotnet"><img src="https://poser.pugx.org/laravel/framework/license.svg" alt="License"></a>
 <a href="#sponsors" alt="Sponsors on Open Collective"><img src="https://opencollective.com/larecipe/sponsors/badge.svg" /></a> 
</p>
<br/><br/>

**LaRecipe** is simply a code-driven package that provides an easy way to create beautiful documentation for your product or application inside your **.Net** apps.

> Note: LaRecipe was originally built to work with Laravel framework and now we're expanding the scope to integrate it with dotnet core applications. Check out the [Laravel integration version](https://github.com/saleem-hadad/larecipe)

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
builder.Services.AddLaRecipe(); // <- add LaRecipe

...
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    ...
    app.UseLaRecipe(); // <- Use in development only, but feel free to use it in other/all environments.
}
```


3. Add the markdown documentation files, you can use the LaRecipe CLI to help you with that or you can create them manually if you like:

> Check the [provided example](https://github.com/larecipe/larecipe-dotnet/tree/main/tests/LaRecipe.Example/Documentation) for more information


```
# run these commands in the root of your application
dotnet new tool-manifest # if you are setting up this repo
dotnet tool install --local LaRecipe.Cli --version 0.0.4-alpha
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

## Contributors

This project exists thanks to all the people who contribute. [[Contribute](CONTRIBUTING.md)].
<a href="https://github.com/saleem-hadad/larecipe/graphs/contributors"><img src="https://opencollective.com/larecipe/contributors.svg?width=890&button=false" /></a>

## License

This library is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details.
