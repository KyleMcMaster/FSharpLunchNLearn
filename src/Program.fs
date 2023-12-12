module FSharpWebbApp.Program

open Falco.HostBuilder
open Falco.Routing
open FSharpWebApp.Pages

// let html =
//     Markup.Elem.html
//         [ lang "en" ]
//         [ Markup.Elem.head [] [ title [] [ raw "Sample App" ] ]
//           body
//               []
//               [ main
//                     []
//                     [ h1 [] [ raw "Sample App" ]
//                       // Elem.p [] [ Text.rawf "%s %s" "Kyle" "McMaster" ]
//                       ] ] ]

[<EntryPoint>]
let main args =

    webHost args {

        use_static_files

        endpoints
            [
              //get "/" (Response.ofHtml IndexPage.html)
              get "/" IndexPage.handleHtml ]
    }

    0
