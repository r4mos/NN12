using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Naja_Negra
{
    public class License
    {
        private readonly uint ID = 0;
        private const string DICTIONARY = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        private const string GAME_REG_SUBKEY = @"SOFTWARE\Naja Negra";
        private const string GAME_REG_NAME = "Serial";

        public License()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(
                        ReadMachineRegedit(@"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName", "ComputerName") +
                        ReadMachineRegedit(@"HARDWARE\DESCRIPTION\System\BIOS", "SystemSerialNumber") +
                        ReadMachineRegedit(@"SOFTWARE\Microsoft\Cryptography", "MachineGuid") +
                        ReadMachineRegedit(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString") +
                        ReadMachineRegedit(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName") +
                        ReadMachineRegedit(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductId") +
                        ReadMachineRegedit(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner")));

                for (int i = 0; i < 4; i++)
                {
                    ID <<= 8;
                    ID |= hash[i * 8 + 4];
                }
            }
        }

        public bool IsActive()
        {
            return CheckSerial(ID, FromText(ReadUserRegedit(GAME_REG_SUBKEY, GAME_REG_NAME)));
        }

        public string getID()
        {
            return GetText(ID);
        }

        public bool Activate(string serial)
        {
            if (CheckSerial(ID, FromText(serial)))
            {
                WriteUserRegedit(GAME_REG_SUBKEY, GAME_REG_NAME, serial);
                return true;
            }
            return false;
        }

        private bool CheckSerial(uint id, uint serial)
        {
            IntPtr nativeLicenseCheckerPtr = LoadLibrary(ExtractDll());
            if (nativeLicenseCheckerPtr == IntPtr.Zero)
            {
                return false;
            }

            IntPtr checkSerialPtr = GetProcAddress(nativeLicenseCheckerPtr, "CheckSerial");
            if (checkSerialPtr == IntPtr.Zero)
            {
                return false;
            }

            CheckSerialDelegate checkSerialNative =
                (CheckSerialDelegate)Marshal.GetDelegateForFunctionPointer(checkSerialPtr, typeof(CheckSerialDelegate));

            return checkSerialNative(id, serial);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CheckSerialDelegate(uint id, uint serial);


        private string ExtractDll()
        {
            byte[] resource = Environment.Is64BitProcess
                ? Properties.Resources.NativeLicenseChecker_x64
                : Properties.Resources.NativeLicenseChecker_x86;

            string path = Path.Combine(Path.GetTempPath(), "NajaNegraLicense.dll");
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, resource);
            }
            return path;
        }

        private string ReadMachineRegedit(string subkey, string name)
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(subkey))
            {
                return registryKey?.GetValue(name)?.ToString() ?? String.Empty;
            }
        }

        private string ReadUserRegedit(string subkey, string name)
        {
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(subkey))
            {
                return registryKey?.GetValue(name)?.ToString() ?? String.Empty;
            }
        }

        private void WriteUserRegedit(string subkey, string name, object value)
        {
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey))
            {
                registryKey?.SetValue(name, value);
            }
        }

        private string GetText(uint value)
        {
            return ToBase32(value).PadRight(7, '1').Insert(3, "-").Insert(7, "-");
        }

        private string ToBase32(uint value)
        {
            string result = string.Empty;

            for (int i = 0; i < 7; i++)
            {
                uint index = i == 6
                    ? (value & 0x03) << 3
                    : value >> (27 - (i * 5));
                index &= 0x1F;
                result += DICTIONARY[(int)index];
            }

            return result;
        }

        private uint FromText(string value)
        {
            return FromBase32(value.Replace("1", "").Replace("-", "").PadRight(7, '1').Substring(0, 7));
        }

        private uint FromBase32(string value)
        {
            uint result = 0;

            for (int i = 0; i < value.Length; i++)
            {
                int index = DICTIONARY.IndexOf(value.ElementAt(i));
                if (index != -1 && i < 7)
                {
                    if (i == 6)
                    {
                        result |= ((uint)index & 0x1F) >> 3;
                    }
                    else
                    {
                        result |= ((uint)index & 0x1F) << (27 - (i * 5));
                    }
                }
            }

            return result;
        }
    }
}
