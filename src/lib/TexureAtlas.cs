using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

public class TextureAtlas
{
    private Dictionary<string, TextureRegion> regions;
    private Dictionary<string, Animation> animations;

    public Texture2D Texture;

    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
        regions = [];
        animations = [];
    }

    public void AddRegion(string name, int x, int y, int width, int height)
    {
        var region = new TextureRegion(Texture, x, y, width, height);
        regions[name] = region;
    }

    public TextureRegion GetRegion(string name)
    {
        return regions[name];
    }

    public bool RemoveRegion(string name)
    {
        return regions.Remove(name);
    }

    public void Clear()
    {
        regions.Clear();
    }

    public Sprite CreateSprite(string name)
    {
        var tr = GetRegion(name);
        return new Sprite(tr);
    }

    public void AddAnimation(string name, Animation anim)
    {
        animations[name] = anim;
    }

    public Animation GetAnimation(string name)
    {
        return animations[name];
    }

    public AnimatedSprite CreateAnimatedSprite(string name, Animation anim)
    {
        AddAnimation(name, anim);
        return new AnimatedSprite(anim);
    }

    public bool RemoveAnimation(string name)
    {
        return animations.Remove(name);
    }
}