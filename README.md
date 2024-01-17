# FSharpLunchNLearn

## Introduction

- F# is a functional programming language that can be used to create .NET applications

## Goals / Motivation

- Learn F# by building a web app from scratch
- Interested more on the App Dev side of F# and less on Domain Modeling / Functional Programming in F# (lots of resources for this)
- [F# Web Dev](https://learn.microsoft.com/en-us/dotnet/fsharp/scenarios/web-development)

## Why F#?

- Looking to learn a new language while still building my understanding of DDD and .NET
- Can utilize the .NET ecosystem which I already am familiar with
- Functional Programming is a different way of thinking about problems. Learn different set of best practices and patterns
- A lot of the concepts in F# are being ported to C# (Pattern Matching, Records, etc) so deepen C# understanding as well
- Definitely not learning VB.NET 💀
- Have fun! 🎉

## Commentary on Socials and Community

- Small but active
- Niche enthusiast subject or passion project for most
- F# has a steep learning curve which is representative of the community in my experience, few intermediate F# resources compared to advanced resources

### Who I follow or have learned from

- [Don Syme](https://github.com/dsyme)
- [Isaac Abraham](https://www.manning.com/books/get-programming-with-f-sharp)
- [Pim Brouwers](https://github.com/pimbrouwers)
- [Scott Wlaschin](https://fsharpforfunandprofit.com/)
- [Ian Russel](https://leanpub.com/essential-fsharp)

## Tooling

- [Visual Studio](https://visualstudio.com/) or
- [Ionide F#](https://ionide.io/) + [Visual Studio Code](https://code.visualstudio.com/)
- [Fantomas linting](https://github.com/fsprojects/fantomas)
- [FsAutoComplete](https://github.com/fsharp/FsAutoComplete)

## Time to look at some code!

### Domain Modeling Made Functional

Open in VS, look at the code, run the tests

## Falco

### 1 - Initialize new F# Web App using ASP.NET Core

Create this to show a resemblance to minimal APIs

```bash
dotnet new web -lang F# -o FSharpWebApp
```

Add Falco dependencies and dive in!

- Program entry point
- Simple Index Page
- Setup Entity Framework and seed Sqlite DB
- More complex Contributors Page with create endpoint

## Future takeaways and next steps

- Type Unions with Entity Framework
- Donald
- F# with bare metal ASP.NET Core
- F# with Azure Functions 👀

## Resources

- [Why F#?](https://fsharpforfunandprofit.com/why-use-fsharp/)
- [Domain Modeling Made Functional](https://pragprog.com/titles/swdddf/domain-modeling-made-functional/)
- [Domain Modeling Made Functional - Code](https://github.com/swlaschin/DomainModelingMadeFunctional/blob/master/src/OrderTaking/PlaceOrder.Api.fs)
- [F# reference](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/keyword-reference)
- [Falco Getting Started](https://www.falcoframework.com/docs/get-started.html)
- [Falco Markup intro](https://github.com/pimbrouwers/Falco/blob/master/documentation/markup.md)
- [Donald](https://github.com/pimbrouwers/Donald)
