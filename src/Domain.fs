namespace FSharpWebApp.Domain

module Domain =
    open System.ComponentModel.DataAnnotations

    [<CLIMutable>]
    type Status = // kind of like SmartEnum base class
        { Id: int; Name: string }

    [<CLIMutable>] // needed for EF Core
    type Contributor =
        { [<Key>]
          Id: int
          FullName: string
          Status: string }

    //[<CLIMutable>]
    //type ContributorStatus =
    //    |  Community
    //    |  Company
    //    |  NotSet

    //    member this.Id =
    //        match this with
    //        | Community -> 0
    //        | Company -> 1
    //        | NotSet -> 2

    //    member this.Name =
    //        match this with
    //        | Community -> "Community"
    //        | Company -> "Company"
    //        | NotSet -> "Not Set"

    let ContributorStatus: Status list =
        [ { Id = 0; Name = "Community" }
          { Id = 1; Name = "Company" }
          { Id = 2; Name = "Not Set" } ]

    let IdFromName name =
        ContributorStatus |> List.find (fun c -> c.Name = name) |> (fun c -> c.Id)
