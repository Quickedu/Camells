using Heirloom;

namespace Camells;

public class CamelTrampos : Camell{
    private readonly int Velocitat = 10;
    private int direccio = 1;
    private Random rnd = new();
    public CamelTrampos(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(0,50);
        if (go <= 10){
            go = rnd.Next(0,10);
            PosR.X += (Velocitat+go)*direccio;
            direccio *= -1;
        }
    }
}