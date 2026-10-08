using iEx = System.IndexOutOfRangeException;

namespace Utility;
internal static class Array_Indexing {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Get previous|next Array-Item from "i", with Array.Length wrapping.
    //
    //      A.prev(i)    is equivalent to    A.prev(i,1)
    //      A.next(i)    is equivalent to    A.next(i,1)
    //      A.prev(i,2)
    //      A.next(i,2)
    //
    //  NOTE:  "ref"
    //    struct MyStruct {}
    //    MyStruct[] Things;
    //    ref MyStruct A = ref Things.next(i);        Modifying "A" will     alter array-item.  Reassignment of "A" will     alter array-item.
    //        MyStruct B =     Things.next(i);        Modifying "B" will NOT alter array-item.  Reassignment of "B" will NOT alter array-item.  Stores copy of array-item.
    //
    //    class MyClass {}
    //    MyClass[] Things;
    //    ref MyClass A = ref Things.next(i);         Modifying "A" will     alter array-item.  Reassignment of "A" will     alter array-item.
    //        MyClass B =     Things.next(i);         Modifying "B" will     alter array-item.  Reassignment of "B" will NOT alter array-item.
    //
    //==========================================================================================================================================================
    [In(line)] internal static ref T prev<T>(this T[] A, int i)                         => ref A[(   --i <         0) ?      A.Length - 1 : i];
    [In(line)] internal static ref T next<T>(this T[] A, int i)                         => ref A[(   ++i >= A.Length) ?                 0 : i];

    [In(line)] internal static ref T prev<T>(this T[] A, int i,           int A_Length) => ref A[(   --i <         0) ?      A_Length - 1 : i]; //  Override "A.Length" version.
    [In(line)] internal static ref T next<T>(this T[] A, int i,           int A_Length) => ref A[(   ++i >= A_Length) ?                 0 : i];

    //==========================================================================================================================================================
    //
    //  NOTE:  These only wrap 1 iteration of Array.Length.
    //
  //[In(line)] internal static ref T prev<T>(this T[] A, int i, int Step)               => ref A[(i-Step <         0) ? i-Step + A.Length : i-Step];
  //[In(line)] internal static ref T next<T>(this T[] A, int i, int Step)               => ref A[(i+Step >= A.Length) ? i+Step - A.Length : i+Step];

    [In(line)] internal static ref T prev<T>(this T[] A, int i, int Step, int A_Length) => ref A[(i-Step <         0) ? i-Step + A_Length : i-Step]; //  Override "A.Length" version.
    [In(line)] internal static ref T next<T>(this T[] A, int i, int Step, int A_Length) => ref A[(i+Step >= A_Length) ? i+Step - A_Length : i+Step];

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Get previous|next Index from "i", with Array.Length wrapping.
    //  Essentially, a less-gross version of "wrap()" that only works with positive integers in the 0 to N range.
    //
    //      A[ prev(i, A.Length) ]     is equivalent to    A[ prev(i, 1, A.Length) ]
    //      A[ next(i, A.Length) ]     is equivalent to    A[ next(i, 1, A.Length) ]
    //
    //      A[ prev(i, 2, A.Length) ]
    //      A[ next(i, 2, A.Length) ]
    //
    //==========================================================================================================================================================
    [In(line)] internal static s32 prev(s32 i,           s32 A_Len) => (--i <    0  ) ? A_Len-1 : i;
    [In(line)] internal static s64 prev(s64 i,           s64 A_Len) => (--i <    0  ) ? A_Len-1 : i;

    [In(line)] internal static s32 next(s32 i,           s32 A_Len) => (++i >= A_Len) ?    0    : i;
    [In(line)] internal static s64 next(s64 i,           s64 A_Len) => (++i >= A_Len) ?    0    : i;

    //==========================================================================================================================================================
    //
    //  NOTE:  These only wrap 1 iteration of Array.Length.
    //
    [In(line)] internal static s32 prev(s32 i, s32 Step, s32 A_Len) => ((i -= Step) <    0  ) ? i+A_Len : i;
    [In(line)] internal static s64 prev(s64 i, s64 Step, s64 A_Len) => ((i -= Step) <    0  ) ? i+A_Len : i;

