using Heirloom;

namespace Camells;

public class CamelTrampos : Camell{
    private Rectangle PosicioR;
    private readonly int Velocitat = 10;
    private int direccio = 1;
    private Random rnd = new();
    public CamelTrampos(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(0,600);
        if (go <= 3){
            go = rnd.Next(0,10);
            PosicioR.X += (Velocitat+go)*direccio;
            direccio *= -1;
        }
    }
}