﻿//Copyright(c) 2020 Mertcan Davulcu
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

namespace fstest

open System;
open System.Threading;
open System.Threading.Tasks;
open System.Collections;
open System.Collections.Generic;
open NetSh;
open NetSh.Extensions;
open NetSh.Tools;

module main =
    let beep() =
        Console.Beep();

    let beepbeep() =
        Console.Beep();
        Console.Beep();

    let listargs(cmd: string) =
        let args = cmd.GetParameters("-");
        for arg in args do
            arg.Println();

    let BeforePrompt(e: EventArgs) =
        Console.WriteLine(e.GetHashCode());

    let print(command: INetShellCommand,input: string) =
        printf "";

    [<EntryPoint>]
    let main argv =
        printfn "F# test application";
        
        //let mutable command = new NetShellCommand(String.Empty,String.Empty);
        //command.Command <- "Exit";

        //let mutable netshact = new NetShellAction(new Action(beep));
        //netshact.GetAction().Invoke();
        //let mutable act = netshact.GetAction();
        //act <- new Action(beepbeep);
        //netshact.GetAction().Invoke();

        //let coll = List<String>(["Item0";"Item1";"Item2";"Item3"]);
        //coll.Write();
        //coll.WriteLine();

        //let mystr = "Test string value";
        //mystr.Write();
        //mystr.WriteLine();
        //mystr.WriteChars();
        //mystr.WriteLineChars();
        //GenericExtensions.Write(mystr);
        //GenericExtensions.WriteLine(mystr);

        //let coll = [1..10];
        //GenericExtensions.Write(coll);
        //GenericExtensions.WriteLine(coll);

        //let mutable shell = new NetShell();
        //shell.Prompt <- "SHELL$ ";
        //shell.IgnoreCase <- true;
        //shell.Mode <- NetShellMode.Namespace;
        //shell.AddCmd("BEEP","Beep console.",new Action(beep));
        //shell.AddCmd("BEEPBEEP","Beep beep console.",new Action(beepbeep));
        //shell.AddCmd("foo","Beep console.",new Action(beep));
        //shell.AddCmd("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","Beep console.",new Action(beep));
        //shell.Loop();

        //let mutable str = "beep -two -owo-mon -foo";
        //let args = str.GetParameters("-");
        //for arg in args do
        //    arg.WriteLine();

        //let mutable str = "beep -foo -bar -let";
        //str.RemoveParameters("-").WriteLine();

        //let mutable str = "TestNamespace -arg0 -arg1 -arg2";
        //"test".RemoveNamespace().WriteLine();
        //"testest".GetNamespace().WriteLine();
        //str.WriteLine();
        //str.RemoveNamespace().WriteLine();

        //let mutable shell = new NetShell();
        //shell.Prompt <- "MyShell$";
        //shell.BeforePrompt.Add(BeforePrompt);
        //shell.Loop();

        //Printer.Print("Print Test");
        //Printer.Println("Println Test");
        
        //Printer.Print("Print colored test",ConsoleColor.Yellow);
        //Printer.Println("Println colored test",ConsoleColor.Green);
        //Printer.Println("Color test");

        //"Test".Println();
        //"Test colored".Println(ConsoleColor.Green);

        //let mutable shell = new NetShell();
        //shell.Prompt <- "Test$ ";
        //shell.Loop();

        //let mutable shell = new NetShell();
        //shell.Prompt <- "~~$ ";
        //shell.Mode <- NetShellMode.Namespace;
        //shell.AddCmd("print","Print message to screen.",fun(command: INetShellCommand) (input: string) ->
        //    printf ""
        //    );
        //shell.Loop();

        0;
