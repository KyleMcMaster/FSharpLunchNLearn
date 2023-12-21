namespace FSharpWebApp.Pages.ContributorsPage

module ContributorsPage =
    open Falco
    open Falco.Markup
    open FSharpWebApp.Domain.Domain
    open FSharpWebApp.Pages.Shared

    let title = "Contributors Component"

    let contributorHtml contributor =
        Elem.div
            []
            [ Elem.h2 [] [ Text.raw contributor.name ]
              Elem.p [] [ Text.raw (sprintf "%A" contributor.id) ]
              Elem.p [] [ Text.raw (sprintf "%A" contributor.status) ] ]

    let contributorsListHtml contributors =
        [ Elem.h1 [] [ Text.raw title ]
          Elem.div [] (contributors |> List.map contributorHtml) ]

    // TODO - this is a bit of a hack, but it works for now
    let contributorPage = (getContributors >> contributorsListHtml) ()

    let handleHtml: HttpHandler = Response.ofHtml (Layout.layout title contributorPage)
