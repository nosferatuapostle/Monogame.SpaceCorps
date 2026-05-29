using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite
{
    private TextureRegion region;
    private Vector2 scale;

    public TextureRegion Region
    {
        get => region;
        set
        {
            region = value;
            Recalculate();
        }
    }

    public Color Color;

    public float Rotation;

    public Vector2 Scale
    {
        get => scale;
        set
        {
            scale = value;
            Recalculate();
        }
    }

    public Vector2 Origin { get; private set; }

    public SpriteEffects Effects;

    public float LayerDepth;

    public float Width { get; private set; }

    public float Height { get; private set; }

    public Sprite(TextureRegion tr)
    {
        region = tr;
        Color = Color.White;
        Rotation = 0f;
        Effects = SpriteEffects.None;
        LayerDepth = 0f;
        scale = Vector2.One;
        Recalculate();
    }

    private void Recalculate()
    {
        if (region == null)
        {
            Width = 0;
            Height = 0;
            Origin = Vector2.Zero;
            return;
        }

        Width = region.Width * scale.X;
        Height = region.Height * scale.Y;
        Origin = new Vector2(Width, Height) * 0.5f;
    }

    public void Draw(Vector2 position)
    {
        Region.Draw(position, Color, Rotation, Origin, Scale, Effects, LayerDepth);
    }
}