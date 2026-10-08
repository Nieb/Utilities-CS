
namespace UtilityTest;
internal static partial class Program {
    static void Test__String() {
        TESTOUT("\n[Utility.STR]");

        //======================================================================================================================================================
        TEST("RandomDigits()",true
            && RandomDigits(5).Length      == 5
            && RandomDigits(5).IsNumeric() == true
        );

        //======================================================================================================================================================
        TEST(".ToBool()",true
            && "true".ToBool() == true
            && "True".ToBool() == true
            && "TRUE".ToBool() == true
            && "TrUe".ToBool() == true
            && "tRuE".ToBool() == true

            && "false".ToBool() == false
            && "False".ToBool() == false
            && "FALSE".ToBool() == false
            && "FaLsE".ToBool() == false
            && "fAlSe".ToBool() == false

            && "".ToBool() == false
            && "blarg".ToBool() == false
        );

        //TEST(".ToDateTime()",true
        //    && "".ToDateTime() == System.DateTime.MinValue
        //);

        TEST(".ToIpAddress()",true
            && ""               .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && " "              .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "blarg"          .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "0"              .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "0.0.0.0"        .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "127.0.0.1"      .ToIpAddress().Equals(new System.Net.IPAddress(new byte[] { 0x7F, 0x00, 0x00, 0x01 }))
            && "192.168.0.1"    .ToIpAddress().Equals(new System.Net.IPAddress(new byte[] { 0xC0, 0xA8, 0x00, 0x01 }))
            && "255.255.255.255".ToIpAddress().Equals(new System.Net.IPAddress(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }))
        );

        TEST(".ToNameValueCollection()",true
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["ABC"] == "123,789"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["def"] == "Xyz"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["G"]   == "456"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["H"]   == "1.414"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["i"]   == "0"
        );

        //======================================================================================================================================================
        TEST("ByteArrayToString()",true
            && ByteArrayToString(new byte[] { 0xFF, 0xCC, 0xAA })                                  == "FF CC AA "
            && ByteArrayToString(new byte[] { 0xFF, 0xCC, 0xAA, 0x99, 0x77, 0x55, 0x33, 0x11 }, 3) == "FF CC AA \n99 77 55 \n33 11 "
        );

        TEST("EnumerableToString()",true
            && EnumerableToString(["Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg", "Hh", "Ii"]) == "Aa, Bb, Cc, Dd, Ee, Ff, Gg, Hh, Ii"
            && EnumerableToString("AaBbCcDdEeFfGgHhIi")                                   == "A, a, B, b, C, c, D, d, E, e, F, f, G, g, H, h, I, i"
            && EnumerableToString([1, 2, 3])                                              == "1, 2, 3"
        );

        TEST("IntToBinString()",true
            && IntToBinString((sbyte )                 0x7F) ==                                                                "01111111"
            && IntToBinString((short )               0x7FFF) ==                                                       "01111111_11111111"
            && IntToBinString((int   )          0x7FFF_FFFF) ==                                     "01111111_11111111_11111111_11111111"
            && IntToBinString((long  )0x7FFF_FFFF_FFFF_FFFF) == "01111111_11111111_11111111_11111111_11111111_11111111_11111111_11111111"

            && IntToBinString((byte  )                 0xFF) ==                                                                "11111111"
            && IntToBinString((ushort)               0xFFFF) ==                                                       "11111111_11111111"
            && IntToBinString((uint  )          0xFFFF_FFFF) ==                                     "11111111_11111111_11111111_11111111"
            && IntToBinString((ulong )0xFFFF_FFFF_FFFF_FFFF) == "11111111_11111111_11111111_11111111_11111111_11111111_11111111_11111111"
        );

