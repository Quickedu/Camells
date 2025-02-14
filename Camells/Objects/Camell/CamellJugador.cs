using System.ComponentModel.Design;
using Heirloom;
using Heirloom.Collections;

namespace Camells;

public class CamelPlayer : Camell{
    private readonly int Velocitat = 10;
    private Random rnd = new();
    public CamelPlayer(Color color, Image imatge) : base (color,imatge)
    {
    }
    public override void Move(GraphicsContext gfx){
        if (Input.CheckKey(Key.Space,ButtonState.Pressed)){
            var go = rnd.Next(7,13);
            PosR.X += Velocitat+go;
        }
    }
}