using Conditional = System.Diagnostics.ConditionalAttribute;
using ConOut      = System.Console;

namespace DEBUG;
internal static partial class PRINTOUT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Conditional("DEBUG")] internal static void CONOUTS(string PrintMe="", bool StartWithNL=false, bool EndWithNL=false, int FrameOffset=1) {
        #if DEBUG
            #pragma warning disable IL2026
                //  Using member 'System.Diagnostics.StackFrame.GetMethod()' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code.
                //  Metadata for the method might be incomplete or removed.
                var StackFrameMethod = new System.Diagnostics.StackTrace().GetFrame(FrameOffset).GetMethod();
            #pragma warning restore IL2026

            string CallLoc_Class = (StackFrameMethod.DeclaringType != null) ? StackFrameMethod.DeclaringType.Name
                                                                            : "ANONYMOUS";

            string CallLoc_Method = StackFrameMethod.Name;
            if (CallLoc_Method == ".ctor")
                CallLoc_Method = "INSTANTIATE"; //  ".ctor" is a Constructor call.

            string CallLoc = $"{CallLoc_Class}.{CallLoc_Method}";
            int CallLoc_Len = CallLoc.Length;

            if (CallLoc_Len > 34) {
                CallLoc_Class = CallLoc_Class.Substring(0, max(0, CallLoc_Class.Length - (CallLoc_Len - 34)))+"~";
                CallLoc = $"{CallLoc_Class}.{CallLoc_Method}";
            }

            string Result = $"[{DateTime("HH:mm:ss.ffffff")}] {CallLoc,34}:  {PrintMe}";

            System.Console.WriteLine(
                  (StartWithNL ? "\n" : "")
                +  Result
                + (EndWithNL ? "\n" : "")
            );
        #endif
    }

    [Conditional("DEBUG")] internal static void CONOUTS(object PrintMe, bool StartWithNL=false, bool EndWithNL=false, int FrameOffset=1) =>
        CONOUTS($"{PrintMe}", StartWithNL, EndWithNL, FrameOffset+1);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Conditional("DEBUG")] internal static void CONOUTFS(string PrintMe="", bool StartWithNL=false, bool EndWithNL=false, int FrameOffset=1) {
        #if DEBUG
        #pragma warning disable IL2026 // Using member '*' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code.
            var frames = new System.Diagnostics.StackTrace().GetFrames();

            string callStackChain = "UNKNOWN";

            if (frames != null && frames.Length > FrameOffset) {
                var pathParts = new System.Collections.Generic.List<string>();

                // Loop backward from the deepest frame up to your FrameOffset
                for (int i = frames.Length - 1; i >= FrameOffset; i--) {
                    var method = frames[i].GetMethod();
                    if (method == null) continue;

                    // Skip core runtime/system frames if you want cleaner output
                    string className = method.DeclaringType != null ? method.DeclaringType.Name : "ANONYMOUS";
                    string methodName = method.Name == ".ctor" ? "INSTANTIATE" : method.Name;

                    pathParts.Add($"{className}.{methodName}");
                }

                if (pathParts.Count > 0) {
                    callStackChain = "\n -> " + string.Join("\n -> ", pathParts);
                }
            }

            // Optional: Truncate the chain if it gets too long for your layout
            //if (callStackChain.Length > 60) {
            //    callStackChain = "..." + callStackChain.Substring(callStackChain.Length - 57);
            //}

            string Result = $"[{DateTime("HH:mm:ss.ffffff")}]:  {PrintMe}{callStackChain}";

            System.Console.WriteLine(
                  (StartWithNL ? "\n" : "")
                + Result
                + (EndWithNL ? "\n" : "")
            );
        #pragma warning restore IL2026
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
