using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

public class SpriteRenderer : IRenderer
{
    private Sprite sprite;
    private Transform2 transform;

    public SpriteRenderer(Sprite s, Transform2 t)
    {
        sprite = s;
        sprite.Origin = new Vector2(sprite.TextureRegion.Width, sprite.TextureRegion.Height) * 0.5f;

        transform = t;
    }

    public void Update(GameTime gt) {}

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(sprite, transform);
    } 
}