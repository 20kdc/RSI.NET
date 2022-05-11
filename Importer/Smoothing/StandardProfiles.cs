using Importer.Directions;

namespace RSI.Smoothing;

public static class SmoothingProfiles
{
    // -- Space Station 14 --

    public static readonly QuadSmoothingProfile SS14 = new SS14SmoothingProfile(
        new int[]
        {
        // QuadSubtileIndex order matches RT direction order
        // So this is pretty much the identity matrix
        //  BR  TL  TR  BL
             0,  1,  2,  3, // 0
             4,  5,  6,  7, // 1
             8,  9, 10, 11, // 2
            12, 13, 14, 15, // 3
            16, 17, 18, 19, // 4
            20, 21, 22, 23, // 5
            24, 25, 26, 27, // 6
            28, 29, 30, 31  // 7
        },
        new string[] {"0", "1", "2", "3", "4", "5", "6", "7"},
        DirectionType.Cardinal
    ).Compile("ss14");

    // -- Space Station 13 --

    public static readonly QuadSmoothingProfile Citadel = new SS14SmoothingProfile(
        new int[]
        {
        //  BR  TL  TR  BL
             3,  0,  1,  2, // 0
            11,  8,  5,  6, // 1
             3,  0,  1,  2, // 2
            11,  8,  5,  6, // 3
             7,  4,  9, 10, // 4
            15, 12, 13, 14, // 5
             7,  4,  9, 10, // 6
            19, 16, 17, 18  // 7
        },
        new string[]
        {
            "1-i", "2-i", "3-i", "4-i",
            "1-n", "2-n", "3-s", "4-s",
            "1-w", "2-e", "3-w", "4-e",
            "1-nw", "2-ne", "3-sw", "4-se",
            "1-f", "2-f", "3-f", "4-f",
        },
        DirectionType.None
    ).Compile("citadel");

    // TODO: This is a BAD PROFILE! I AM A BAD PERSON! WHY HAVE I USHERED FORTH THE MISSING SUBTILE APOCALYPSE?!?!?!
    // Seriously, though, /tg/ needs a dedicated profile to really work right, it uses a decompressed AT Field
    public static readonly QuadSmoothingProfile TG = new SS14SmoothingProfile(
        new int[]
        {
        //  BR  TL  TR  BL
             0,  0,  0,  0, // 0
            12, 12,  3,  3, // 1
             0,  0,  0,  0, // 2
            12, 12,  3,  3, // 3
             3,  3, 12, 12, // 4
            15, 15, 15, 15, // 5
             3,  3, 12, 12, // 6
            46, 46, 46, 46  // 7
        },
        new string[]
        {
            "0", "1", "2", "3", "4", "5", "6", "7",
            "8", "9", "10", "11", "12", "13", "14", "15",
            "21", "23", "29", "31", "38", "39", "46", "47",
            "55", "63", "74", "75", "78", "79", "95", "110",
            "111", "127", "137", "139", "141", "143", "157", "159",
            "175", "191", "203", "207", "223", "239", "255"
        },
        DirectionType.None
    ).Compile("tg");

    // -- RM (Split) --

    public static readonly QuadSmoothingProfile VXASplit = new SS14SmoothingProfile(
        new int[]
        {
        //  BR  TL  TR  BL
             5,  2,  3,  4, // 0 X (ST)
             4,  3,  5,  2, // 1
             5,  2,  3,  4, // 2 X (ST)
             4,  3,  5,  2, // 3
             3,  4,  2,  5, // 4
             1,  1,  1,  1, // 5 X (IC)
             3,  4,  2,  5, // 6
             2,  5,  4,  3  // 7 X (F)
        },
        new string[] {"0", "1", "2", "3", "4", "5"},
        DirectionType.None
    ).Compile("vxa-split");

    public static readonly QuadSmoothingProfile VXAPSplit = new SS14SmoothingProfile(
        new int[]
        {
        //  BR  TL  TR  BL
             5,  2,  3,  4, // 0 X (ST)
             4,  3,  5,  2, // 1
             0,  0,  0,  0, // 2 - diagdup of 0
             6,  6,  7,  7, // 3 - diagdup of 1
             3,  4,  2,  5, // 4
             1,  1,  1,  1, // 5 X (IC)
             7,  7,  6,  6, // 6 - diagdup of 4
             2,  5,  4,  3  // 7 X (F)
        },
        new string[] {"0", "1", "2", "3", "4", "5", "6", "7"},
        DirectionType.None
    ).Compile("vxap-split");

    // -- RM (Regular) --

    // -- List --

    public static readonly QuadSmoothingProfile[] AllProfiles = new QuadSmoothingProfile[] {
        SS14,
        Citadel,
        TG,
        VXASplit,
        VXAPSplit
    };
}

