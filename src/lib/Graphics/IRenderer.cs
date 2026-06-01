using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

// world renderer - transform
// ui renderer


public interface IRenderer
{
    void Update(GameTime gt);
    void Draw(SpriteBatch sb);
}

public abstract class WorldRenderer<T> : IRenderer where T : Sprite
{
    protected T sprite;
    protected Transform2 transform;

    public WorldRenderer(T s, Transform2 t)
    {
        sprite = s;
        transform = t;
        
        sprite.Origin =  new Vector2(sprite.TextureRegion.Width, sprite.TextureRegion.Height) * 0.5f;
    }

    public virtual void Update(GameTime gt) {}
    public virtual void Draw(SpriteBatch sb)
    {
        sb.Draw(sprite, transform);
    }
}