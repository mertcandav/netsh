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

module path

open System;
open System.Linq;
open System.IO;
open System.Text.RegularExpressions;
open NetSh.Extensions;
open NetSh.Tools;

let format(path: string) : string =
    let mutable pattern = new Regex("\\\\|/",RegexOptions.IgnoreCase ||| RegexOptions.Singleline);
    let mutable npath = pattern.Replace(path,Path.DirectorySeparatorChar.ToString());
    npath;

let previous(path: string) : string =
    let mutable path = path;
    path <- format(path);
    let mutable index = path.LastIndexOf(Path.DirectorySeparatorChar);
    if index > -1 then
        path <- path.Substring(0,index);
    path;

let join(path: string,name: string) =
    let mutable npath = Path.Combine(path,name);
    npath <- format(npath);
    if Directory.Exists(npath) = false then
        "Directory is not exists this path!".Println(ConsoleColor.Red);
        path;
    else
        npath;
