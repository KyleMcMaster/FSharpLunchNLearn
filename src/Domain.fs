namespace FSharpWebApp.Domain

module Domain =
    type ContributorStatus =
        | Community
        | Company
        | NotSet

    type Contributor =
        { id: int
          name: string
          status: ContributorStatus }

    let private contributors =
        [ { id = 1
            name = "Kyle McMaster"
            status = Company }
          { id = 2
            name = "John Doe"
            status = Community } ]

    let getContributors () = contributors

// let getContributorById id =
//     contributors |> List.tryFind (fun c -> c.id = id)
