open System;
open System.Collections;
open System.Collections.Generic;
open System.IO;
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
    shell.AddCmd("cd","Manage current path.",fun (command: INetShellCommand) (input: string) ->
        let mutable cmd = input.RemoveNamespace().Trim();
        if cmd = ".." then
            shell.Prompt <- path.previous(shell.Prompt);
        else if cmd = "" then
            "Command is not defined!".Println(ConsoleColor.Red);
        else
            shell.Prompt <- path.join(shell.Prompt,cmd);
        );
    shell.AddCmd("ls","List this directory.",fun (command: INetShellCommand) (input: string) ->
        let mutable cmd = input.RemoveNamespace();
        if input.ToLower() = "ls" then
            cmd <- "ls -f -d";
        let mutable parameters = cmd.GetParameters("-");
        for cparam in parameters do
            let mutable param = cparam.Trim().ToLower();
            if param = "-f" then
                Directory.GetFiles(shell.Prompt).WriteLine();
            else if param = "-d" then
                Directory.GetDirectories(shell.Prompt).WriteLine();
            else
                printfn "'%s' is not defined!" cparam;
        );
    shell.AddCmd("echo","Print message to screen.",fun (command: INetShellCommand) (input: string) ->
        let mutable message = input.RemoveNamespace();
        message.Println();
        );
    shell.Loop();

    0;
