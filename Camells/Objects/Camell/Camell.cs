using Heirloom;
using Heirloom.Collections;

namespace Camells;

public abstract class Camell{
    private Rectangle PosicioR;
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
    public void position(Rectangle pista){
        PosicioR = ((pista.X+pista.Width,pista.Y+pista.Height),PosicioR.Size);
    }
}