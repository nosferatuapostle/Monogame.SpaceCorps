using System;
using System.Collections.Generic;

public class Animation
{
    public List<TextureRegion> Frames;

    public TimeSpan Delay;

    public Animation(List<TextureRegion> frames, TimeSpan delay)
    {
        Frames = frames;
        Delay = delay;
    }

    public Animation(TimeSpan delay)
    {
        Frames = [];
        Delay = delay;
    }
}