using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.UI;

namespace Systems.Utility
{
    public static class Methods
    {
        public static Color32 HexToColor(int HexVal)
        {
            byte R = (byte)((HexVal >> 16) & 0xFF);
            byte G = (byte)((HexVal >> 8) & 0xFF);
            byte B = (byte)((HexVal) & 0xFF);
            return new Color32(R, G, B, 255);
        }

        public static Color32 HexToColor(string HexVal)
        {
            if (HexVal.StartsWith("#"))
            {
                HexVal = HexVal.Substring(1);
            }

            if (HexVal.StartsWith("0x"))
            {
                HexVal = HexVal.Substring(2);
            }

            byte r = byte.Parse(HexVal.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(HexVal.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(HexVal.Substring(4, 2), NumberStyles.HexNumber);
            byte a = 1;
            if (HexVal.Length == 6)
            {
                a = byte.Parse(HexVal.Substring(6, 2), NumberStyles.HexNumber);
            }

            return new Color32(r, g, b, a);
        }
    }
}
