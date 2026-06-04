using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

public class Core : Microsoft.Xna.Framework.Game
{
    internal static Core instance;

    public static Core Instance => instance;

    public static GraphicsDeviceManager Graphics;

    public static new GraphicsDevice GraphicsDevice;

    public static SpriteBatch SpriteBatch;

    public static new ContentManager Content;

    public Core(string title, int width, int height, bool isFullScreen)
    {
        instance = this;

        Graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = width,
            PreferredBackBufferHeight = height,
            IsFullScreen = isFullScreen
        };

        Graphics.ApplyChanges();

        Window.Title = title;
        Window.AllowUserResizing = true;

        Content = base.Content;
        Content.RootDirectory = "res";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        GraphicsDevice = base.GraphicsDevice;
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        base.Initialize();
    }

    protected override void Update(GameTime gt)
    {
        G.Input.Update();
        G.Time.Update(gt);
        G.Renderer.Update(gt);
        G.Entt.Update();

        base.Update(gt);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        G.Renderer.Render();

        base.Draw(gameTime);
    }
}