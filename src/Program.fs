namespace FSharpWebApp

open EntityFrameworkCore.FSharp.Extensions
open Falco.HostBuilder
open Falco.Routing
open FSharpWebApp.Pages.ContributorsPage
open FSharpWebApp.Pages.IndexPage
open Microsoft.AspNetCore.Builder
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.DependencyInjection
open FSharpWebApp.Infrastructure.Infrastructure
open Falco

module Program = 

    let ensureDatabaseCreatedAndReset (builder: IApplicationBuilder) =
        use serviceScope = builder.ApplicationServices.CreateScope()
        let db = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>()
        printfn "Contributors inserted: %d " (seedDbContext db)
        builder

    [<EntryPoint>]
    let main args =

        webHost args {

            add_service (fun services ->
                services.AddDbContext<AppDbContext>(fun options ->
                    options.UseSqlite("Data Source=\".\\FSharpWebApp.sqlite\"") |> ignore
                    options.UseFSharpTypes() |> ignore))

            use_if FalcoExtensions.IsDevelopment ensureDatabaseCreatedAndReset

            use_static_files

            endpoints
                [

                  get "/" IndexPage.handleHtml

                  get "/Contributors" ContributorsPage.handleHtml

                  ]
        }

        0
