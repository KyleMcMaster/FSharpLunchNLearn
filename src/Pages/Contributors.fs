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
            [ Elem.h2 [] [ Text.raw contributor.name ]
              Elem.p [] [ Text.raw (contributor.id.ToString()) ]
              Elem.p [] [ Text.raw (sprintf "%A" contributor.status) ] ]

    let contributorsListHtml contributors =
        [ Elem.h1 [] [ Text.raw title ]
          Elem.div [] (contributors |> List.map contributorHtml) ]

    // TODO - this is a bit of a hack, but it works for now
    let contributorPage (contributors): XmlNode list = contributorsListHtml contributors

    let handleHtml: HttpHandler =
      Services.inject<AppDbContext> (fun db ->
      fun ctx ->
        task {
          let! contributors = db.Contributors |> toListAsync
          return Response.ofHtml (Layout.layout title (contributorPage contributors)) ctx
        })