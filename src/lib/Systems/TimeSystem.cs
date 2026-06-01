using System;
using Microsoft.Xna.Framework;

public interface IGlobalSystem;

public class TimeSystem
{
    public TimeSpan ElapsedTime;
    public float Delta;

    public void Update(GameTime gt)
    {
        ElapsedTime = gt.ElapsedGameTime;
        Delta = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}