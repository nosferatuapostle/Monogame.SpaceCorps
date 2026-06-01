using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

public class SpriteRenderer : WorldRenderer<Sprite>
{
    public SpriteRenderer(Sprite s, Transform2 t) : base(s, t) {}
}