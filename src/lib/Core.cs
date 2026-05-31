using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

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
        Window.AllowUserResizing = true;

        Content = base.Content;
        Content.RootDirectory = "res";
        IsMouseVisible = true;
    }

    private BoxingViewportAdapter viewportAdapter;

    protected override void Initialize()
    {
        base.Initialize();

        GraphicsDevice = base.GraphicsDevice;

        SpriteBatch = new SpriteBatch(GraphicsDevice);

        viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 1280, 720);
        G.Camera = new OrthographicCamera(viewportAdapter);
    }

    protected override void Update(GameTime gt)
    {
        Time.Update(gt);

        Input.Update();

        Renderer.Update(gt);

        const float speed = 200f;
        if (Input.Keyboard.IsKeyDown(Keys.A))
        {
            G.Camera.Position -= new Vector2(speed * Time.Delta, 0f);
        }

        if (Input.Keyboard.IsKeyDown(Keys.D))
        {
            G.Camera.Position += new Vector2(speed * Time.Delta, 0f);
        }

        if (Input.Keyboard.IsKeyDown(Keys.W))
        {
            G.Camera.Position -= new Vector2(0f, speed * Time.Delta);
        }

        if (Input.Keyboard.IsKeyDown(Keys.S))
        {
            G.Camera.Position += new Vector2(0f, speed * Time.Delta);
        }

        base.Update(gt);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        Renderer.Render();

        base.Draw(gameTime);
    }
}