    [In(line)] internal static s32 next(s32 i, s32 Step, s32 A_Len) => ((i += Step) >= A_Len) ? i-A_Len : i;
    [In(line)] internal static s64 next(s64 i, s64 Step, s64 A_Len) => ((i += Step) >= A_Len) ? i-A_Len : i;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static s32 step(s32 i, s32 Step, s32 A_Len) => ((i += Step) < 0)  ?  i+A_Len  :  (i >= A_Len)  ?  i-A_Len  :  i;
    [In(line)] internal static s64 step(s64 i, s64 Step, s64 A_Len) => ((i += Step) < 0)  ?  i+A_Len  :  (i >= A_Len)  ?  i-A_Len  :  i;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      A[ idx(iX, iY, DimX) ];
    //      A[ idx(iXY, DimX|DimXY) ];
    //
    //      A[ idx(iX, iY, iZ, DimX, DimY) ];
    //      A[ idx(iXYZ, DimX, DimY) ];
    //      A[ idx(iXYZ, DimXY|DimXYZ) ];
    //
    //  NOTE:  Debug versions don't always have enough information to verify "iY" or "iZ" is in range of its Dimension.
    //         Though, the purpose of this is to cleanup & encapsulate mundane index math.
    //
    //==========================================================================================================================================================
#if DEBUG
    [In(line)] internal static int idx(i1 iX, i1 iY,        i1 DimX)          => (iX   < 0 || iX   >=        DimX      ) ? throw new iEx() : iX  + (iY  * DimX );
    [In(line)] internal static int idx(i2 i,                i1 DimX)          => (i.x  < 0 || i.x  >=        DimX      ) ? throw new iEx() : i.x + (i.y * DimX );
    [In(line)] internal static int idx(i2 i,                i2 Dim)           => (i    < 0 || i    >=        Dim       ) ? throw new iEx() : i.x + (i.y * Dim.x); //  full validation

    [In(line)] internal static int idx(i1 iX, i1 iY, i1 iZ, i1 DimX, i1 DimY) {i2 i = (iX,iY); return
                                                                                 (i    < 0 || i    >= new i2(DimX,DimY)) ? throw new iEx() : iX  + (iY  * DimX ) + (iZ  * DimX  * DimY );}
    [In(line)] internal static int idx(i3 i,                i1 DimX, i1 DimY) => (i.xy < 0 || i.xy >= new i2(DimX,DimY)) ? throw new iEx() : i.x + (i.y * DimX ) + (i.z * DimX  * DimY );
    [In(line)] internal static int idx(i3 i,                i2 Dim          ) => (i.xy < 0 || i.xy >=        Dim       ) ? throw new iEx() : i.x + (i.y * Dim.x) + (i.z * Dim.x * Dim.y);
    [In(line)] internal static int idx(i3 i,                i3 Dim          ) => (i    < 0 || i    >=        Dim       ) ? throw new iEx() : i.x + (i.y * Dim.x) + (i.z * Dim.x * Dim.y); //  full validation

#else
    [In(line)] internal static int idx(i1 iX, i1 iY,        i1 DimX)          => iX  + (iY  * DimX );
    [In(line)] internal static int idx(i2 i,                i1 DimX)          => i.x + (i.y * DimX );
    [In(line)] internal static int idx(i2 i,                i2 Dim)           => i.x + (i.y * Dim.x);

    [In(line)] internal static int idx(i1 iX, i1 iY, i1 iZ, i1 DimX, i1 DimY) => iX  + (iY  * DimX ) + (iZ  * DimX  * DimY );
    [In(line)] internal static int idx(i3 i,                i1 DimX, i1 DimY) => i.x + (i.y * DimX ) + (i.z * DimX  * DimY );
    [In(line)] internal static int idx(i3 i,                i2 Dim          ) => i.x + (i.y * Dim.x) + (i.z * Dim.x * Dim.y);
    [In(line)] internal static int idx(i3 i,                i3 Dim          ) => i.x + (i.y * Dim.x) + (i.z * Dim.x * Dim.y);
#endif

    //==========================================================================================================================================================

    //  Wrapping versions of idx() ???     widx()  wrapidx()  wrapi()

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
