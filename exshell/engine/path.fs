module path

open System;
open System.IO;
open System.Text.RegularExpressions;
open NetSh.Tools;

let previous(path: string) : string =
    let pattern = new Regex("\\|/");
    let mutable path = path;
    path <- pattern.Replace(path,Path.DirectorySeparatorChar.ToString());
    let mutable index = path.LastIndexOf(Path.DirectorySeparatorChar);
    if index > -1 then
        path <- path.Substring(0,index);
    path;

let join(path: string,name: string) =
    let mutable npath = Path.Combine(path,name);
    if Directory.Exists(npath) = false then
        "Directory is not exists this name!".Println(ConsoleColor.Red);
        path;
    else
        npath;
