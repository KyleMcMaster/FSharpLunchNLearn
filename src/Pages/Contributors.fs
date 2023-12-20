namespace FSharpWebApp.Pages.ContributorsPage

module ContributorsPage =
    open Falco
    open Falco.Markup

    let handleHtml: HttpHandler =
        Response.ofHtml (Elem.html [] [ Elem.body [] [ Elem.main [] [ Elem.h1 [] [ Text.raw "Contributors" ] ] ] ])
