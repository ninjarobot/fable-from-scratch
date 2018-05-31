module Program

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Pg

type Command =
| Script of string
| Exec of string array

[<Pojo>]
type Coordinate = {
    X : decimal
    Y : decimal
}

let average (coordinates:Coordinate list) =
    let intermediate =
        coordinates
        |> List.fold
            (fun acc coord -> { X = acc.X + coord.X; Y = acc.Y + coord.Y })
            { X=0M;Y=0M }
    {
        X = intermediate.X / decimal coordinates.Length
        Y = intermediate.Y / decimal coordinates.Length
    }

[<EntryPoint>]
let main argv =
    [
        { X=90M; Y=15M }
        { X=95M; Y=107M }
        { X=93M; Y=182M }
        { X=81M; Y=37M }
        { X=103M; Y=38M }
        { X=72M; Y=92M }
        { X=71M; Y=92M }
    ]
    |> average
    |> printfn "Average: %A"
    let clientConfig = createEmpty<Pg.ClientConfig>
    clientConfig.database <- "postgres" |> Some
    let client = Pg.Client.Create(clientConfig)
    client.connect()
    let query = createEmpty<Pg.QueryConfig>
    query.text <- "SELECT datname AS database_name, pg_size_pretty(pg_database_size(datname)) AS size FROM pg_database;"
    let result = client.query (query, fun err res -> printfn "%A" err; client.``end``(); printfn "%A" res.rows )
    let c = Exec ([|"foo"; "bar"|])
    printfn "Hello World from F#!: %A" c
    0 // return an integer exit code
