using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Core : Game
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
        Content = base.Content;
        Content.RootDirectory = "res";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        GraphicsDevice = base.GraphicsDevice;

        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gt)
    {
        Time.Update(gt);

        base.Update(gt);
    }
}