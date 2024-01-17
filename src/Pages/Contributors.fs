namespace FSharpWebApp.Pages.ContributorsPage

open Falco
open Falco.Markup
open FSharpWebApp.Domain.Domain
open FSharpWebApp.Infrastructure.Infrastructure
open FSharpWebApp.Pages.Shared
open EntityFrameworkCore.FSharp.DbContextHelpers

module ContributorsPage =

    let title = "Contributors Component"

    let contributorHtml contributor =
        Elem.div
            []
            [ Elem.h2 [] [ Text.raw contributor.FullName ]
              Elem.p [] [ Text.raw (contributor.Id.ToString()) ]
              Elem.p [] [ Text.raw contributor.Status ] ]

    let contributorsListHtml contributors =
        [ Elem.h1 [] [ Text.raw title ]
          Elem.div [] (contributors |> List.map contributorHtml) ]

    let contributorPage (contributors) : XmlNode list = contributorsListHtml contributors

    let handleHtml: HttpHandler =
        Services.inject<AppDbContext> (fun db ->
            fun ctx ->
                task {
                    let! contributors = db.Contributors |> toListAsync
                    return Response.ofHtml (Layout.layout title (contributorPage contributors)) ctx
                })
