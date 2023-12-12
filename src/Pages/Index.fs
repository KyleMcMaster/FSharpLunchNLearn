namespace FSharpWebApp.Pages

module IndexPage =
    open Falco
    open Falco.Markup.Attr
    open Falco.Markup.Elem
    open Falco.Markup

    let appTitle = "Lunch-n-Learn App"
    let heading = "Contributors"

    let html =
        html
            [ lang "en" ]
            [ head [] [ title [] [ Text.raw appTitle ] ]
              body [] [ main [] [ h1 [] [ Text.raw heading ]; p [] [ Text.rawf "%s %s" "Kyle" "McMaster" ] ] ] ]

    let handleHtml: HttpHandler = Response.ofHtml html
