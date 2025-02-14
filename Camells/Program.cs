using Heirloom;
using Heirloom.Desktop;

namespace Camells;

class Program
{
    private static Window _window;
    private static Game game;

    static void Main()
    {
        Application.Run(() =>
        {
            // Crea la finestra
            _window = new Window("Camells") { IsResizable = false };
            _window.Maximize();

            game = new Game (_window);
            game.Load();

            var loop = GameLoop.Create(_window.Graphics, OnUpdate, 60);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        game.Run(gfx,dt);
    }
}