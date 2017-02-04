namespace OpenCL
open System.Runtime.InteropServices

module CL =
    let [<Literal>] lib = "OpenCL.dll"
    [<DllImport(lib)>] extern void clGetPlatformIDs();

type Class1() = 
    member this.X = "F#"
