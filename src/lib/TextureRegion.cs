using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextureRegion
{
    public Texture2D Texture;

    public Rectangle SourceRectangle;

    public int Width => SourceRectangle.Width;

    public int Height => SourceRectangle.Height;

    public TextureRegion(Texture2D texture, int x, int y, int width, int height)
    {
        Texture = texture;
        SourceRectangle = new Rectangle(x, y, width, height);
    }

    public void Draw(Vector2 position, Color color)
    {
        Draw(position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);
    }

    public void Draw(Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        Core.SpriteBatch.Draw(Texture, position, SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
    }
}