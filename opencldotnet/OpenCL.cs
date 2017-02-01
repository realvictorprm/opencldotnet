using System;
using System.Runtime.InteropServices;

namespace OpenCL
{

	public struct PlatformID
	{
	}

	public class CL
	{
		public CL()
		{
		}


		[DllImport("OpenCL.dll")]
		public static extern void clGetPlatformIDs(uint maxPlatforms, PlatformID[] platforms, IntPtr count);
	}

}
