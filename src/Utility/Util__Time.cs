using Stopwatch = System.Diagnostics.Stopwatch;
using Thread    = System.Threading.Thread;

namespace Utility;
internal struct TIME {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public f64 DeltaClamp = 0d;
    public f64 Delta64      {get; private set;} = 0d;
    public f32 Delta        {get; private set;} = 0f;

    public f64 DeltaAvg_Weight = 0d;
    public f64 DeltaAvg64   {get; private set;} = 0d;
    public f32 DeltaAvg     {get; private set;} = 0f;

  //public vec4 Cos         {get; private set;}                                 //  ( 1 hertz, 10 hertz, 30 hertz, 60 hertz )
  //public vec4 Sin         {get; private set;}

    public u64 Frame        {get; private set;} = 0;

    public readonly s64 Beginning = 0;
    public readonly f64 SinceBeginning64 => f64(this.ThisFrame-this.Beginning) / this.FloatFreq;    //  Absolute Delta

    public f64 SinceStart64 {get; private set;} = 0d;                           //  Cumulative Delta
    public f32 SinceStart   {get; private set;} = 0f;

    public f64 Seconds      {get; private set;} = 0d;
    public s64 Minutes      {get; private set;} = 0;
    public s64 Hours        {get; private set;} = 0;

    public readonly string HMS   => $"{Hours:00}:{Minutes:00}:{Seconds:00}";
    public readonly string HMSf  => $"{Hours:00}:{Minutes:00}:{Seconds:00.000}";
    public readonly string HMSff => $"{Hours:00}:{Minutes:00}:{Seconds:00.000000}";

    public static s64  Frequency => Stopwatch.Frequency;                        //  Ticks PerSecond.    10,000,000      1/t == 0.000_000_1      0.1 MicroSeconds
    public static bool IsHighRes => Stopwatch.IsHighResolution;                 //                      true

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    private f64 FloatFreq = 0d;

    private s64 PrevFrame = 0;
    private s64 ThisFrame = 0;
    private s64 NextFrame = 0;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public bool LimitFrameRate = false;
    private s64 TargetFrameRate = 240;
    private s64 FrameStep       =   0;
    private s64 OneMillis       =   0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public TIME() : this(1d/24d) {}

    public TIME(f64 dAvg_Weight) {
        this.DeltaAvg_Weight = dAvg_Weight;
        this.DeltaAvg64      = 1d/60d;
        this.DeltaAvg        = 1f/60f;

        this.FloatFreq = f64(Stopwatch.Frequency);

        this.Beginning = Stopwatch.GetTimestamp();
        this.PrevFrame = this.Beginning;
        this.ThisFrame = this.Beginning;

        this.NextFrame = this.Beginning;
        this.FrameStep = (Stopwatch.Frequency/this.TargetFrameRate);
        this.OneMillis = (Stopwatch.Frequency/1000);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void SetTargetFrameRate(s64 Target) {
        this.TargetFrameRate = clamp(Target, 15, 960);
        this.FrameStep = (Stopwatch.Frequency/this.TargetFrameRate);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //public void Update(f64 Speed = 1d) {
    public void Update() {
        #if true
            this.NextFrame += this.FrameStep;
            while (this.LimitFrameRate) {
                s64 DeltaNext = this.NextFrame - Stopwatch.GetTimestamp();
                if (DeltaNext <= 0) break;
                //if (DeltaNext > this.OneMillis) Thread.Sleep(1);       //  Sleep time-resolution is 1/64 (15.625 ms).  :(
                if (DeltaNext > this.OneMillis) Thread.Yield();          //  If there is no other process that wants to use the CPU core, Yield() will return immediately.
                //if (DeltaNext > this.OneMillis) Thread.SpinWait(64);   //  Parameter is "loop iterations".  Highly variable, dependent on CPU performance/speed.
            }
        #endif

        this.ThisFrame = Stopwatch.GetTimestamp();
        ++this.Frame;

        this.Delta64 = f64(this.ThisFrame-this.PrevFrame) / this.FloatFreq;
        if (this.DeltaClamp > 0d) {this.Delta64 = min(this.DeltaClamp, this.Delta64);}
        this.Delta = f32(this.Delta64);

        this.DeltaAvg64 += (this.Delta64 - this.DeltaAvg64) * DeltaAvg_Weight;
        this.DeltaAvg    = f32(this.DeltaAvg64);

        this.Seconds += this.Delta64;
        if (this.Seconds >= 60d) {
            this.Seconds -= 60d;
            this.Minutes +=  1;
            if (this.Minutes >= 60) {
                this.Minutes -= 60;
                this.Hours   +=  1;
            }
        }

        this.SinceStart64 = f64(this.Hours*3600L + this.Minutes*60L) + this.Seconds;
        this.SinceStart   = f32(this.SinceStart64);

        this.PrevFrame = this.ThisFrame;

        //(this.Sin.x, this.Cos.x) = ((f32, f32))Math.SinCos(this.Seconds * 0.10471975511965977462d); //  1 hertz
        //(this.Sin.y, this.Cos.y) = ((f32, f32))Math.SinCos(this.Seconds * 1.04719755119659774615d); // 10 hertz  https://www.desmos.com/calculator/e4f49ebeb2
        //(this.Sin.z, this.Cos.z) = ((f32, f32))Math.SinCos(this.Seconds * 3.14159265358979323846d); // 30 hertz
        //(this.Sin.w, this.Cos.w) = ((f32, f32))Math.SinCos(this.Seconds * 6.28318530717958647693d); // 60 hertz
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
