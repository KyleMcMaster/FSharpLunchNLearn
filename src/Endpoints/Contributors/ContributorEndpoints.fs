namespace FSharpWebApp.Endpoints.Contributors

module ContributorEndpoints =
    open Falco
    open FSharpWebApp.Infrastructure.Infrastructure
    open System.Text.Json
    open FSharpWebApp.Domain.Domain
    open Microsoft.AspNetCore.Http

    type ContributorCreateRequest = { FullName: string; Status: int }
    type ValidatedContributorCreateRequest = { FullName: string; Status: string }

    type ErrorMessage = string

    type ValidationResult =
        | Ok of ValidatedContributorCreateRequest
        | Error of ErrorMessage

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

    let validateRequest (request: ContributorCreateRequest) : ValidationResult =
        let status = validateStatus request.Status

        match status with
        | Some s ->
            Ok
                { FullName = request.FullName
                  Status = s }
        | None -> Error "Bad Request"

    let createContributor (db: AppDbContext) r =
        let contributor: Contributor =
            { Id = 0
              FullName = r.FullName
              Status = r.Status }

        db.Contributors.Add contributor |> ignore
        db.SaveChanges() |> ignore
        contributor

    let handleRequest (db: AppDbContext) (ctx: HttpContext) =
        let validatedRequest = ctx |> getRequestFromJson |> validateRequest

        let result =
            match validatedRequest with
            | Ok validatedContributor ->
                let contributor = createContributor db validatedContributor
                Response.ofJson contributor
            | Error errorMessage -> (Response.withStatusCode 400 >> Response.ofPlainText errorMessage)

        result ctx

    let handler: HttpHandler =
        Services.inject<AppDbContext> (fun db -> (fun ctx -> handleRequest db ctx))

// let create2: HttpHandler =
//     Services.inject<AppDbContext> (fun db ->
//         fun ctx ->
//             task {
//                 // Deserialize the request
//                 let createRequest =
//                     Request.getBodyString ctx
//                     |> Async.AwaitTask
//                     |> Async.RunSynchronously
//                     |> JsonSerializer.Deserialize<ContributorCreateRequest>

//                 // Validate the request
//                 let validatedstatus =
//                     match createRequest.Status with
//                     | 0 -> Some "Community"
//                     | 1 -> Some "Company"
//                     | 2 -> Some "Not Set"
//                     | _ -> None

//                 let validatedRequest =
//                     match validatedstatus with
//                     | Some s ->
//                         Some
//                             { FullName = createRequest.FullName
//                               Status = s }
//                     | None -> None

//                 let result =
//                     match validatedRequest with
//                     | Some r ->
//                         let contributor: Contributor =
//                             { Id = 0
//                               FullName = r.FullName
//                               Status = r.Status }

//                         db.Contributors.Add contributor |> ignore
//                         db.SaveChanges() |> ignore
//                         Response.ofJson (JsonSerializer.Serialize contributor)
//                     | None -> (Response.withStatusCode 400 >> Response.ofPlainText "BadRequest")

//                 return result ctx
//             })