        TEST("IntToHexString()",true
            && IntToHexString((sbyte )                 0x7F) ==                  "7F"
            && IntToHexString((short )               0x7FFF) ==                "7FFF"
            && IntToHexString((int   )          0x1234_5678) ==           "1234_5678"
            && IntToHexString((int   )          0x0034_0078) ==           "0034_0078"
            && IntToHexString((long  )0x1234_5678_90AB_CDEF) == "1234_5678_90AB_CDEF"
            && IntToHexString((long  )0x0234_0078_000B_00EF) == "0234_0078_000B_00EF"

            && IntToHexString((byte  )                 0xFF) ==                  "FF"
            && IntToHexString((ushort)               0xFFFF) ==                "FFFF"
            && IntToHexString((uint  )          0x1234_5678) ==           "1234_5678"
            && IntToHexString((uint  )          0x0034_0078) ==           "0034_0078"
            && IntToHexString((ulong )0x1234_5678_90AB_CDEF) == "1234_5678_90AB_CDEF"
            && IntToHexString((ulong )0x0234_0078_000B_00EF) == "0234_0078_000B_00EF"
        );

        //======================================================================================================================================================
        TEST("CommaDelimit()",true
            && CommaDelimit(s16(-12_345)) == "-12,345"
            && CommaDelimit(s16( -2_345)) ==  "-2,345"
            && CommaDelimit(s16(   -345)) ==    "-345"
            && CommaDelimit(s16(    -45)) ==     "-45"
            && CommaDelimit(s16(      5)) ==       "5"
            && CommaDelimit(s16(     45)) ==      "45"
            && CommaDelimit(s16(    345)) ==     "345"
            && CommaDelimit(s16(  2_345)) ==   "2,345"
            && CommaDelimit(s16( 12_345)) ==  "12,345"

            && CommaDelimit(u16(     9)) ==      "9"
            && CommaDelimit(u16(    89)) ==     "89"
            && CommaDelimit(u16(   789)) ==    "789"
            && CommaDelimit(u16( 6_789)) ==  "6,789"
            && CommaDelimit(u16(56_789)) == "56,789"

            && CommaDelimit(-1_234_567_890) == "-1,234,567,890"
            && CommaDelimit(  -234_567_890) ==   "-234,567,890"
            && CommaDelimit(   -34_567_890) ==    "-34,567,890"
            && CommaDelimit(    -4_567_890) ==     "-4,567,890"
            && CommaDelimit(      -567_890) ==       "-567,890"
            && CommaDelimit(       -67_890) ==        "-67,890"
            && CommaDelimit(        -7_890) ==         "-7,890"
            && CommaDelimit(          -890) ==           "-890"
            && CommaDelimit(           -90) ==            "-90"
            && CommaDelimit(             0) ==              "0"
            && CommaDelimit(            90) ==             "90"
            && CommaDelimit(           890) ==            "890"
            && CommaDelimit(         7_890) ==          "7,890"
            && CommaDelimit(        67_890) ==         "67,890"
            && CommaDelimit(       567_890) ==        "567,890"
            && CommaDelimit(     4_567_890) ==      "4,567,890"
            && CommaDelimit(    34_567_890) ==     "34,567,890"
            && CommaDelimit(   234_567_890) ==    "234,567,890"
            && CommaDelimit( 1_234_567_890) ==  "1,234,567,890"

            && CommaDelimit(            0u) ==             "0"
            && CommaDelimit(           90u) ==            "90"
            && CommaDelimit(          890u) ==           "890"
            && CommaDelimit(        7_890u) ==         "7,890"
            && CommaDelimit(       67_890u) ==        "67,890"
            && CommaDelimit(      567_890u) ==       "567,890"
            && CommaDelimit(    4_567_890u) ==     "4,567,890"
            && CommaDelimit(   34_567_890u) ==    "34,567,890"
            && CommaDelimit(  234_567_890u) ==   "234,567,890"
            && CommaDelimit(1_234_567_890u) == "1,234,567,890"
            && CommaDelimit(4_123_456_789u) == "4,123,456,789"

            && CommaDelimit(-9_223_372_036_854_775_807L) == "-9,223,372,036,854,775,807"
            && CommaDelimit(          -123_456_789_000L) ==           "-123,456,789,000"
            && CommaDelimit(                         0L) ==                          "0"
            && CommaDelimit(           123_456_789_000L) ==            "123,456,789,000"
            && CommaDelimit( 9_223_372_036_854_775_807L) ==  "9,223,372,036,854,775,807"

            && CommaDelimit(                         0UL) ==                          "0"
            && CommaDelimit(18_446_744_073_709_551_615UL) == "18,446,744,073,709,551,615"
        );

