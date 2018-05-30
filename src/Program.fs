module Program

open Fable.Core

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
    let c = Exec ([|"foo"; "bar"|])
    printfn "Hello World from F#!: %A" c
    0 // return an integer exit code
