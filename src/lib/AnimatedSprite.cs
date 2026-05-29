using System;

public class AnimatedSprite : Sprite
{
    private int currentFrame;
    private TimeSpan elapsed;
    private Animation animation;

    public Animation Animation
    {
        get => animation;
        set
        {
            animation = value;
            Region = animation.Frames[0];
        }
    }

    public AnimatedSprite(Animation anim) : base(anim.Frames[0])
    {
        Animation = anim;
    }

    public void Update()
    {
        elapsed += Time.ElapsedTime;

        if (elapsed >= animation.Delay)
        {
            elapsed -= animation.Delay;
            currentFrame++;

            if (currentFrame >= animation.Frames.Count)
            {
                currentFrame = 0;
            }

            Region = animation.Frames[currentFrame];
        }
    }
}