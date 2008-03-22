using System;
using System.Collections.Generic;
using System.Text;
using MediaPortal.Core;
using MediaPortal.Core.Logging;

namespace Presentation.SkinEngine.Players.Subtitles
{
  class TextConversion
  {
    private static Dictionary<string, Dictionary<char, char>> langSpecificMap;


    static TextConversion()
    {
      langSpecificMap = new Dictionary<string, Dictionary<char, char>>();
      langSpecificMap["dan"] = new Dictionary<char, char>();
      langSpecificMap["dan"]['�'] = '�';
      langSpecificMap["dan"]['�'] = '�';
    }

    public static string ConvertLineLangSpecific(string lang, string line)
    {
      ServiceScope.Get<ILogger>().Debug("ConvertLineLangSpecific {0} {1}", lang, line);
      if (!langSpecificMap.ContainsKey(lang)) return line;

      StringBuilder lineBuilder = new StringBuilder();
      for (int i = 0; i < line.Length; i++)
      {
        char c = line[i];
        if (langSpecificMap[lang].ContainsKey(c))
        {
          lineBuilder.Append(langSpecificMap[lang][c]);
        }
        else lineBuilder.Append(c);
      }
      return lineBuilder.ToString();
    }

    private static byte[,] vtx2iso8559_1_table = new byte[8, 96]
        {
          /* English */
          { 0x20,0x21,0x22,0xa3,0x24,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0x5b,0xbd,0x5d,0x5e,0x23,   // 0x50-0x5f
            0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0xbc,0x7c,0xbe,0xf7,0x7f }, // 0x70-0x7f
          /* German - TO BE COMPLETED */
          { 0x20,0x21,0x22,0x23,0xa4,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0x5b,0x5c,0x5d,0x5e,0x5f,   // 0x50-0x5f
            0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7c,0x7d,0x7e,0x7f }, // 0x70-0x7f
          /* Swedish/Finnish/Hungarian */
          { 0x20,0x21,0x22,0x23,0xa4,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0xc9,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0xc4,0xd6,0xc5,0xdc,0x5f,   // 0x50-0x5f
            0xe9,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0xe4,0xf6,0xe5,0xfc,0x7f }, // 0x70-0x7f
          /* Italian - TO BE COMPLETED */
          { 0x20,0x21,0x22,0x23,0xa4,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0x5b,0x5c,0x5d,0x5e,0x5f,   // 0x50-0x5f
            0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7c,0x7d,0x7e,0x7f }, // 0x70-0x7f
          /* French - TO BE COMPLETED */
          { 0x20,0x21,0x22,0x23,0xa4,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0x5b,0x5c,0x5d,0x5e,0x5f,   // 0x50-0x5f
            0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7c,0x7d,0x7e,0x7f }, // 0x70-0x7f
          /* Spanish/Portuguese */
          { 0x20,0x21,0x22,0xec,0x24,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0xa1,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0xe1,0xe9,0xed,0xf3,0xfa,   // 0x50-0x5f
            0xbf,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0xfc,0xf1,0xe8,0xe0,0x7f }, // 0x70-0x7f
          /* Czech/Slovak - TO BE COMPLETED */
          { 0x20,0x21,0x22,0x23,0xa4,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0x5b,0x5c,0x5d,0x5e,0x5f,   // 0x50-0x5f
            0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7c,0x7d,0x7e,0x7f }, // 0x70-0x7f
          /* Unknown - Unused?*/
          { 0x20,0x21,0x22,0x23,0xa4,0x25,0x26,0x27,0x28,0x29,0x2a,0x2b,0x2c,0x2d,0x2e,0x2f,   // 0x20-0x2f
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x3a,0x3b,0x3c,0x3d,0x3e,0x3f,   // 0x30-0x3f
            0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,   // 0x40-0x4f
            0x50,0x51,0x52,0x53,0x54,0x55,0x56,0x57,0x58,0x59,0x5a,0x5b,0x5c,0x5d,0x5e,0x5f,   // 0x50-0x5f
            0x60,0x61,0x62,0x63,0x64,0x65,0x66,0x67,0x68,0x69,0x6a,0x6b,0x6c,0x6d,0x6e,0x6f,   // 0x60-0x6f
            0x70,0x71,0x72,0x73,0x74,0x75,0x76,0x77,0x78,0x79,0x7a,0x7b,0x7c,0x7d,0x7e,0x7f }  // 0x70-0x7f
        };

    public static void ConvertLine(int lang, char[] teletext, int len)
    {
      assert(lang >= 0 && lang <= 7, "ConvertLine: Lang outside range!");
      for (int col = 0; col < len; col++)
      {
        teletext[col] = (char)vtx2iso8559_1_table[lang, (teletext[col] & 0x7f) - 0x20];
      }
    }

    public static void Convert(int lang, byte[] teletext)
    {
      assert(lang >= 0 && lang <= 7, "Convert: Lang outside range!");
      ServiceScope.Get<ILogger>().Debug("Convert: Input data length {0} teletext");
      for (int i = 0; i < teletext.Length; i++)
      {
        //ServiceScope.Get<ILogger>().Debug("" + (teletext[i] & 0x7f));

        int charIndex = (teletext[i] & 0x7f) - 0x20;
        //assert(charIndex >= 0, "Convert: About to index position [" +lang + ", " + charIndex + "] source pos is " + i+ "( line " + (i % 25) + ")");

        if (charIndex < 0)
        {
          ServiceScope.Get<ILogger>().Debug("Convert: About to index position [" + lang + ", " + charIndex + "] source pos is " + i + "( line " + (i % 25) + ")");
          continue;
        }
        teletext[i] = vtx2iso8559_1_table[lang, charIndex];
      }
    }

    private static void assert(bool ok, string msg)
    {
      if (!ok) throw new Exception("Assertion failed in TextConversion! " + msg);
    }
  }
}
