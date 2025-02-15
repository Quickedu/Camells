using Heirloom;

namespace Camells;
public class Carril{
    private Rectangle rectsize;
    public List <Camell> camells = new();
    public bool final {get;set;}

    public Carril(Rectangle midarect)
    {
        rectsize=midarect;
    }

    public void Spawn(GraphicsContext gfx){
        gfx.DrawRectOutline(rectsize);
        foreach(var cam in camells){
            cam.Move(gfx);
            cam.Spawn(gfx);
            if (cam.PosicioR.Right >= rectsize.Right){
                final=true;
            }
        }
    }
    public void posiciocamel (Camell camel,int alturacarril){
        camells.Add(camel);
        foreach (var camell in camells){
            camell.PosicioR = ((10,alturacarril-100),size:(70,100));
        }
    }
    public Camell GetCamell(){
        var mesgran = 0.0;
        Camell camell = camells[0];
        foreach (var cam in camells){
            if (cam.PosicioR.Right>mesgran) {
                camell = cam; 
                mesgran = cam.PosicioR.Right;
            }
        }
        return camell;
    }
}