namespace FSharpWebApp.Pages.IndexPage

module IndexPage =
    open Falco
    open Falco.Markup.Attr
    open Falco.Markup.Elem
    open Falco.Markup.Text

    let appTitle = "Lunch -> n -> Learn App"
    let pageTitle = "Index"

    let html =
        html
            [ lang "en" ]
            [ head [] [ title [] [ raw appTitle ] ]
              body
                  []
                  [ main
                        []
                        [ h1 [] [ raw pageTitle ]
                          p [] [ rawf "Hello my name <- %s %s" "Kyle" "McMaster" ] ] ] ]

    let handleHtml: HttpHandler = Response.ofHtml html
