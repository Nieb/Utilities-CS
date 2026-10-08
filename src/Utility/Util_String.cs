using System.Linq;
using NameValueCollection = System.Collections.Specialized.NameValueCollection;

using StringBuilder = System.Text.StringBuilder;
using Regex         = System.Text.RegularExpressions.Regex;

namespace Utility;
internal static partial class STR {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  Generate String
    //==========================================================================================================================================================
    //
    //  FormatString:
    //      "yyyy-MM-dd"
    //      "yyyy-MM-dd HH:mm:ss"
    //      "yyyy-MM-dd__HH.mm.ss.fff"
    //      "yyyy-MM-dd HH:mm:ss.ffffff"
    //      "HH:mm:ss"
    //      "HH:mm:ss.fff"
    //      "HH:mm:ss.ffffff"
    //
    [In(line)] internal static string DateTime(string FormatString) => System.DateTime.Now.ToString(FormatString);

    //==========================================================================================================================================================
    internal static string RandomDigits(int Count) {
        if (Count <= 0)
            return "";

        char[] Result = new char[Count];

        for (int i = 0; i < Count; i++)
            Result[i] = (char)(48 + RandomInt(0,9));

        return new string(Result);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                Convert FROM String
    //==========================================================================================================================================================
    [In(line)] internal static bool ToBool(this string STR) {
        if (STR.IsVoid())
            return false;

        bool Parse_Succeed = System.Boolean.TryParse(STR, out bool Parse_Result);

        if (!Parse_Succeed)
            return false;

        return Parse_Result;
    }

    //==========================================================================================================================================================
    [In(line)] internal static System.DateTime ToDateTime(this string STR) {
        if (STR.IsVoid())
            return System.DateTime.MinValue;

        bool Parse_Succeed = System.DateTime.TryParse(STR, out System.DateTime Parse_Result);

        //  If parse fails, result is 'DateTime.MinValue'.

        return Parse_Result;
    }

    //==========================================================================================================================================================
    [In(line)] internal static System.Net.IPAddress ToIpAddress(this string STR) {
        if (STR.IsVoid())
            return new System.Net.IPAddress(0);

        bool Parse_Succeed = System.Net.IPAddress.TryParse(STR, out System.Net.IPAddress Parse_Result);

        if (!Parse_Succeed)
            return new System.Net.IPAddress(0);

        return Parse_Result;
    }

    //==========================================================================================================================================================
    //
    //      var Blarg = "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()
    //
    //      Blarg["ABC"] == "123,789"
    //      Blarg["def"] == "Xyz"
    //      Blarg["G"]   == "456"
    //      Blarg["H"]   == "1.414"
    //      Blarg["i"]   == "0"
    //
    internal static NameValueCollection ToNameValueCollection(this string STR) {
        if (STR.IsVoid())
            return null;

        var NameValueCol = new NameValueCollection();

        foreach (string pair in STR.Split(',')) {
            int SplitIndex = pair.IndexOf('=');
            if (SplitIndex > 0) {
                string PairName  = pair.Substring(0, SplitIndex).Trim();
                string PairValue = pair.Substring(SplitIndex + 1).Trim();
                NameValueCol.Add(PairName, PairValue);
            }
        }

        return NameValueCol;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 Convert TO String
    //==========================================================================================================================================================
    internal static string ByteArrayToString(byte[] ByteArr, int BytesPerLine = 16, string Delimiter = " ") {
        if (ByteArr == null)
            return "NULL";

        StringBuilder Result = new StringBuilder();

        for (int iY = 0; iY < ByteArr.Length; iY += BytesPerLine) {
            for (int iX = 0; iX < BytesPerLine && iY + iX < ByteArr.Length; iX++)
                Result.Append($"{ByteArr[iY+iX]:X2}{Delimiter}");
            if (iY + BytesPerLine < ByteArr.Length)
                Result.Append("\n");
        }

        return Result.ToString();
    }

    //==========================================================================================================================================================
    //
    //      EnumerableToString(Enmrbl, ItemsPerLine: 0, ItemPadding: 0, LineIndent: 0, ItemDelimiter: ", ", LineDelimiter: "\n")
    //
    internal static string EnumerableToString<T>(System.Collections.Generic.IEnumerable<T> Enmrbl,
                                                 int ItemsPerLine = 0, int ItemPadding = 0, int LineIndent = 0, string ItemDelimiter = ", ", string LineDelimiter = "\n") {
        if (Enmrbl == null)
            return "";

        string Result = "";

        if (ItemsPerLine < 1) {
            foreach (var item in Enmrbl) {
                Result += (Result == "") ? $"{item}" : $"{ItemDelimiter}{item}";
            }

        } else {
            string Indent = new System.String(' ', LineIndent);
            int EnumCount = Enumerable.Count(Enmrbl);
            for (int iY = 0; iY < EnumCount; iY += ItemsPerLine) {
                Result += Indent;
                for (int iX = 0; (iX < ItemsPerLine) && (iY+iX < EnumCount); iX++) {

                    Result += $"{Enmrbl.ElementAt(iY+iX)}".Pad(ItemPadding);

                    Result += ((iX < ItemsPerLine) && (iY+iX+1 < EnumCount)) ? ItemDelimiter : "";
                }
                if (iY + ItemsPerLine < EnumCount)
                    Result += LineDelimiter;
            }
        }

        return Result;
    }

    //==========================================================================================================================================================
    internal static string IntToBinString( s8 A) =>               System.Convert.ToString(      A, 2).PadLeft( 8,'0');
    internal static string IntToBinString( u8 A) =>               System.Convert.ToString(      A, 2).PadLeft( 8,'0');
    internal static string IntToBinString(s16 A) => Regex.Replace(System.Convert.ToString(      A, 2).PadLeft(16,'0'), @".{8}(?!$)", @"$0_");
    internal static string IntToBinString(u16 A) => Regex.Replace(System.Convert.ToString(      A, 2).PadLeft(16,'0'), @".{8}(?!$)", @"$0_");
    internal static string IntToBinString(s32 A) => Regex.Replace(System.Convert.ToString(      A, 2).PadLeft(32,'0'), @".{8}(?!$)", @"$0_");
    internal static string IntToBinString(u32 A) => Regex.Replace(System.Convert.ToString(      A, 2).PadLeft(32,'0'), @".{8}(?!$)", @"$0_");
    internal static string IntToBinString(s64 A) => Regex.Replace(System.Convert.ToString(      A, 2).PadLeft(64,'0'), @".{8}(?!$)", @"$0_");
    internal static string IntToBinString(u64 A) => Regex.Replace(System.Convert.ToString((long)A, 2).PadLeft(64,'0'), @".{8}(?!$)", @"$0_");

    //==========================================================================================================================================================
    internal static string IntToHexString( s8 A) => ((int)A).ToString("X2");
    internal static string IntToHexString( u8 A) =>        A.ToString("X2");
    internal static string IntToHexString(s16 A) =>        A.ToString("X4");
    internal static string IntToHexString(u16 A) =>        A.ToString("X4");
    internal static string IntToHexString(s32 A) =>                                         $"{(A>>16)&0xFFFF:X4}_{A&0xFFFF:X4}";
    internal static string IntToHexString(u32 A) =>                                         $"{(A>>16)&0xFFFF:X4}_{A&0xFFFF:X4}";
    internal static string IntToHexString(s64 A) => $"{(A>>48)&0xFFFF:X4}_{(A>>32)&0xFFFF:X4}_{(A>>16)&0xFFFF:X4}_{A&0xFFFF:X4}";
    internal static string IntToHexString(u64 A) => $"{(A>>48)&0xFFFF:X4}_{(A>>32)&0xFFFF:X4}_{(A>>16)&0xFFFF:X4}_{A&0xFFFF:X4}";

    //==========================================================================================================================================================
    internal static string CommaDelimit(s16 A, int N=3) => Regex.Replace(A.ToString(), @"(?<=\d)(?=(\d{" + N.ToString() + @"})+(?!\d))", ",");
    internal static string CommaDelimit(u16 A, int N=3) => Regex.Replace(A.ToString(), @"(?<=\d)(?=(\d{" + N.ToString() + @"})+(?!\d))", ",");
    internal static string CommaDelimit(s32 A, int N=3) => Regex.Replace(A.ToString(), @"(?<=\d)(?=(\d{" + N.ToString() + @"})+(?!\d))", ",");
    internal static string CommaDelimit(u32 A, int N=3) => Regex.Replace(A.ToString(), @"(?<=\d)(?=(\d{" + N.ToString() + @"})+(?!\d))", ",");
    internal static string CommaDelimit(s64 A, int N=3) => Regex.Replace(A.ToString(), @"(?<=\d)(?=(\d{" + N.ToString() + @"})+(?!\d))", ",");
    internal static string CommaDelimit(u64 A, int N=3) => Regex.Replace(A.ToString(), @"(?<=\d)(?=(\d{" + N.ToString() + @"})+(?!\d))", ",");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 String Is <Something>
    //==========================================================================================================================================================
    internal static bool IsNumeric(this string STR, bool Signed=false, bool Fractional=false) {
        if (STR.IsVoid())
            return false;

        string Pattern = (Signed     ? @"^(\-)?"             : @"^"      )
                       + (Fractional ? @"[0-9]*(\.)?[0-9]+$" : @"[0-9]+$");

        return new Regex(Pattern).IsMatch(STR);
    }

    //==========================================================================================================================================================
    //
    //    NOTE: An obvious, yet easy-to-overlook, thing to note is that specified domain-strings are not validated.
    //          Though, they are Regex.Escaped.
    //
    //    NOTE: While this has gone through some testing to check for false-positives and false-negatives.
    //          A more rigorous test is still warranted.  Use at your own risk.
    //
    //      "user@sub.domain.top".IsValidEmailAddress()                       == TRUE
    //      "user@sub.domain.top".IsValidEmailAddress("top", "domain", "sub") == TRUE
    //      "user@sub.domain.top".IsValidEmailAddress("blarg")                == FALSE
    //
    internal static bool IsValidEmailAddress(this string STR, string DomainTop="", string Domain="", string DomainSub="") {
        /* Validate Input: STR */{
            const int MaxLen_Local        =  63;
            const int MaxLen_Domain       = 253;
            const int MaxLen_EmailAddress = MaxLen_Local + MaxLen_Domain + 1; //  317 == 253 + 63 + 1  for '@'

            if (STR.IsVoid())
                return false;

            //STR = STR.Trim();  This could be misleading, trim the string before testing|using|storing.

            if (STR.Length > MaxLen_EmailAddress)
                return false;

            string[] STR_Split = STR.Split('@');

            if (STR_Split.Length != 2)
                return false;

            if (STR_Split[0].IsVoid() || STR_Split[1].IsVoid())
                return false;

            if (STR_Split[0].Length > MaxLen_Local || STR_Split[1].Length > MaxLen_Domain)
                return false;
        }

        /* Regex: "<Local>@<Sub.Domain.Top>" */{
            //  0-9  A-Z  a-z  +  -  _  ~  !  #  $  %  &  ‘  .  /  =  ^  '  {  }  |
            string Ptrn_Local = @"[0-9A-Za-z\+\-_~!#\$%\&'./=\^{}\|]+";

            //  0-9  A-Z  a-z  -  (cannot end with -)
            string Ptrn_Domain  = (DomainSub.IsVoid() ? @"(?:[A-Za-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)?" : $@"{Regex.Escape(DomainSub)}\.");

                   Ptrn_Domain += (Domain   .IsVoid() ? @"[A-Za-z0-9](?:[a-z0-9-]*[a-z0-9])?\."      : $@"{Regex.Escape(Domain)   }\.");

            #if true
                   Ptrn_Domain += (DomainTop.IsVoid() ? @"[A-Za-z]{2,}(\.[A-Za-z]{2,})*"             : $@"{Regex.Escape(DomainTop)}"  ); //  Multi-part, such as: "co.uk"
            #else
                   Ptrn_Domain += (DomainTop.IsVoid() ? @"[A-Za-z]{2,}"                              : $@"{Regex.Escape(DomainTop)}"  );
            #endif

            return new Regex("^" + Ptrn_Local + "@" + Ptrn_Domain + "$").IsMatch(STR);
        }
    }

    //==========================================================================================================================================================
    //
    //  "IsVoid" if:
    //      String == null
    //      String == ""
    //      String contains only whitespace characters.
    //
    //  Stupid:
    //      String.IsNullOrEmpty("blarg")
    //      String.IsNullOrWhiteSpace("blarg")      also checks for empty
    //
    //  Better:
    //      "blarg".IsVoid()
    //
    [In(line)] internal static bool IsVoid(this string STR) {
        if (STR == null)
            return true;

        for (int i = 0; i < STR.Length; i++)
            if (!System.Char.IsWhiteSpace(STR[i]))
                return false; //  Is not void.

        return true; //  String does not contain any non-whitespace characters (this condition includes empty strings ""):
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  String Operators
    //==========================================================================================================================================================
    //
    //      "blarg".ContainsAny( {"ugh", "arg"} ) == TRUE
    //
    internal static bool ContainsAny(this string STR, string[] OfThese) {
        return OfThese.Any(x => STR.Contains(x));
    }

    //==========================================================================================================================================================
    //
    //      "blarg".ContainsAny_GetMatches( {"bla", "ugh", "arg"} ) == {"bla", "arg"}
    //
    internal static string[] ContainsAny_GetMatches(this string STR, string[] OfThese) {
        return OfThese.Where(x => STR.Contains(x))
                      .ToArray();
    }

    //==========================================================================================================================================================
    //
    //  This works on strings that contain newline "\n" characters.
    //  Though, does not explicitly check for or handle "\r\n" newlines.
    //
    //      "blarg\nblarg\nblarg".Indent() == "    blarg\n    blarg\n    blarg"
    //
    internal static string Indent(this string STR, int IndentSize = 4, char IndentWith = ' ') {
        string Indent = new System.String(IndentWith, IndentSize);

        if (STR.IsVoid())
            return Indent;

        if (STR.Contains("\n")) {
            string[] STR_Split = STR.Split('\n');
            string Result = "";

            foreach (string line in STR_Split)
                Result += Indent + line + "\n";

            return Regex.Replace(Result, @"\n$", "");

        } else {
            return Indent + STR;
        }
    }

    //==========================================================================================================================================================
    //
    //      "blargblargblarg".InsertEvery(5, ", ") == "blarg, blarg, blarg"
    //
    internal static string InsertEvery(this string STR, uint nChars, string InsertMe, bool NotAtEnd = true) {
        return Regex.Replace(STR,
            ".{" + $"{nChars}" + "}" + (NotAtEnd ? "(?!$)" : ""),
            "$0" + InsertMe
        );
    }

    //==========================================================================================================================================================
    //
    //  This works on strings that contain newline "\n" characters.
    //  Though, does not explicitly check for or handle "\r\n" newlines.
    //
    //      "blarg".Pad(-10) == "     blarg"
    //      "blarg".Pad( 10) == "blarg     "
    //
    internal static string Pad(this string STR, int PadSize, char PadWith = ' ') {
        if (STR.IsVoid())
            return new System.String(PadWith, PadSize);

        if (STR.Contains("\n")) {
            string[] STR_Split = STR.Split('\n');
            string Result = "";

            if (PadSize < 0)
                foreach (string line in STR_Split)
                    Result += line.PadLeft(-PadSize, PadWith) + "\n";
            else
                foreach (string line in STR_Split)
                    Result += line.PadRight(PadSize, PadWith) + "\n";

            return Regex.Replace(Result, @"\n$", "");
        }

        return (PadSize < 0) ? STR.PadLeft(-PadSize, PadWith)
                             : STR.PadRight(PadSize, PadWith);
    }

    //==========================================================================================================================================================
    //
    //  This works on strings that contain newline "\n" characters.
    //  Though, does not explicitly check for or handle "\r\n" newlines.
    //
    //      "blarg\nblarg\nblarg".Prepend(" ~~ ") == " ~~ blarg\n ~~ blarg\n ~~ blarg"
    //
    internal static string Prepend(this string STR, string PrependWith) {
        if (STR.IsVoid())
            return PrependWith;

        if (STR.Contains("\n")) {
            string[] STR_Split = STR.Split('\n');
            string Result = "";

            foreach (string line in STR_Split)
                Result += PrependWith + line + "\n";

            return Regex.Replace(Result, @"\n$", "");

        } else {
            return PrependWith + STR;
        }
    }

    //==========================================================================================================================================================
    //
    //      "blarg".Repeat(3) == "blargblargblarg"
    //
    internal static string Repeat(this string STR, int Count) {
        return (Count <= 0 || STR == null || STR == "") ? ""
             : (Count == 1)                             ? STR
                                                        : new StringBuilder(STR.Length * Count).Insert(0, STR, Count).ToString();
    }

    //==========================================================================================================================================================
    //
    //      "blarg BLARG bLaRg".ToTitleCase() == "Blarg Blarg Blarg"
    //
    internal static string ToTitleCase(this string STR) {
        if (STR.IsVoid())
            return "";

        char[] Result = STR.ToLower().ToCharArray();
        bool CapitalizeNext = true;

        for (int i = 0; i < Result.Length; i++) {
            if (char.IsWhiteSpace(Result[i])) {
                CapitalizeNext = true;
            } else if (CapitalizeNext && char.IsLetter(Result[i])) {
                Result[i] = char.ToUpper(Result[i]);
                CapitalizeNext = false;
            }
        }

        return new string(Result);
    }

    [In(line)] internal static string ToLowerCase(this string STR) => STR.ToLower();
    [In(line)] internal static string ToUpperCase(this string STR) => STR.ToUpper();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
