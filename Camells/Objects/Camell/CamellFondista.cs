using Heirloom;

namespace Camells;

public class CamelFondista : Camell{
    private readonly int Velocitat = 10;
    private Random rnd = new();
    public CamelFondista(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(1,2);
        PosR.X += Velocitat+go;
    }
}