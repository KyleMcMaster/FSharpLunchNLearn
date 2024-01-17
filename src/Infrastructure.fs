namespace FSharpWebApp.Infrastructure

open Microsoft.EntityFrameworkCore
open FSharpWebApp.Domain.Domain

module Infrastructure =

    module SeedData =
        let private contributors =
            [ { Id = 1
                FullName = "Kyle McMaster"
                Status = "Community" }
              { Id = 2
                FullName = "John Doe"
                Status = "Company" } ]

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
