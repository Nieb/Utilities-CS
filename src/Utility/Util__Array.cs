
namespace Utility;
internal static class Array {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.inlinearrayattribute?view=net-8.0
    //
    [System.Runtime.CompilerServices.InlineArray( 2)] internal struct  InlineArray2<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 3)] internal struct  InlineArray3<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 4)] internal struct  InlineArray4<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 5)] internal struct  InlineArray5<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 6)] internal struct  InlineArray6<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 7)] internal struct  InlineArray7<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 8)] internal struct  InlineArray8<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray( 9)] internal struct  InlineArray9<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(10)] internal struct InlineArray10<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(11)] internal struct InlineArray11<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(12)] internal struct InlineArray12<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(13)] internal struct InlineArray13<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(14)] internal struct InlineArray14<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(15)] internal struct InlineArray15<T>{private T i;}
    [System.Runtime.CompilerServices.InlineArray(16)] internal struct InlineArray16<T>{private T i;}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Is NULL or Empty.
    //
    //      Blarg.IsVoid()
    //
    [In(line)] internal static bool IsVoid<T>(this T[] A) => (A == null || A.Length == 0);

    //==========================================================================================================================================================
    //
    //  Proper "Length" method.  (zero inclusive)
    //
    //                    ●----|--->|
    //                    0    1    2
    //          Blarg = ["A", "B", "C"]
    //
    //      Blarg.Count()  == 3      0 is empty.
    //      Blarg.Length() == 2     -1 is empty.
    //
  //[In(line)] internal static int Count<T>(this T[] A)  => (A == null           ) ?  0 : A.Length;
  //[In(line)] internal static int Count(this string A)  => (A == null || A == "") ?  0 : A.Length;
  //
  //[In(line)] internal static int Length<T>(this T[] A) => (A == null           ) ? -1 : A.Length-1;    As much as I would prefer this,
  //[In(line)] internal static int Length(this string A) => (A == null || A == "") ? -1 : A.Length-1;    I don't want two co-existing things that behave differently.  (".Length" & ".Length()")

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      Blarg.Clear();
    //
    [In(line)] internal static void Clear<T>(this T[] A) => System.Array.Clear(A);

    //==========================================================================================================================================================
    //
    //  Immediately GarbageCollect an Array.
    //
    //  This only works when used upon the original ref from the originating scope.
    //  Also, there must be no additional references stored elsewhere.
    //
    //      Delete(ref Blarg);
    //      DeleteAndCollect(ref Blarg); ...
    //
    [In(line)] internal static void Delete<T>(ref T[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}

    //==========================================================================================================================================================
    //
    //  This method allocates a new array with the specified size,
    //  copies elements from the old array to the new one,
    //  and then replaces the old array reference with the new one.
    //
    //  Array must be one-dimensional.
    //
    //      Resize(ref Blarg, ItemCount);
    //
    [In(line)] internal static void Resize<T>(ref T[] A, int Size) => System.Array.Resize(ref A, Size);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      Blarg.FillWith( ThisValue );
    //
    [In(line)] internal static void FillWith<T>(this T[] A, T V) => System.Array.Fill(A, V);

    //==========================================================================================================================================================
    //
    //      Blarg.IndexFill();
    //
    [In(line)] internal static void IndexFill(this  s8[] A) {for (int i=0; i<A.Length; ++i) {A[i] =  (s8)i;}}
    [In(line)] internal static void IndexFill(this  u8[] A) {for (int i=0; i<A.Length; ++i) {A[i] =  (u8)i;}}
    [In(line)] internal static void IndexFill(this s16[] A) {for (int i=0; i<A.Length; ++i) {A[i] = (s16)i;}}
    [In(line)] internal static void IndexFill(this u16[] A) {for (int i=0; i<A.Length; ++i) {A[i] = (u16)i;}}
    [In(line)] internal static void IndexFill(this s32[] A) {for (int i=0; i<A.Length; ++i) {A[i] =      i;}}
    [In(line)] internal static void IndexFill(this u32[] A) {for (int i=0; i<A.Length; ++i) {A[i] = (u32)i;}}

    //==========================================================================================================================================================
    //
    //      Blarg.IndexOf(ValueToFind);
    //
    [In(line)] internal static int IndexOf<T>(this T[] A, T V) => System.Array.IndexOf(A, V);

    //==========================================================================================================================================================
    //
    //  This would be better, but alas...
    //      Blarg[i..] = [Values, To, Set, Etc];
    //
    //      Blarg.SetFrom(i,   Values, To, Set, Etc);
    //
  //[In(line)] internal static void SetFrom<T>(this T[] A, int I, params T[] B) => System.Array.ConstrainedCopy(
  //         sourceArray: B,      sourceIndex: 0,
  //    destinationArray: A, destinationIndex: I,  length: B.Length
  //);

  //[In(line)] internal static void SetFrom<T>(this T[] A, int I, System.ReadOnlySpan<T> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));

  //[In(line)] internal static void SetFrom<T_Dst, T_Src>(this T_Dst[] A, int I, System.ReadOnlySpan<T_Src> B)
  //where T_Dst: struct
  //where T_Src: struct, T_Dst {
  //    System.Runtime.InteropServices.MemoryMarshal.Cast<T_Src, T_Dst>(B)
  //        .CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
  //}

    [In(line)] internal static void SetFrom(this  s8[] A, int I, System.ReadOnlySpan< s8> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this  u8[] A, int I, System.ReadOnlySpan< u8> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this s16[] A, int I, System.ReadOnlySpan<s16> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this u16[] A, int I, System.ReadOnlySpan<u16> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this s32[] A, int I, System.ReadOnlySpan<s32> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this u32[] A, int I, System.ReadOnlySpan<u32> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));

    [In(line)] internal static void SetFrom(this f16[] A, int I, System.ReadOnlySpan<f16> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this f32[] A, int I, System.ReadOnlySpan<f32> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));
    [In(line)] internal static void SetFrom(this f64[] A, int I, System.ReadOnlySpan<f64> B) => B.CopyTo(System.MemoryExtensions.AsSpan(A, I, B.Length));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
