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
        G.Input.Update();
        G.Time.Update(gt);
        G.Renderer.Update(gt);
        
        G.Entt.Update();

        var kb = G.Input.Keyboard;
        var time = G.Time;
        var cam = G.Camera;

        const float speed = 200f;
        if (kb.IsKeyDown(Keys.A))
        {
            cam.Position -= new Vector2(speed * time.Delta, 0f);
        }

        if (kb.IsKeyDown(Keys.D))
        {
            cam.Position += new Vector2(speed * time.Delta, 0f);
        }

        if (kb.IsKeyDown(Keys.W))
        {
            cam.Position -= new Vector2(0f, speed * time.Delta);
        }

        if (kb.IsKeyDown(Keys.S))
        {
            cam.Position += new Vector2(0f, speed * time.Delta);
        }

        base.Update(gt);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        G.Renderer.Render();

        base.Draw(gameTime);
    }
}