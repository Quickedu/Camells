using Heirloom;
using Heirloom.Collections;

namespace Camells;

public class CamelImparell : Camell{
    private Rectangle PosicioR;
    private readonly int Velocitat = 10;
    private Random rnd = new();
    public CamelImparell(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(0,600);
        if (go <= 6 && go%2 != 0){
            go = rnd.Next(0,5);
            PosicioR.X += Velocitat+go;
        }
    }
}