namespace FSharpWebApp.Pages

module IndexPage =
    open Falco
    open Falco.Markup.Attr
    open Falco.Markup.Elem
    open Falco.Markup.Text

    let appTitle = "Lunch-n-Learn App"
    let heading = "Contributors"

    let html =
        html
            [ lang "en" ]
            [ head [] [ title [] [ raw appTitle ] ]
              body [] [ main [] [ h1 [] [ raw heading ]; p [] [ rawf "%s %s" "Kyle" "McMaster" ] ] ] ]

    let handleHtml: HttpHandler = Response.ofHtml html
