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

module SNetShell

open System;
open System.Linq;
open System.IO;
open NetSh;
open NetSh.Tools;
open NetSh.Extensions;

type SNetShell() =
    inherit NetShell()

    override this.ProcessCommand(command: string) =
        if command = ".." then
            base.ProcessCommand("cd ..");
        else
            base.ProcessCommand(command);

    override this.Help(spacecount: int) =
        printfn "";
        base.Help(spacecount);
        printfn "";

    override this.Prompt
        with get() = base.Prompt
        and set(value: string) =
            let mutable parts = value.Split(Path.DirectorySeparatorChar);
            let mutable npath = parts.First();
            for part in parts.Skip(1) do
                if part = ".." then
                    npath <- path.previous(npath);
                else
                    npath <- (npath + Path.DirectorySeparatorChar.ToString() + part);
            base.Prompt <- npath;
