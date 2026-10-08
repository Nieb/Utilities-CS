
namespace UtilityTest;
internal static partial class Program {
static void Test___() {
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{

}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    TESTOUT("\nTesting \"VectorOps\"...");

    const int I = (1 << 24);
    double[] Sum    = new double[15];
    double[] Result = new double[15];

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 0] +=       clamp(Random1(),-Random1u(), Random1u());     PROFILE_End(); Result[ 0]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 1] +=       clamp(Random1());                             PROFILE_End(); Result[ 1]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 2] += sumof(clamp(Random2(),-Random1u(), Random1u()));    PROFILE_End(); Result[ 2]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 3] += sumof(clamp(Random2())                        );    PROFILE_End(); Result[ 3]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 4] += sumof(clamp(Random3(),-Random1u(), Random1u()));    PROFILE_End(); Result[ 4]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 5] += sumof(clamp(Random3())                        );    PROFILE_End(); Result[ 5]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 6] += sumof(clamp(Random4(),-Random1u(), Random1u()));    PROFILE_End(); Result[ 6]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 7] += sumof(clamp(Random4())                        );    PROFILE_End(); Result[ 7]=PROFILE_Result();

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 8] += sumof(cross(Random3(),Random3()));                  PROFILE_End(); Result[ 8]=PROFILE_Result();

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[ 9] +=         dot(Random2(),Random2());                   PROFILE_End(); Result[ 9]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[10] +=         dot(Random2());                             PROFILE_End(); Result[10]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[11] +=         dot(Random3(),Random3());                   PROFILE_End(); Result[11]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[12] +=         dot(Random3());                             PROFILE_End(); Result[12]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[13] +=         dot(Random4(),Random4());                   PROFILE_End(); Result[13]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[14] +=         dot(Random4());                             PROFILE_End(); Result[14]=PROFILE_Result();

    TESTOUT($"""

       clamp(v1,v1,v1)  Iterations: {CommaDelimit(I)}    Seconds: {Result[ 0]:N16}    Sum: {Sum[ 0]:N3}
       clamp(v1)        Iterations: {CommaDelimit(I)}    Seconds: {Result[ 1]:N16}    Sum: {Sum[ 1]:N3}
       clamp(v2,v1,v1)  Iterations: {CommaDelimit(I)}    Seconds: {Result[ 2]:N16}    Sum: {Sum[ 2]:N3}
       clamp(v2)        Iterations: {CommaDelimit(I)}    Seconds: {Result[ 3]:N16}    Sum: {Sum[ 3]:N3}
       clamp(v3,v1,v1)  Iterations: {CommaDelimit(I)}    Seconds: {Result[ 4]:N16}    Sum: {Sum[ 4]:N3}
       clamp(v3)        Iterations: {CommaDelimit(I)}    Seconds: {Result[ 5]:N16}    Sum: {Sum[ 5]:N3}
       clamp(v4,v1,v1)  Iterations: {CommaDelimit(I)}    Seconds: {Result[ 6]:N16}    Sum: {Sum[ 6]:N3}
       clamp(v4)        Iterations: {CommaDelimit(I)}    Seconds: {Result[ 7]:N16}    Sum: {Sum[ 7]:N3}

       cross(v3,v3)     Iterations: {CommaDelimit(I)}    Seconds: {Result[ 8]:N16}    Sum: {Sum[ 8]:N3}

       dot(v2,v2)       Iterations: {CommaDelimit(I)}    Seconds: {Result[ 9]:N16}    Sum: {Sum[ 9]:N3}
       dot(v2)          Iterations: {CommaDelimit(I)}    Seconds: {Result[10]:N16}    Sum: {Sum[10]:N3}
       dot(v3,v3)       Iterations: {CommaDelimit(I)}    Seconds: {Result[11]:N16}    Sum: {Sum[11]:N3}
       dot(v3)          Iterations: {CommaDelimit(I)}    Seconds: {Result[12]:N16}    Sum: {Sum[12]:N3}
       dot(v4,v4)       Iterations: {CommaDelimit(I)}    Seconds: {Result[13]:N16}    Sum: {Sum[13]:N3}
       dot(v4)          Iterations: {CommaDelimit(I)}    Seconds: {Result[14]:N16}    Sum: {Sum[14]:N3}

    """);
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    TESTOUT("\nTesting \"min(A,B,C,D)\"...");

    const int I = (1 << 24);

     float[] Sum    = new  float[8];
    double[] Result = new double[8];

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[0] +=   min(Random1 (), Random1u(), Random1u(), Random1u());    PROFILE_End(); Result[0]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[1] +=   min(Random1u(), Random1u(), Random1u(), Random1 ());    PROFILE_End(); Result[1]=PROFILE_Result();     //  ~120ms slower.

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[2] += _minA(Random1 (), Random1u(), Random1u(), Random1u());    PROFILE_End(); Result[2]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[3] += _minA(Random1u(), Random1u(), Random1u(), Random1 ());    PROFILE_End(); Result[3]=PROFILE_Result();     //  ~40ms faster???   on i7-3930k

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[4] += _minB(Random1 (), Random1u(), Random1u(), Random1u());    PROFILE_End(); Result[4]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[5] += _minB(Random1u(), Random1u(), Random1u(), Random1 ());    PROFILE_End(); Result[5]=PROFILE_Result();     //  ~40ms faster???

    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[6] += _minC(Random1 (), Random1u(), Random1u(), Random1u());    PROFILE_End(); Result[6]=PROFILE_Result();
    PROFILE_Start();    for(int i=0;i<I;++i)  Sum[7] += _minC(Random1u(), Random1u(), Random1u(), Random1 ());    PROFILE_End(); Result[7]=PROFILE_Result();     //  ~40ms faster???

    TESTOUT($"""

       min()     Iterations: {CommaDelimit(I)}    Seconds: {Result[0]:F9}    Sum: {Sum[0]:F2}
       min()     Iterations: {CommaDelimit(I)}    Seconds: {Result[1]:F9}    Sum: {Sum[1]:F2}

      _minA()    Iterations: {CommaDelimit(I)}    Seconds: {Result[2]:F9}    Sum: {Sum[2]:F2}
      _minA()    Iterations: {CommaDelimit(I)}    Seconds: {Result[3]:F9}    Sum: {Sum[3]:F2}

      _minB()    Iterations: {CommaDelimit(I)}    Seconds: {Result[4]:F9}    Sum: {Sum[4]:F2}
      _minB()    Iterations: {CommaDelimit(I)}    Seconds: {Result[5]:F9}    Sum: {Sum[5]:F2}

      _minC()    Iterations: {CommaDelimit(I)}    Seconds: {Result[6]:F9}    Sum: {Sum[6]:F2}
      _minC()    Iterations: {CommaDelimit(I)}    Seconds: {Result[7]:F9}    Sum: {Sum[7]:F2}

    """);
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
    for (float iF = 0f; iF <= 2.000001f; iF += 0.05f) {
        float A = Cylinder_SurfaceA__a(iF, 2f*iF);
        float B = Cylinder_SurfaceArea(iF, 2f*iF);

        TESTOUT($"""
          [{iF:0.00}]  {A:00.000000000} == {B:00.000000000}    {abs(B-A) < EPS5}
        """);
    }
#endif

#if false
{
    int i = 0;
    for (float iF = 0f; iF <= 1f; iF = 0.05f*(float)++i) {
        TESTOUT($"  [{i,2}]  {iF}");
    }
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
{
    vec2[] Filo2 = Phyllotaxis2(360, 0.5f);

    string STR = "";
    for (int i = 0; i < Filo2.Length; ++i) {
        STR += $"{Filo2[i]}, ";
    }
    TESTOUT("["+STR+"]");
}
#endif

#if false
{
    vec3[] Filo3 = Phyllotaxis3(80);

    string STR = "";
    for (int i = 0; i < Filo3.Length; ++i) {
        STR += $"[{i,2}] {Filo3[i]}\n";
    }
    TESTOUT(STR);
}
#endif

#if false
{
    for (int i = 0; i < 5; ++i) {
        TESTOUT($"""

            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
            {normalize(Random3())}
        """);
    }
}
#endif
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
//##############################################################################################################################################################
}}
