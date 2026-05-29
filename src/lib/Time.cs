using System;
using Microsoft.Xna.Framework;

public static class Time
{
    public static TimeSpan ElapsedTime;
    public static float Delta;

    public static void Update(GameTime gt)
    {
        ElapsedTime = gt.ElapsedGameTime;
        Delta = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}