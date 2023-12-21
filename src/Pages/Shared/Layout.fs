namespace FSharpWebApp.Pages.Shared

module Layout =
    open Falco.Markup.Elem

    let head elems = head [] elems

    let layout pageName bodyContent =
        Falco.Markup.Elem.html
            [ Falco.Markup.Attr.lang "en" ]
            [ head [ Falco.Markup.Elem.title [] [ Falco.Markup.Text.raw pageName ] ]
              body [] bodyContent
              footer [] [] ]
