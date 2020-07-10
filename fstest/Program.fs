namespace fstest

open System
open NetSh

module main =
    [<EntryPoint>]
    let main argv =
        printfn "F# test application"
        let mutable command = new NetShellCommand(String.Empty,String.Empty)
        command.Command <- "Exit"
        0
