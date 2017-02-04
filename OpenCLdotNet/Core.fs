namespace OpenCL
open System.Runtime.InteropServices
open System

[<Struct>]
type HandleStructure =
     val handle : nativeint

type PlatformID = HandleStructure

module Helper =
    let ToString (o:byte[]) =
        System.Text.Encoding.ASCII.GetString o
        

module CL =
    let [<Literal>] lib = "OpenCL.dll"
    [<DllImport(lib)>] 
    extern ResultValue clGetPlatformIDs(uint32 maxNumEntries, [<Out>][<MarshalAs(UnmanagedType.LPArray)>]PlatformID[] p, UInt32& count);
    
    [<DllImport(lib)>] 
    extern ResultValue clGetPlatformInfo(PlatformID p, PlatformInfo info, UInt64 maxParamSize, byte[] paramData, UInt64& paramSize)

    [<Obsolete>]
    let check r =
        if r = ResultValue.SUCCESS then
            ()
        else 
            failwith "Result is not success!"
    
    ///Not ready yet
    [<Obsolete>]
    let getPlatforms () =
        let mutable count = 0u
        check (clGetPlatformIDs(UInt32.MaxValue, null, &count))
        let mutable platforms = Array.create (int(count)) (PlatformID())
        check (clGetPlatformIDs(count, platforms, &count))
        platforms
        
