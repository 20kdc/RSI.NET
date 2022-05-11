using System;
using SixLabors.ImageSharp;
using Importer.Directions;

namespace RSI.Smoothing;

/// <summary>
/// An SS14 smoothing profile is a "compressed" QuadSmoothingProfile, which only considers the states used by SS14 icon smoothing.
/// </summary>
public sealed class SS14SmoothingProfile
{
    /// <summary>
    /// The mapping table for every possible situation.
    /// The first index is the neighbourhood (SS14IndexFlags), and the second index is the subtile (QuadSubtileIndex).
    /// </summary>
    public readonly QuadSmoothingProfileSource[,] Sources = new QuadSmoothingProfileSource[8, 4];

    public SS14SmoothingProfile()
    {
    }

    /// <summary>
    /// The QuadSmoothingProfileSource for a given subtile.
    /// </summary>
    public QuadSmoothingProfileSource this[SS14IndexFlags idx, QuadSubtileIndex sub]
    {
        get
        {
            return Sources[(int) idx, (int) sub];
        }
        set
        {
            Sources[(int) idx, (int) sub] = value;
        }
    }

    /// <summary>
    /// Convert this SS14SmoothingProfile into a QuadSmoothingProfile.
    /// </summary>
    public QuadSmoothingProfile ConvertToQuadProfile()
    {
        QuadSmoothingProfile res = new();
        for (int subTileIdx = 0; subTileIdx < 4; subTileIdx++)
        {
            var subTile = (QuadSubtileIndex) subTileIdx;
            var relevantDirFlags = SS14IndexFlags.All.ToDirectionFlags(subTile);
            for (int neighbourIdx = 0; neighbourIdx < 8; neighbourIdx++)
            {
                var neighbourFlags = (SS14IndexFlags) neighbourIdx;
                var neighbourDirFlags = neighbourFlags.ToDirectionFlags(subTile);
                for (int dirFlagsIdx = 0; dirFlagsIdx < 256; dirFlagsIdx++)
                {
                    // See if this matches
                    var dirFlags = (DirectionFlags) dirFlagsIdx;
                    if ((dirFlags & relevantDirFlags) != neighbourDirFlags)
                        continue;
                    // It matches, so we're using this
                    res[dirFlags, subTile] = this[neighbourFlags, subTile];
                }
            }
        }
        return res;
    }
}
