namespace FSharpWebApp.Endpoints.Contributors

module ContributorEndpoints =
    open Falco
    open FSharpWebApp.Infrastructure.Infrastructure
    open System.Text.Json
    open FSharpWebApp.Domain.Domain
    open Microsoft.AspNetCore.Http

    type ContributorCreateRequest = { FullName: string; Status: int }
    type ValidatedContributorCreateRequest = { FullName: string; Status: string }

    let getRequestFromJson (ctx: HttpContext) =
        Request.getBodyString ctx
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> JsonSerializer.Deserialize<ContributorCreateRequest>

    let validateStatus (status: int) =
        match status with
        | 0 -> Some "Community"
        | 1 -> Some "Company"
        | 2 -> Some "Not Set"
        | _ -> None

    let validateRequest (request: ContributorCreateRequest) : Option<ValidatedContributorCreateRequest> =
        let status = validateStatus request.Status

        match status with
        | Some s ->
            Some
                { FullName = request.FullName
                  Status = s }
        | None -> None

    let createContributor (db: AppDbContext) r =
        let contributor: Contributor =
            { Id = 0
              FullName = r.FullName
              Status = FromName r.Status }

        db.Contributors.Add contributor |> ignore
        db.SaveChanges() |> ignore

        contributor

    let handleRequest (db: AppDbContext) (ctx: HttpContext) =
        let createRequest = getRequestFromJson ctx

        let validatedRequest = validateRequest createRequest

        let result =
            match validatedRequest with
            | Some req ->
                let contributor = createContributor db req
                Response.ofJson contributor
            | None -> (Response.withStatusCode 400 >> Response.ofPlainText "Bad Request")

        result ctx

    let handler: HttpHandler =
        Services.inject<AppDbContext> (fun db -> (fun ctx -> handleRequest db ctx))

// let create2: HttpHandler =
//     Services.inject<AppDbContext> (fun db ->
//         fun ctx ->
//             task {
//                 let createRequest =
//                     Request.getBodyString ctx
//                     |> Async.AwaitTask
//                     |> Async.RunSynchronously
//                     |> JsonSerializer.Deserialize<ContributorCreateRequest>

//                 let validatedRequest = validateRequest createRequest

//                 let result =
//                     match validatedRequest with
//                     | Some r ->
//                         let contributor: Contributor =
//                             { Id = 0
//                               FullName = r.FullName
//                               Status = FromName r.Status }

//                         db.Contributors.Add contributor |> ignore
//                         db.SaveChanges() |> ignore
//                         Response.ofJson (JsonSerializer.Serialize contributor)
//                     | None -> (Response.withStatusCode 400 >> Response.ofPlainText "BadRequest")

//                 return result ctx
//             })
