open System;
open System.Collections;
open System.Collections.Generic;
open NetSh;
open NetSh.Tools;
open NetSh.Extensions;
open SNetShell;

let mutable shell = new SNetShell();

let AfterPrompt(e: EventArgs) =
    "$ ".Print(ConsoleColor.DarkYellow);

[<EntryPoint>]
let main(argv) =
    printfn "Example Shell of NetShell";
    shell.Prompt <- __SOURCE_DIRECTORY__;
    shell.AfterPrompt.Add(AfterPrompt);
    shell.Loop();

    0;
