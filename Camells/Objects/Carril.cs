using Heirloom;

namespace Camells;
public class Carril{
    private Rectangle rectsize;
    public List <Camell> camells = new();

    public Carril(Rectangle midarect)
    {
        rectsize=midarect;
    }

    public void Spawn(GraphicsContext gfx){
        gfx.DrawRectOutline(rectsize);
        foreach(var cam in camells){
            cam.Move(gfx);
            cam.Spawn(gfx);
        }
    }
    public void posiciocamel (Camell camel,int alturacarril){
        camells.Add(camel);
        foreach (var camell in camells){
            camell.PosicioR = ((10,alturacarril-100),size:(70,100));
        }
    }
}