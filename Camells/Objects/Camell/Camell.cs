using Heirloom;
using Heirloom.Collections;

namespace Camells;

public abstract class Camell{

    protected Rectangle PosR;
    public Rectangle PosicioR {get=> PosR; set => PosR=value;}
    private Color colorcamell;
    private Image Skin;
    public Camell(Color color, Image imatge)
    {
        Skin = imatge;
        colorcamell = color;
    }
    public void Spawn (GraphicsContext gfx){
        gfx.Color = colorcamell;
        gfx.DrawImage(Skin,PosicioR);
        gfx.Color = Color.White;
    }
    public abstract void Move(GraphicsContext gfx);
}