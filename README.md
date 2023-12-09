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

## Resources

* [Falco Getting Started](https://www.falcoframework.com/docs/get-started.html)