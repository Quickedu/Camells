using Heirloom;

namespace Camells;

public class CamelSprint : Camell{
    private readonly int Velocitat = 10;
    private int direccio = 1;
    private Random rnd = new();
    public CamelSprint(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(0,50);
        if (go <= 10){
            go = rnd.Next(0,10);
            if (go>=7)go*=2;
            PosR.X += (Velocitat+go)*direccio;
            direccio *= -1;
        }
    }
}