
module SNetShell

open System;
open NetSh;

type SNetShell() =
    inherit NetShell()

    override this.Help(spacecount: int) =
        printfn "";
        base.Help(spacecount);
        printfn "";
