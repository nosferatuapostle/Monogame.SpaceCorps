using MonoGame.Extended.Input;

public class InputSystem
{
    public MouseStateExtended Mouse => MouseExtended.GetState();
    public KeyboardStateExtended Keyboard => KeyboardExtended.GetState();

    public void Update()
    {
        MouseExtended.Update();
        KeyboardExtended.Update();
    }
}