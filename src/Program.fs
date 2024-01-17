namespace FSharpWebApp

open EntityFrameworkCore.FSharp.Extensions
open Falco.HostBuilder
open Falco.Routing
open FSharpWebApp.Endpoints.Contributors
open FSharpWebApp.Pages.ContributorsPage
open FSharpWebApp.Pages.IndexPage
open Microsoft.AspNetCore.Builder
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.DependencyInjection
open FSharpWebApp.Infrastructure.Infrastructure
open Falco

module Program =

    let createAndSeedDatabase (builder: IApplicationBuilder) =
        use serviceScope = builder.ApplicationServices.CreateScope()
        let db = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>()
        seedDbContext db |> ignore
        builder

    let addEntityFramework (services: IServiceCollection) =
        services.AddDbContext<AppDbContext>(fun options ->
            options.UseSqlite("Data Source=\".\\FSharpWebApp.sqlite\"") |> ignore
            options.UseFSharpTypes() |> ignore)

    [<EntryPoint>]
    let main args =

        // https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/computation-expressions
        webHost args {

            add_service (fun services ->
                services.AddDbContext<AppDbContext>(fun options ->
                    options.UseSqlite("Data Source=\".\\FSharpWebApp.sqlite\"") |> ignore
                    options.UseFSharpTypes() |> ignore))

            // add_service addEntityFramework

            use_if FalcoExtensions.IsDevelopment createAndSeedDatabase

            endpoints
                [

                  get "/" IndexPage.handleHtml

                  get "/contributors" ContributorsPage.handleHtml

                  post "api/contributors" ContributorEndpoints.handler

                  ]
        }

        0
