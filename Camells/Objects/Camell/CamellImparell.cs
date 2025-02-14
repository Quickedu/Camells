using Heirloom;
using Heirloom.Collections;

namespace Camells;

public class CamelImparell : Camell{
    private readonly int Velocitat = 10;
    private Random rnd = new();
    public CamelImparell(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(0,50);
        if (go <= 20 && go%2 != 0){
            go = rnd.Next(0,5);
            PosR.X += Velocitat+go;
        }
    }
}