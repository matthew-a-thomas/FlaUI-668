namespace ScrollTest;

using System;
using FlaUI.Core.Input;

class Program
{
    static async Task Main()
    {
        while (true)
        {
            Mouse.Scroll(-1);
            Console.WriteLine("Scroll");

            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}
