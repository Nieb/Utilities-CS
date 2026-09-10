using System;
using Rune          = System.Text.Rune;
using StringBuilder = System.Text.StringBuilder;

namespace Utility;
public struct DimString {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public int CursorPosX {get; private set;}
    public int CursorPosY {get; private set;}
    public readonly int CursorPos => (CursorPosY * this.SizeX) + CursorPosX;

    public readonly int SizeX;
    public readonly int SizeY;
    public readonly int Size => (SizeX * SizeY);

    private Rune[] Text; //  Rune[] insures:  Array.Length == MaxCharacterCount

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public DimString() : this(1,1) {}

    public DimString(int CharsPerLine, int NumOfLines) {
        if (CharsPerLine < 1) throw new System.ArgumentOutOfRangeException(nameof(CharsPerLine));
        if (NumOfLines   < 1) throw new System.ArgumentOutOfRangeException(nameof(NumOfLines));

        this.CursorPosX = 0;
        this.CursorPosY = 0;

        this.SizeX = CharsPerLine;
        this.SizeY = NumOfLines;

        this.Text = new Rune[CharsPerLine * NumOfLines];
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public void Clear() {
        this.CursorPosX = 0;
        this.CursorPosY = 0;
        System.Array.Clear(this.Text);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //[Impl(AggressiveInlining)] public void FillWith(char c) => this.Text.AsSpan().Fill(new Rune(c));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] private void AdvanceCursorToNextLine() {this.CursorPosX = 0;  ++this.CursorPosY;}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //[Impl(AggressiveInlining)] public void SetCursorPosX(int X) => this.CursorPosX = clamp(X, 0, this.SizeX);
    //[Impl(AggressiveInlining)] public void SetCursorPosY(int Y) => this.CursorPosY = clamp(Y, 0, this.SizeY);
    //[Impl(AggressiveInlining)] public void SetCursorPos(int X, int Y) {
    //    this.CursorPosX = clamp(X, 0, this.SizeX);
    //    this.CursorPosY = clamp(Y, 0, this.SizeY);
    //}

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] private readonly int Index(int X, int Y) => X + (Y*this.SizeX);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public void Append(string S) => Append(S.AsSpan());

    public void Append(ReadOnlySpan<char> S) {
        if (this.CursorPosY >= this.SizeY)
            return;
        if (S.IsEmpty)
            return;

        int i = 0;
        char c;
        while (i < S.Length) {
            if (this.CursorPosY >= this.SizeY)
                return;

            //  If CursorPosX is beyond CharsPerLine, advance until NewLine or EndOfString.
            if (this.CursorPosX >= this.SizeX) {
                while (i < S.Length) {
                    c = S[i++];
                    if (c == '\n') {
                        this.AdvanceCursorToNextLine();
                        break;
                    } else if (c == '\r') {
                        if (i < S.Length && S[i] == '\n') ++i; // consume \n
                        this.AdvanceCursorToNextLine();
                        break;
                    }
                }
                continue;
            }

            c = S[i];

            if (c == '\n') {
                ++i;
                this.AdvanceCursorToNextLine();
                continue;
            }
            if (c == '\r') {
                ++i;
                if (i < S.Length && S[i] == '\n') ++i; // consume \n
                this.AdvanceCursorToNextLine();
                continue;
            }

            // Decode one Rune from UTF-16
            System.Buffers.OperationStatus DecodeStatus = Rune.DecodeFromUtf16(S.Slice(i), out Rune DecodedRune, out int DecodeConsumed);
            if (DecodeStatus != System.Buffers.OperationStatus.Done || DecodeConsumed <= 0) {
                // Replace invalid sequences with U+FFFD
                DecodedRune = Rune.ReplacementChar;
                DecodeConsumed = 1;
            }

            this.Text[Index(this.CursorPosX, this.CursorPosY)] = DecodedRune;
            ++this.CursorPosX;
            i += DecodeConsumed;
        }
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] public void AppendLine(string S) => AppendLine(S.AsSpan());

    [Impl(AggressiveInlining)] public void AppendLine(ReadOnlySpan<char> S) {
        if (this.CursorPosY >= this.SizeY)
            return;
        this.Append(S);
        this.AdvanceCursorToNextLine();
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public void AppendLine() {
        if (this.CursorPosY >= this.SizeY)
            return;
        this.AdvanceCursorToNextLine();
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //public readonly Span<Rune> AsSpan() => this.Text.AsSpan();

    public readonly override string ToString() {
        int SB_Capacity = (2 * this.SizeX*this.SizeY) + (this.SizeY - 1); //  Two Chars per-Rune,  plus newline Chars.
        var SB = new StringBuilder(SB_Capacity);
        //CONOUT($"{SB.Capacity}");

        Span<char> tmp = stackalloc char[2];

        for (int iY = 0; iY < this.SizeY; ++iY) {
            for (int iX = 0; iX < this.SizeX; ++iX) {
                Rune r = this.Text[Index(iX,iY)];

                if (r.Value == 0)
                    break;

                int CharsWritten = r.EncodeToUtf16(tmp);
                SB.Append(tmp.Slice(0, CharsWritten));
            }

            if (iY != this.SizeY - 1)
                SB.Append('\n');
        }

        //CONOUT($"{SB.Capacity}");
        return SB.ToString();
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
