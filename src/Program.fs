module FSharpWebbApp.Program

open Falco.HostBuilder
open Falco.Routing
open FSharpWebApp.Pages.ContributorsPage
open FSharpWebApp.Pages.IndexPage
// open Falco
// open FSharpWebApp.Domain



[<EntryPoint>]
let main args =

    webHost args {

        use_static_files

        endpoints
            [

              get "/" IndexPage.handleHtml

              get "/Contributors" ContributorsPage.handleHtml

              ]
    }

    0
