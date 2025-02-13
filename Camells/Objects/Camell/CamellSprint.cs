using Heirloom;

namespace Camells;

public class CamelSprint : Camell{
    private Rectangle PosicioR;
    private readonly int Velocitat = 10;
    private int direccio = 1;
    private Random rnd = new();
    public CamelSprint(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        var go = rnd.Next(0,600);
        if (go <= 7){
            go = rnd.Next(0,10);
            if (go>=7)go*=2;
            PosicioR.X += (Velocitat+go)*direccio;
            direccio *= -1;
        }
    }
}