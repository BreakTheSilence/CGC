using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace CGC
{
    class AuthorizationProcessor
    {
        public string MachineIdHash { get; set; }

        private string cdKeyFileName;

        public AuthorizationProcessor()
        {
            cdKeyFileName = "CDKey.cdkey";
            MachineIdHash = GetMD5StringHash(GetCPUId());
        }

        public bool IsUserAuthenticated()
        {
            return MachineIdHash == ReadCDKeyFile();
        }

        private string GetMD5StringHash(String inputString)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(inputString);
            var hash = md5.ComputeHash(inputBytes);
            var stringbuilder = new StringBuilder();
            foreach (byte hashByte in hash)
            {
                stringbuilder.Append(hashByte.ToString("X2"));
            }
            return stringbuilder.ToString();
        }

        private string GetCPUId()
        {
            string cpuId = string.Empty;
            var managClass = new ManagementClass("win32_processor");
            var managCollec = managClass.GetInstances();
            foreach (ManagementObject managObj in managCollec)
            {
                cpuId = managObj.Properties["processorID"].Value.ToString();
                break;
            }
            return cpuId;
        }

        private void SaveCDKeyFile(string writeToFile)
        {
            File.Delete(cdKeyFileName);
            var streamWriter = new StreamWriter(cdKeyFileName);
            streamWriter.Write(writeToFile);
        }

        private string ReadCDKeyFile()
        {
            if (File.Exists(cdKeyFileName))
            {
                var streamReader = new StreamReader("CDKey.cdkey");
                return streamReader.ReadToEnd();
            }
            return String.Empty;
        }
    }
}
