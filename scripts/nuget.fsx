#!/usr/bin/env fsharpi

open System
open System.IO
open System.Linq

#r "System.Configuration"
#load "../fsx/InfraLib/Misc.fs"
#load "../fsx/InfraLib/Process.fs"
#load "../fsx/InfraLib/Network.fs"
open FSX.Infrastructure
open Process

let PackAndMaybeUpload (packageName: string) =
    let argsPassedToThisScript = Misc.FsxArguments()
    if argsPassedToThisScript.Length <> 1 then
        Console.WriteLine "NUGET_API_KEY not passed to script, skipping upload..."
    else
        let nugetApiKey = argsPassedToThisScript.First()
        let githubRef = Environment.GetEnvironmentVariable "GITHUB_REF"
// Had to disable this due to developing in a branch
//        if githubRef <> "refs/heads/master" then
//            Console.WriteLine "Branch different than master, skipping upload..."
//        else
        let defaultNugetFeedUrl = "https://api.nuget.org/v3/index.json"
        let nugetPushCmd =
            {
                Command = "dotnet"
                Arguments = sprintf "nuget push Output\*.nupkg -k %s -s %s"
                                    nugetApiKey defaultNugetFeedUrl
            }
        Console.WriteLine "Pushing package..."
        Process.SafeExecute (nugetPushCmd, Echo.All) |> ignore
        Console.WriteLine "Pushing completed!"


Console.WriteLine "Packaging..."
PackAndMaybeUpload "Xamarin.Essentials"
