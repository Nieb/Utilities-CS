using System;
using MemoryMarshal = System.Runtime.InteropServices.MemoryMarshal;

namespace Utility;
internal static partial class DATA {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal readonly struct DataArray {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public readonly u8[] Data;

    public readonly u8 this[int i] {
        [In(line)] get => this.Data[i];
        [In(line)] set => this.Data[i] = value;
    }

    //==========================================================================================================================================================
    //                                                              Returns a "view of Data" as a...
    public readonly Span< s8>  s8 => MemoryMarshal.Cast<u8, s8>(Data); //  "Span of sbytes"
    public readonly Span< u8>  u8 => MemoryMarshal.Cast<u8, u8>(Data); //  "Span of  bytes"

    public readonly Span<f16> f16 => MemoryMarshal.Cast<u8,f16>(Data); //  "Span of halves"      truncated if Data.Length is not multiple of 2
    public readonly Span<s16> s16 => MemoryMarshal.Cast<u8,s16>(Data); //  "Span of  shorts"
    public readonly Span<u16> u16 => MemoryMarshal.Cast<u8,u16>(Data); //  "Span of ushorts"

    public readonly Span<f32> f32 => MemoryMarshal.Cast<u8,f32>(Data); //  "Span of floats"      truncated if Data.Length is not multiple of 4
    public readonly Span<s32> s32 => MemoryMarshal.Cast<u8,s32>(Data); //  "Span of  ints"
    public readonly Span<u32> u32 => MemoryMarshal.Cast<u8,u32>(Data); //  "Span of uints"

    public readonly Span<f64> f64 => MemoryMarshal.Cast<u8,f64>(Data); //  "Span of doubles"     truncated if Data.Length is not multiple of 8
    public readonly Span<s64> s64 => MemoryMarshal.Cast<u8,s64>(Data); //  "Span of  longs"
    public readonly Span<u64> u64 => MemoryMarshal.Cast<u8,u64>(Data); //  "Span of ulongs"

    //==========================================================================================================================================================
    [In(line)] public DataArray()         => this.Data = new u8[0];
    [In(line)] public DataArray(int Size) => this.Data = new u8[Size];

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan< s8> B) => B.CopyTo(this. s8[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan< u8> B) => B.CopyTo(this. u8[I..]);

    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<f16> B) => B.CopyTo(this.f16[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<s16> B) => B.CopyTo(this.s16[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<u16> B) => B.CopyTo(this.u16[I..]);

    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<f32> B) => B.CopyTo(this.f32[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<s32> B) => B.CopyTo(this.s32[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<u32> B) => B.CopyTo(this.u32[I..]);

    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<f64> B) => B.CopyTo(this.f64[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<s64> B) => B.CopyTo(this.s64[I..]);
    [In(line)] public readonly void SetFrom(int I, ReadOnlySpan<u64> B) => B.CopyTo(this.u64[I..]);

    //==========================================================================================================================================================
    //[In(line)] public readonly void SetFrom(int I, params  s8[] B) => ((ReadOnlySpan< s8>)B).CopyTo(this. s8[I..]); //params ReadOnlySpan< s8> B
    //[In(line)] public readonly void SetFrom(int I, params  u8[] B) => ((ReadOnlySpan< u8>)B).CopyTo(this. u8[I..]); //params ReadOnlySpan< u8> B

    //[In(line)] public readonly void SetFrom(int I, params f16[] B) => ((ReadOnlySpan<f16>)B).CopyTo(this.f16[I..]); //params ReadOnlySpan<f16> B
    //[In(line)] public readonly void SetFrom(int I, params s16[] B) => ((ReadOnlySpan<s16>)B).CopyTo(this.s16[I..]); //params ReadOnlySpan<s16> B
    //[In(line)] public readonly void SetFrom(int I, params u16[] B) => ((ReadOnlySpan<u16>)B).CopyTo(this.u16[I..]); //params ReadOnlySpan<u16> B

    //[In(line)] public readonly void SetFrom(int I, params f32[] B) => ((ReadOnlySpan<f32>)B).CopyTo(this.f32[I..]); //params ReadOnlySpan<f32> B
    //[In(line)] public readonly void SetFrom(int I, params s32[] B) => ((ReadOnlySpan<s32>)B).CopyTo(this.s32[I..]); //params ReadOnlySpan<s32> B  not available in C# 12.0
    //[In(line)] public readonly void SetFrom(int I, params u32[] B) => ((ReadOnlySpan<u32>)B).CopyTo(this.u32[I..]); //params ReadOnlySpan<u32> B

    //[In(line)] public readonly void SetFrom(int I, params f64[] B) => ((ReadOnlySpan<f64>)B).CopyTo(this.f64[I..]); //params ReadOnlySpan<f64> B
    //[In(line)] public readonly void SetFrom(int I, params s64[] B) => ((ReadOnlySpan<s64>)B).CopyTo(this.s64[I..]); //params ReadOnlySpan<s64> B
    //[In(line)] public readonly void SetFrom(int I, params u64[] B) => ((ReadOnlySpan<u64>)B).CopyTo(this.u64[I..]); //params ReadOnlySpan<u64> B

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
