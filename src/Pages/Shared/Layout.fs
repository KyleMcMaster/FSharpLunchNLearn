namespace FSharpWebApp.Pages.Shared

module Layout =
    open Falco.Markup.Elem
    open Falco.Markup

    let scripts: XmlNode list =
        [ Elem.script
              [ Attr.src "https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
                Attr.integrity "sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
                Attr.crossorigin "anonymous" ]
              [] ]

    let heading elems = head [] elems

    let layout pageName bodyContent =
        Falco.Markup.Elem.html
            [ Falco.Markup.Attr.lang "en" ]
            [ heading
                  [ Falco.Markup.Elem.title [] [ Falco.Markup.Text.raw pageName ]
                    link
                        [ Attr.rel "stylesheet"
                          Attr.href "https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
                          Attr.integrity "sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN"
                          Attr.crossorigin "anonymous" ] ]
              body [] (bodyContent @ scripts)
              footer [] [] ]

// Bootstrap CDN from https://github.com/twbs/examples/blob/main/starter/index.html
