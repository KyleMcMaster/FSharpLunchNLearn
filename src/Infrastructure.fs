namespace FSharpWebApp.Infrastructure

open Microsoft.EntityFrameworkCore
open FSharpWebApp.Domain.Domain

module Infrastructure =

    module SeedData =
        let private contributors =
            [ { id = 1
                name = "Kyle McMaster"
                status = getIdByName ContributorStatus "Community" }
              { id = 2
                name = "John Doe"
                status = getIdByName ContributorStatus "Not Set" } ]

        let Contributors = contributors

    type AppDbContext(options: DbContextOptions<AppDbContext>) =
        inherit DbContext(options)

        [<DefaultValue>]
        val mutable private _contributors: DbSet<Contributor>

        member this.Contributors
            with get () = this._contributors
            and set v = this._contributors <- v

    let seedDbContext (context: AppDbContext) =
        context.Database.EnsureDeleted() |> ignore
        context.Database.EnsureCreated() |> ignore
        context.Contributors.AddRange SeedData.Contributors
        context.SaveChanges()
