
namespace DEBUG;
internal static class PROFILE {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      PROFILE_Start();
    //
    //      ...
    //
    //      PROFILE_End();
    //
    //      CONOUT($"{PROFILE_Result():F6}");
    //
    private static s64 TimeStamp_Start = 0;
    private static s64 TimeStamp_End   = 0;

    [In(line)] public static void PROFILE_Start() => TimeStamp_Start = System.Diagnostics.Stopwatch.GetTimestamp();
    [In(line)] public static void PROFILE_End()   => TimeStamp_End   = System.Diagnostics.Stopwatch.GetTimestamp();

    [In(line)] public static f64 PROFILE_Result() => (TimeStamp_End - TimeStamp_Start) / (f64)System.Diagnostics.Stopwatch.Frequency;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
