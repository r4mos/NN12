namespace Brutalforce
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class BrutalforceForm : Form
    {
        private const string DICTIONARY = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        public BrutalforceForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            button.Enabled = false;
            // PL5-ZUM-Q > PL5ZUMQ > 0x7AFB9A32 > 0xDC72886D > 3RZIQ3I > 3RZ-IQ3-I
            MessageBox.Show(EfficientCrack(FromText(idBox.Text)), "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button.Enabled = true;
        }

        private string Crack(uint id)
        {
            for (uint i = 0; i < uint.MaxValue; i++)
            {
                if (CheckSerial(id, i))
                {
                    return GetText(i);
                }
            }
            return "Not Found?";
        }

        private string EfficientCrack(uint id)
        {
            string result = "Not Found?";
            bool found = false;
            object lockObject = new object();

            Parallel.For(0, (long)uint.MaxValue, (i, state) =>
            {
                if (found)
                {
                    state.Stop();
                    return;
                }

                if (CheckSerial(id, (uint)i))
                {
                    lock (lockObject)
                    {
                        if (!found)
                        {
                            found = true;
                            result = GetText((uint)i);
                            state.Stop();
                        }
                    }
                }
            });

            return result;
        }

        [DllImport("NativeLicenseChecker.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool CheckSerial(uint id, uint serial);

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
