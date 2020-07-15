//Copyright(c) 2020 Mertcan Davulcu
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

open System;
open System.Linq;
open System.Diagnostics;
open System.Text;
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
        if cmd.RemoveParameters("-") = "" = false then
            messager.error("'" + input + "' is not defined!");
        else
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
                    messager.error("'" + cparam + "' is not defined!");
        );
    shell.AddCmd("echo","Print message to screen.",fun (command: INetShellCommand) (input: string) ->
        let mutable message = input.RemoveNamespace();
        message.Println();
        );
    shell.AddCmd("processes","List processes.",fun (command: INetShellCommand) (input: string) ->
        if input.Equals("processes",StringComparison.CurrentCultureIgnoreCase) then
            let GetWS(spacecount: int) : string =
                let mutable builder = new StringBuilder();
                for _ in [ 1 .. spacecount ] do
                    builder <- builder.Append(" ");
                builder.ToString();

            let mutable processes = Process.GetProcesses();
            let mutable max = processes.Max(fun (x: Process) ->
                x.Id.ToString().Length) + 10;
            "ID".Print();
            GetWS(max - 2).Print();
            "Name\n".Println();
            for ``process`` in processes do
                ``process``.Id.Print();
                GetWS(max - ``process``.Id.ToString().Length).Print();
                ``process``.ProcessName.Println();
        else
            messager.error("'" + input + "' is not defined!");
        
        );
    shell.Loop();

    0;
