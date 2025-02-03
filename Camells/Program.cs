using Heirloom;
using Heirloom.Desktop;

namespace Camells;

class Program
{
    private const int Amplada = 1024;
    private const int Altura = 768;
    private static Window _finestra = null!;

    static void Main()
    {
        Application.Run(() =>
        {
            // Crea la finestra
            _finestra = new Window("Camells", (Amplada, Altura)) { IsResizable = false };
            _finestra.MoveToCenter();

            // TODO: Inicialitza el programa

            var loop = GameLoop.Create(_finestra.Graphics, OnUpdate, 120);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        // TODO: Bucle del programa
    }
}