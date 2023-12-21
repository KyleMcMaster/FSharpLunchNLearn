namespace FSharpWebApp.Pages.ContributorsPage

module ContributorsPage =
    open Falco
    open Falco.Markup
    open FSharpWebApp.Domain.Domain

    let contributorListHtml contributors =
        contributors
        |> List.map (fun c ->
            Elem.div
                []
                [ Elem.h2 [] [ Text.raw c.name ]
                  Elem.p [] [ Text.raw (sprintf "%A" c.id) ]
                  Elem.p [] [ Text.raw (sprintf "%A" c.status) ] ])

    let contributorHtml =
        [ Elem.h1 [] [ Text.raw "Contributors" ] ] @ contributorListHtml contributors

    let handleHtml: HttpHandler =
        Response.ofHtml (Elem.html [] [ Elem.body [] [ Elem.main [] contributorHtml ] ])
