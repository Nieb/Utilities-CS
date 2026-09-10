using System.Collections.Generic;

namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This is a bit VibeCoded.
    //  Ew, it uses Dictionary & List.  I s'poze, it is with good reason...  :(
    //
    //  SubDiv   Vertices   Triangles   Indices
    //       0         12          20        60
    //       1         42          80       240
    //       2        162         320       960
    //       3        642       1,280     3,840
    //       4      2,562       5,120    15,360
    //       5     10,242      20,480    61,440
    //       6     40,962      81,920   245,760
    //
    public static (vec3[], uint[]) Icosahedron(float Radius=1f, int SubDivisions=0) {
        SubDivisions = clamp(SubDivisions, 0, 6);

        const float t = PHI;
        List<vec3> V = new List<vec3> {
            (-1, t, 0), ( 1, t, 0), (-1,-t, 0), ( 1,-t, 0),
            ( 0,-1, t), ( 0, 1, t), ( 0,-1,-t), ( 0, 1,-t),
            ( t, 0,-1), ( t, 0, 1), (-t, 0,-1), (-t, 0, 1)
        };
        List<uint> I = new List<uint> {
            0,11, 5,   0, 5, 1,    0, 1, 7,    0, 7,10,   0,10,11,
            1, 5, 9,   5,11, 4,   11,10, 2,   10, 7, 6,   7, 1, 8,
            3, 9, 4,   3, 4, 2,    3, 2, 6,    3, 6, 8,   3, 8, 9,
            4, 9, 5,   2, 4,11,    6, 2,10,    8, 6, 7,   9, 8, 1
        };

        //  Cache to avoid duplicating vertices when splitting edges:
        Dictionary<ulong,uint> MidPointCache = new Dictionary<ulong,uint>();

        //  Get|Create a midpoint vertex between two existing vertices:
        uint GetMidPoint(uint p1, uint p2) {
            ulong Key = (u64(min(p1,p2)) << 32) | u64(max(p1,p2));

            if (MidPointCache.TryGetValue(Key, out uint Index))
                return Index;

            V.Add( avg(V[(int)p1],V[(int)p2]) );

            uint NewIndex = (uint)(V.Count - 1);
            MidPointCache.Add(Key, NewIndex);

            return NewIndex;
        }

        //  Subdivide faces recursively:
        for (int iS = 0; iS < SubDivisions; ++iS) {
            List<uint> NewIndices = new List<uint>();
            for (int i = 0; i < I.Count; i+=3) {
                uint A = I[i];
                uint B = I[i+1];
                uint C = I[i+2];

                uint AB = GetMidPoint(A, B);
                uint BC = GetMidPoint(B, C);
                uint CA = GetMidPoint(C, A);

                NewIndices.AddRange([ A, AB, CA]);
                NewIndices.AddRange([ B, BC, AB]);
                NewIndices.AddRange([ C, CA, BC]);
                NewIndices.AddRange([AB, BC, CA]);
            }
            I = NewIndices;
        }

        vec3[] V_ToArray = new vec3[V.Count];
        for (int i = 0; i < V.Count; ++i) {
            V_ToArray[i] = normalize(V[i]) * Radius;
        }

        return (V_ToArray, I.ToArray());
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
