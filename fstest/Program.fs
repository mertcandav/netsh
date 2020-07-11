namespace fstest

open System;
open System.Threading;
open System.Collections;
open System.Collections.Generic;
open NetSh;
open NetSh.Extensions;

module main =
    let beep() =
        Console.Beep();

    let beepbeep() =
        Console.Beep();
        Console.Beep();

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

        //let coll = new List<String>(["Item0";"Item1";"Item2";"Item3"]);
        //coll.Write();
        //coll.WriteLine();

        0;