        //======================================================================================================================================================
        TEST(".IsNumeric()",true
            && "123".IsNumeric() == true

            && "-123".IsNumeric()     == false
            && "-123".IsNumeric(true) == true

            && "-123.456".IsNumeric(true)      == false
            && "-123.456".IsNumeric(true,true) == true
            && "123.456".IsNumeric(false,true) == true

            && "ab12".IsNumeric() == false
            && "123_".IsNumeric() == false
            && "123 ".IsNumeric() == false
        );

        TEST(".IsValidEmailAddress()",true
            && "user@sub.domain.top".IsValidEmailAddress()                         == true
            && "user@sub.domain.top".IsValidEmailAddress("top", "domain", "sub"  ) == true
            && "user@sub.domain.top".IsValidEmailAddress("top", "domain"         ) == true
            && "user@sub.domain.top".IsValidEmailAddress("top"                   ) == true
            && "user@sub.domain.top".IsValidEmailAddress("top", "domain", "blarg") == false
            && "user@sub.domain.top".IsValidEmailAddress("top", "blarg"          ) == false
            && "user@sub.domain.top".IsValidEmailAddress("blarg"                 ) == false
        );

        TEST(".IsVoid()",true
            && "blarg".IsVoid() == false

            && "     ".IsVoid() == true
            && " \n  ".IsVoid() == true
            && "  \t ".IsVoid() == true
            && "\n\t ".IsVoid() == true

            && "".IsVoid() == true

            && ((string)null).IsVoid() == true
        );

        //======================================================================================================================================================
        TEST(".ContainsAny()",true
            && "blarg".ContainsAny( new string[] {"ugh", "arg"} ) == true
        );

        TEST(".ContainsAny_GetMatches()",true
            && "blarg".ContainsAny_GetMatches( new string[] {"bla", "ugh", "arg"} )[0] == "bla"
            && "blarg".ContainsAny_GetMatches( new string[] {"bla", "ugh", "arg"} )[1] == "arg"
        );

        //======================================================================================================================================================
        TEST(".Indent()",true
            && "blarg\nblarg\nblarg".Indent() == "    blarg\n    blarg\n    blarg"
        );

        TEST(".InsertEvery()",true
            && "blargblargblarg".InsertEvery(5, ", ") == "blarg, blarg, blarg"
        );

        TEST(".Pad()",true
            && "blarg".Pad(-10) == "     blarg"
            && "blarg".Pad( 10) == "blarg     "
        );

        TEST(".Prepend()",true
            && "blarg\nblarg\nblarg".Prepend(" ~~ ") == " ~~ blarg\n ~~ blarg\n ~~ blarg"
        );

        TEST(".Repeat()",true
            && $"{"blarg".Repeat(3)}{"  ".Repeat(4)}{"blarg".Repeat(3)}" == "blargblargblarg        blargblargblarg"
            && $"{"blarg".Repeat(3)}{"\n".Repeat(4)}{"blarg".Repeat(3)}" == "blargblargblarg\n\n\n\nblargblargblarg"
        );

        TEST(".ToTitleCase()",true
            && "blarg BLARG bLaRg".ToTitleCase() == "Blarg Blarg Blarg"
        );

        //======================================================================================================================================================
    }
}
