namespace FSharpWebApp.Pages

module IndexPage =
    open Falco.Markup

    // Template
    let page (title: string) =
        Elem.html [ Attr.lang "en" ] [ Elem.head [] [ Elem.title [] [ Text.raw title ] ]; Elem.body [] [] ]
