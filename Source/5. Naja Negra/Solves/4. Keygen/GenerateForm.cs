namespace Generator
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class GenerateForm : Form
    {
        private const string DICTIONARY = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        public GenerateForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // PL5-ZUM-Q > PL5ZUMQ > 0x7AFB9A32 > 0xDC72886D > 3RZIQ3I > 3RZ-IQ3-I
            serialBox.Text = GetText(GetSerial(FromText(idBox.Text)));
        }

        uint GetSerial(uint id)
        {
            ushort base1 = 0xDEAD;
            ushort base2 = 0xBEEF;
            ushort base3 = 0xBAAD;
            ushort base4 = 0xF00D;

            ushort seedHigh = (ushort)(id >> 16);
            ushort seedLow = (ushort)(id);
            ushort passHigh = 0x0000;
            ushort passLow = 0x0000;

            for (int i = 0; i < 10; i++)
            {
                passHigh = (ushort)(~seedHigh);
                passHigh ^= seedLow;

                passLow = seedLow;
                passLow *= base1;
                passLow -= base2;
                passLow ^= seedHigh;

                seedHigh = base3;
                seedHigh ^= passHigh;
                seedLow = base4;
                seedLow ^= passLow;
            }

            uint pass;
            pass = passHigh;
            pass <<= 16;
            pass |= passLow;
            pass ^= id;

            return pass;
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
