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
    shell.Mode <- NetShellMode.Namespace;
    shell.Prompt <- __SOURCE_DIRECTORY__;
    shell.AfterPrompt.Add(AfterPrompt);
    shell.AddCmd("cd","Manage current path.",fun (command:INetShellCommand) (input:string) ->
        let mutable cmd = input.RemoveNamespace().Trim();
        if cmd = ".." then
            shell.Prompt <- path.previous(shell.Prompt);
        else if cmd = "" then
            "Command is not defined!".Println(ConsoleColor.Red);
        else
            shell.Prompt <- path.join(shell.Prompt,cmd);
        );
    shell.Loop();

    0;
