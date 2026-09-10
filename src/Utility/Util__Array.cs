
namespace Utility;
internal static class Array {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [System.Runtime.CompilerServices.InlineArray( 2)] internal struct  InlineArray2_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 3)] internal struct  InlineArray3_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 4)] internal struct  InlineArray4_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 6)] internal struct  InlineArray6_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 8)] internal struct  InlineArray8_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray( 9)] internal struct  InlineArray9_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray(12)] internal struct InlineArray12_Float {private float i;}
    [System.Runtime.CompilerServices.InlineArray(16)] internal struct InlineArray16_Float {private float i;}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Get previous|next Array-Item from "i", with Array.Length wrapping.
    //
    //  NOTE: "ref"
    //    struct MyStruct {...}
    //    MyStruct[] Things;
    //    ref MyStruct A = ref Things.next(i);    //  Modifying "A" will     alter array-item.  Reassignment of "A" will     alter array-item.
    //        MyStruct B =     Things.next(i);    //  Modifying "B" will NOT alter array-item.  Reassignment of "B" will NOT alter array-item.  Stores copy of array-item.
    //
    //    class MyClass {...}
    //    MyClass[] Things;
    //    ref MyClass A = ref Things.next(i);     //  Modifying "A" will     alter array-item.  Reassignment of "A" will     alter array-item.
    //        MyClass B =     Things.next(i);     //  Modifying "B" will     alter array-item.  Reassignment of "B" will NOT alter array-item.
    //
    //      Blarg.prev(i)    is equivalent to:    Blarg.prev(i,1)
    //      Blarg.next(i)    is equivalent to:    Blarg.next(i,1)
    //      Blarg.prev(i,2)
    //      Blarg.next(i,2)
    //
    [Impl(AggressiveInlining)] internal static ref T prev<T>(this T[] A, int i)           => ref A[(   --i <         0) ?      A.Length - 1 : i];
    [Impl(AggressiveInlining)] internal static ref T next<T>(this T[] A, int i)           => ref A[(   ++i >= A.Length) ?                 0 : i];

    [Impl(AggressiveInlining)] internal static ref T prev<T>(this T[] A, int i, int Step) => ref A[(i-Step <         0) ? i-Step + A.Length : i-Step];
    [Impl(AggressiveInlining)] internal static ref T next<T>(this T[] A, int i, int Step) => ref A[(i+Step >= A.Length) ? i+Step - A.Length : i+Step];

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Is NULL or Empty.   (A == null || A.Length == 0);
    //
    //      Blarg.IsVoid()
    //
    [Impl(AggressiveInlining)] internal static bool IsVoid<T>(this T[] A) => (A?.Length ?? 0) == 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
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
    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static int Count<T>(this T[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining)] internal static int Count(this string A) => (A == null || A == "") ? 0 : A.Length;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static int Length<T>(this T[] A) => (A == null) ? -1 : A.Length-1;
    [Impl(AggressiveInlining)] internal static int Length(this string A) => (A == null || A == "") ? -1 : A.Length-1;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      Blarg.Clear();
    //
    [Impl(AggressiveInlining)] internal static void Clear<T>(this T[] A) => System.Array.Clear(A);

    //==========================================================================================================================================================
    //
    //      Blarg.FillWith( ThisValue );
    //
    [Impl(AggressiveInlining)] internal static void FillWith(this  s8[] A,  s8 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void FillWith(this  u8[] A,  u8 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void FillWith(this s16[] A, s16 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void FillWith(this u16[] A, u16 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void FillWith(this s32[] A, s32 V) => System.Array.Fill(A, V);
    [Impl(AggressiveInlining)] internal static void FillWith(this u32[] A, u32 V) => System.Array.Fill(A, V);

    [Impl(AggressiveInlining)] internal static void FillWith(this f32[] A, f32 V) => System.Array.Fill(A, V);

  //[Impl(AggressiveInlining)] internal static void FillWith<T>(this T[] A, T V) => System.Array.Fill(A, V);

    //==========================================================================================================================================================
    //
    //  This was used as a temporary hack.  If this ends up in production code, you're probably doing something stupid.  :P
    //
    //      Blarg.IndexFill();
    //
    [Impl(AggressiveInlining)] internal static void IndexFill(this  s8[] A) {for (int i=0; i<A.Length; ++i) {A[i] =  (s8)i;}}
    [Impl(AggressiveInlining)] internal static void IndexFill(this  u8[] A) {for (int i=0; i<A.Length; ++i) {A[i] =  (u8)i;}}
    [Impl(AggressiveInlining)] internal static void IndexFill(this s16[] A) {for (int i=0; i<A.Length; ++i) {A[i] = (s16)i;}}
    [Impl(AggressiveInlining)] internal static void IndexFill(this u16[] A) {for (int i=0; i<A.Length; ++i) {A[i] = (u16)i;}}
    [Impl(AggressiveInlining)] internal static void IndexFill(this s32[] A) {for (int i=0; i<A.Length; ++i) {A[i] =      i;}}
    [Impl(AggressiveInlining)] internal static void IndexFill(this u32[] A) {for (int i=0; i<A.Length; ++i) {A[i] = (u32)i;}}

    //==========================================================================================================================================================
    //
    //  This would be better, but alas...
    //      Blarg[i..] = [Values, To, Set, Etc];
    //
    //      Blarg.SetFrom(i,   Values, To, Set, Etc);
    //
    [Impl(AggressiveInlining)] internal static void SetFrom(this  s8[] A, int I, params  s8[] B) => B.CopyTo(A, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this  u8[] A, int I, params  u8[] B) => B.CopyTo(A, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this s16[] A, int I, params s16[] B) => B.CopyTo(A, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this u16[] A, int I, params u16[] B) => B.CopyTo(A, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this s32[] A, int I, params s32[] B) => B.CopyTo(A, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this u32[] A, int I, params u32[] B) => B.CopyTo(A, I);

    [Impl(AggressiveInlining)] internal static void SetFrom(this f32[] A, int I, params f32[] B) => B.CopyTo(A, I);

    [Impl(AggressiveInlining)] internal static void SetFrom(this Data32[] A, int I, params Data32[] B) => B.CopyTo(A, I);
    [Impl(AggressiveInlining)] internal static void SetFrom(this Data64[] A, int I, params Data64[] B) => B.CopyTo(A, I);

  //[Impl(AggressiveInlining)] internal static void SetFrom<T>(this T[] A, int I, params T[] B) => B.CopyTo(A, I);  fails to determine type...

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Immediately GarbageCollect an Array.
    //
    //  This only works when used upon the original ref from the originating scope.
    //  Also, there must be no additional references stored elsewhere.
    //
    //      Delete(ref Blarg);
    //      DeleteAndCollect(ref Blarg); ...
    //
    [Impl(AggressiveInlining)] internal static void Delete<T>(ref T[] A) {A = null; System.GC.Collect(); System.GC.WaitForPendingFinalizers();}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This method allocates a new array with the specified size,
    //  copies elements from the old array to the new one,
    //  and then replaces the old array reference with the new one.
    //
    //  Array must be one-dimensional.
    //
    //      Resize(ref Blarg, ItemCount);
    //
    [Impl(AggressiveInlining)] internal static void Resize<T>(ref T[] A, int Size) => System.Array.Resize(ref A, (Size<0) ? 0 : Size);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
