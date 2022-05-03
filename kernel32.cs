using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Amherst
{
    internal class kernel32
    {
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        //import of openprocess
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
         uint processAccess,
         bool bInheritHandle,
         uint processId
        );

        //function to call to get process
        public static IntPtr OpenProcess(Process proc, ProcessAccessFlags flags)
        {
            return OpenProcess(0x001F0FFF, false, (uint)proc.Id);
        }


        //import of write memory
        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            Int32 nSize,
            out IntPtr lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
        IntPtr hProcess,
        int lpBaseAddress,
        byte[] lpBuffer,
        Int32 nSize,
        out IntPtr lpNumberOfBytesRead);

        public bool WriteByte(IntPtr handle, int address, byte[] value)
        {
            //create buffer and pointer
            byte[] dataBuffer = value;
            IntPtr bytesWritten = IntPtr.Zero;

            //do the write
            WriteProcessMemory(handle, (IntPtr)address, dataBuffer, 1, out bytesWritten);

            //error handling
            //if no bytes written
            if(bytesWritten != IntPtr.Zero)
            {
                Console.WriteLine("Nothing was written");
                return false;
            }
            //if bytes written were less than the length
            if(bytesWritten.ToInt32() < dataBuffer.Length)
            {
                Console.WriteLine("We wrote {0} out of {1} bytes!", bytesWritten.ToInt32(), dataBuffer.Length.ToString());
                return false;
            }
            //if it wrote correctly
            return true;
        }

        public int ReadMapID(IntPtr handle)
        {
            //create variables for bytes read and buffer
            IntPtr bytesRead = IntPtr.Zero;
            byte[] buffer = new byte[4];
            //set base address
            int baseAddress = 0x01C10EA8;
            //read base address
            ReadProcessMemory(handle, baseAddress, buffer, buffer.Length, out bytesRead);
            //take address from first and read to get map value
            int mapIDAddr = BitConverter.ToInt32(buffer, 0) + 0x13A4;
            ReadProcessMemory(handle, mapIDAddr, buffer, buffer.Length, out bytesRead);
            //return
            return BitConverter.ToInt32(buffer, 0);
        }

        public int ReadNXAmt(IntPtr handle)
        {
            //create variables for bytes read and buffer
            IntPtr bytesRead = IntPtr.Zero;
            byte[] buffer = new byte[4];

            //get the process so we can get module base address for reading memory
            Process myProc = Process.GetProcessesByName("Maplestory").FirstOrDefault();
            try
            {
                //base address for maplestory (usually 0x00400000 I think?)
                IntPtr baseadd = myProc.MainModule.BaseAddress;
                //get the nx address by adding offset to base address
                int nxadd = (int)baseadd + 0x18318E4;
                //read the nx amount
                kernel32.ReadProcessMemory(handle, nxadd, buffer, buffer.Length, out bytesRead);

                //return string form of nx amount
                return BitConverter.ToInt32(buffer, 0);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
