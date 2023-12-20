# FSharpLunchNLearn

## Introduction

## Building this from scratch

### 1 - Initialize new F# Web App

```bash
dotnet new web -lang F# -o FSharpWebApp
```

### 2 - Configure project, add dependencies

Add Solution

```bash
dotnet new sln -n FSharpLunchNLearn
```

Add Project to Solution

```bash
dotnet sln add .\src\FSharpWebApp.fsproj
```

Add Falco

```bash
dotnet add package Falco
```

Setup entry point to use Falco and define some endpoints

```fsharp

[<EntryPoint>]
let main args =

    webHost args {

        endpoints [ get "/" (Response.ofPlainText "Hello F# World!") ]
    }

    0

```

## Creating our first module

Define some HTML

```fsharp
let html =
    Markup.Elem.html
        [ lang "en" ]
        [ Markup.Elem.head [] [ title [] [ raw "Sample App" ] ]
          body
              []
              [ main
                    []
                    [ h1 [] [ raw "Sample App" ]
                      Elem.p [] [ Text.rawf "%s %s" "Kyle" "McMaster" ]
                      ] ] ]
```

#

### Adding an Index Page

Define a local response using component HTML

```fsharp
get "/" (Response.ofHtml IndexPage.html)
```

Define a handler for the component and encapsulate the HTML to the index module 🧠

```fsharp
get "/" IndexPage.handleHtml
```

## Adding an API endpoint

```fsharp
get "/api/contributors" (Response.ofJson Domain.contributors) ]
```

## Resources

- [Falco Getting Started](https://www.falcoframework.com/docs/get-started.html)
