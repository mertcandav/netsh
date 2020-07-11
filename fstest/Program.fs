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

        0;
