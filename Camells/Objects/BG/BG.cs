using Heirloom;
using Heirloom.Desktop;

namespace Camells;
public class BG{
    public BG(){
        
    }
    public void Spawn(GraphicsContext gfx,Image img, Rectangle rect){
        gfx.DrawImage(img,rect);
    }
}