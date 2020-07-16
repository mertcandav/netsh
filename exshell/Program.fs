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
            shell.Prompt <- path.joinexists(shell.Prompt,cmd);
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
                    Directory.GetFiles(shell.Prompt).Println();
                else if param = "-d" then
                    Directory.GetDirectories(shell.Prompt).Println();
                else
                    messager.error("'" + cparam + "' is not defined!");
        );
    shell.AddCmd("echo","Print message to screen.",fun (command: INetShellCommand) (input: string) ->
        let mutable message = input.RemoveNamespace();
        message.Println();
        );
    shell.AddCmd("processes","List processes.",fun (command: INetShellCommand) (input: string) ->
        if input.Equals("processes",StringComparison.CurrentCultureIgnoreCase) then
            let mutable processes = Process.GetProcesses();
            let mutable max = processes.Max(fun (x: Process) ->
                x.Id.ToString().Length) + 10;
            "ID".Print(ConsoleColor.Cyan);
            str.getwhitespace(max - 2).Print();
            "Name\n".Println(ConsoleColor.Cyan);
            for ``process`` in processes do
                ``process``.Id.Print(ConsoleColor.White);
                str.getwhitespace(max - ``process``.Id.ToString().Length).Print();
                ``process``.ProcessName.Println(ConsoleColor.Gray);
        else
            messager.error("'" + input + "' is not defined!");
        );
    shell.AddCmd("sysinfo","Show system summary.",fun (command: INetShellCommand) (input: string) ->
        "Machine Name                        ".Print(ConsoleColor.White);
        Environment.MachineName.Println(ConsoleColor.Gray);
        "User Domain Name                    ".Print(ConsoleColor.White);
        Environment.UserDomainName.Println(ConsoleColor.Gray);
        "User Name                           ".Print(ConsoleColor.White);
        Environment.UserName.Println(ConsoleColor.Gray);
        "User Interactive                    ".Print(ConsoleColor.White);
        Environment.UserInteractive.Println(ConsoleColor.Gray);
        "Operating System Version            ".Print(ConsoleColor.White);
        Environment.OSVersion.Println(ConsoleColor.Gray);
        "Is 64-Bit Operating System          ".Print(ConsoleColor.White);
        Environment.Is64BitOperatingSystem.Println(ConsoleColor.Gray);
        "Is 64-Bit Processor                 ".Print(ConsoleColor.White);
        Environment.Is64BitProcess.Println(ConsoleColor.Gray);
        "Processor core count                ".Print(ConsoleColor.White);
        Environment.ProcessorCount.Println(ConsoleColor.Gray);
        "Memory Size(Mb)                     ".Print(ConsoleColor.White);
        Environment.SystemPageSize.Println(ConsoleColor.Gray);
        "Memory Size(Gb)                     ".Print(ConsoleColor.White);
        (Environment.SystemPageSize / 1024).Println(ConsoleColor.Gray);
        "Working Set                         ".Print(ConsoleColor.White);
        Environment.WorkingSet.Println(ConsoleColor.Gray);
        "System Directory                    ".Print(ConsoleColor.White);
        Environment.SystemDirectory.Println(ConsoleColor.Gray);
    );
    shell.AddCmd("mkdir","Create directory.",fun (command: INetShellCommand) (input: string) ->
        let mutable command = input.RemoveNamespace();
        if command = String.Empty then
            messager.error("'" + input + "' is not defined!");
        else
            let mutable _path = shell.Prompt;
            _path <- path.join(_path,command);
            if Directory.Exists(_path) then
                messager.error("Alrady exists this directory.");
            else
                let mutable info = Directory.CreateDirectory(_path);
                "Created '".Print(ConsoleColor.Green);
                info.Name.Print(ConsoleColor.White);
                "' directory successfully!".Println(ConsoleColor.Green);
    );
    shell.AddCmd("rmdir","Delete directory.",fun (command: INetShellCommand) (input: string) ->
        let mutable command = input.RemoveNamespace();
        if command = String.Empty then
            messager.error("'" + input + "' is not defined!");
        else
            let mutable _path = shell.Prompt;
            _path <- path.join(_path,command);
            if Directory.Exists(_path) then
                Directory.Delete(_path,true);
            "Deleted '".Print(ConsoleColor.Green);
            command.Print(ConsoleColor.White);
            "' directory successfully!".Println(ConsoleColor.Green);
    );
    shell.AddCmd("mkfile","Create file.",fun (command: INetShellCommand) (input: string) ->
        let mutable command = input.RemoveNamespace();
        if command = String.Empty then
            messager.error("'" + input + "' is not defined!");
        else
            let mutable _path = shell.Prompt;
            _path <- path.join(_path,command);
            if File.Exists(_path) then
                messager.error("Alrady exists this file.");
            else
                let mutable info = File.Create(_path);
                "Created '".Print(ConsoleColor.Green);
                command.Print(ConsoleColor.White);
                info.Dispose();
                "' file successfully!".Println(ConsoleColor.Green);
    );
    shell.AddCmd("rmfile","Delete file.",fun (command: INetShellCommand) (input: string) ->
        let mutable command = input.RemoveNamespace();
        if command = String.Empty then
            messager.error("'" + input + "' is not defined!");
        else
            let mutable _path = shell.Prompt;
            _path <- path.join(_path,command);
            if File.Exists(_path) then
                File.Delete(_path);
            "Deleted '".Print(ConsoleColor.Green);
            command.Print(ConsoleColor.White);
            "' file successfully!".Println(ConsoleColor.Green);
    );
    shell.AddCmd("print","Print content of file.",fun (command: INetShellCommand) (input: string) ->
        let mutable command = input.RemoveNamespace();
        if command = String.Empty then
            messager.error("'" + input + "' is not defined!");
        else
            let mutable _path = shell.Prompt;
            _path <- path.join(_path,command);
            if File.Exists(_path) then
                let mutable content = File.ReadAllText(_path);
                content.Println();
            else
                messager.error("Not exists this file.");
    );
    shell.AddCmd("exdir","Exists directory.",fun (command: INetShellCommand) (input: string) ->
        let mutable command = input.RemoveNamespace();
        if command = String.Empty then
            messager.error("'" + input + " is not defined!");
        else
            let mutable path = path.join(shell.Prompt,command);
            Directory.Exists(path).Println();
    );
    shell.Loop();

    0;
