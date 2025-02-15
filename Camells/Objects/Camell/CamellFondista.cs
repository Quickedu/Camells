using Heirloom;

namespace Camells;

public class CamelFondista : Camell{
    private readonly int Velocitat = 10;
    private int canIgo = 1;
    private Random rnd = new();
    public CamelFondista(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        canIgo *= -1;
        if (canIgo == -1)return;
        var go = rnd.Next(0,1);
        PosR.X += Velocitat+go;
    }
}