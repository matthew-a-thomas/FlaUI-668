namespace ScrollTest;

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.UI.Input.KeyboardAndMouse;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Scroll");
            Scroll(-1);

            Thread.Sleep(1000);
        }
    }

    static void Scroll(double lines)
    {
        var amount = (uint)(PInvoke.WHEEL_DELTA * lines);
        var mouseInput = new MOUSEINPUT{
            dx = 0,
            dy = 0,
            mouseData = amount,
            dwExtraInfo = 0,
            time = 0,
            dwFlags = MOUSE_EVENT_FLAGS.MOUSEEVENTF_WHEEL
        };

        var input = new INPUT{ type = INPUT_TYPE.INPUT_MOUSE, Anonymous = { mi = mouseInput }};
        Span<INPUT> inputs = stackalloc INPUT[1];
        inputs[0] = input;
        if (PInvoke.SendInput(inputs, Marshal.SizeOf<INPUT>()) == 0)
        {
            throw new Win32Exception();
        }
    }
}
