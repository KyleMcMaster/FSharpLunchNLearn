open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open FSharpWebApp.Pages

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()

    app.MapGet("/", Func<string>(fun () -> "Hello World!")) |> ignore

    // app.MapGet("/index", Func<string>(fun () -> IndexPage.page "Hello Index!"))
    // |> ignore

    app.Run()

    0 // Exit code
