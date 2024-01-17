namespace FSharpWebApp.Pages.ContributorsPage

open Falco
open Falco.Markup
open FSharpWebApp.Domain.Domain
open FSharpWebApp.Infrastructure.Infrastructure
open FSharpWebApp.Pages.Shared
open EntityFrameworkCore.FSharp.DbContextHelpers

module ContributorsPage =

    let title = "Contributors Component"
    let divider = Elem.hr [ Attr.class' "divider" ]

    let contributorHtml contributor =
        Elem.div
            []
            [ Elem.h2 [] [ Text.raw (sprintf "%s %s" "Full Name: " contributor.FullName) ]
              Elem.br []
              Elem.p [] [ Text.raw (sprintf "%s %A" "Id: " contributor.Id) ]
              Elem.p [] [ Text.raw (sprintf "%s %s" "Status: " contributor.Status) ]
              Elem.br [] ]

    let contributorsListHtml contributors =
        [ Elem.h1 [] [ Text.raw title ]
          divider
          Elem.div [] (contributors |> List.map contributorHtml) ]

    let contributorPage (contributors) : XmlNode list = contributorsListHtml contributors

    let handleHtml: HttpHandler =
        Services.inject<AppDbContext> (fun db ->
            fun ctx ->
                task {
                    let! contributors = db.Contributors |> toListAsync
                    return Response.ofHtml (Layout.layout title (contributorPage contributors)) ctx
                })
