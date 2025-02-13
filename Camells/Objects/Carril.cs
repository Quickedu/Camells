using Heirloom;

namespace Camells;
public class Carril{
    private Rectangle rectsize;
    public List <Camell> camells;

    public Carril(Rectangle midarect,Camell camel)
    {
        rectsize=midarect;
        camells.Add(camel);
    }

    public void Spawn(GraphicsContext gfx){
        gfx.DrawRect(rectsize);
        foreach(var cam in camells){
            cam.Move(gfx);
            cam.Spawn(gfx);
        }
    }

}