// Weitere Informationen zu F# finden Sie unter http://fsharp.org. Im Projekt "F#-Tutorial" finden Sie
// einen Leitfaden zum Programmieren in F#.
#load "Enums.fs"
#load "Core.fs"
open OpenCL
open System
// Skriptcode für die Bibliothek hier definieren
// General Tests

let platforms = CL.getPlatforms ()

let mutable count = 0UL
let mutable res = CL.clGetPlatformInfo(platforms.[0], PlatformInfo.NAME, UInt64.MaxValue, null, &count)
let platformName = Array.create (int(count)) (0uy)
res <- CL.clGetPlatformInfo(platforms.[0], PlatformInfo.NAME, count, platformName, &count)
let name = System.Text.Encoding.ASCII.GetString platformName