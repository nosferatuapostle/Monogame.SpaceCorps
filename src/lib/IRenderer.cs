using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// world renderer - transform
// ui renderer


public interface IRenderer
{
    void Update(GameTime gt);
    void Draw(SpriteBatch sb);
}