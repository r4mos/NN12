namespace Sample
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Wellcome()
        {
            Console.WriteLine("");
            Console.WriteLine("  _____       _   _____             __");
            Console.WriteLine(" |  __ \\     | | |  __ \\           /_/");
            Console.WriteLine(" | |  | | ___| | | |__) |_____   _____  ___");
            Console.WriteLine(" | |  | |/ _ \\ | |  _  // _ \\ \\ / / _ \\/ __|");
            Console.WriteLine(" | |__| |  __/ | | | \\ \\  __/\\ V /  __/\\__ \\");
            Console.WriteLine(" |_____/ \\___|_| |_|  \\_\\___| \\_/ \\___||___/");
            Console.WriteLine("");
            Console.WriteLine("                                   #nn12ed");
            Console.WriteLine("Check the flag:");
            Console.Write("> ");
        }

        static bool Checker(byte[] input)
        {
            byte[] encryptionKey = Encoding.UTF8.GetBytes("This is an encryption key");
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (byte)(input[i] ^ encryptionKey[i % encryptionKey.Length]);
            }

            // https://gchq.github.io/CyberChef/#recipe=XOR(%7B'option':'UTF8','string':'This%20is%20an%20encryption%20key'%7D,'Standard',false)To_Hex('0x%20with%20comma',0)&input=ZjE0OXt3aDNuXzFuX2QwdTg3X3U1M180X2QzOHU5OTMyfQ&oeol=VT
            byte[] encryptedFlag = { 0x32, 0x59, 0x5d, 0x4a, 0x5b, 0x1e, 0x1b, 0x13, 0x0f, 0x31, 0x11, 0x0b, 0x31, 0x07, 0x42, 0x0c, 0x48, 0x43, 0x36, 0x1a, 0x5b, 0x13, 0x34, 0x51, 0x26, 0x30, 0x5b, 0x51, 0x06, 0x19, 0x50, 0x40, 0x12, 0x1c };
            for (int i = 0; i < encryptedFlag.Length; i++)
            {
                if (encryptedFlag[i] != input[i])
                {
                    return false;
                }
            }

            return true;
        }

        static int Main()
        {
            Wellcome();

            byte[] input = Encoding.UTF8.GetBytes(Console.ReadLine() ?? "");
            if (input.Length == 0)
            {
                Console.WriteLine("This is infuriating! Let's fix this now!");
                return 1;
            }

            if (Checker(input))
            {
                Console.WriteLine("Amazing! Joy has taken control! The string is perfect");
            }
            else
            {
                Console.WriteLine("Oh no... Sadness has taken over. The string is incorrect, let's try again");
            }

            Console.ReadLine();
            return 0;
        }
    }
}
