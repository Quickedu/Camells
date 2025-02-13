using System.ComponentModel;
using System.Formats.Asn1;
using System.Net;
using Heirloom;
using Heirloom.Desktop;

namespace Camells;
public class Game{
    private readonly Window _window;
    private Rectangle rect;
    private int status = 0;
    private List <Camell> Jugadors;
    private List <Camell> Camel;
    public Game(Window finestra){
        _window = finestra;
    }
    public void Run (GraphicsContext gfx, float dt){
        rect = new Rectangle ((0,0),_window.Size);
        switch (status){
            case 0 :
            start();
            break;
            case 1:
            game();
            break;
            case 2:
            end();
            break;
            default:
            status = 1;
            break;
        }
    }
    public void Load(){
        
        
    }
    public void start (){
        if (Input.CheckKey(Key.Enter,ButtonState.Pressed)){
            var players = player();
            for (int i=0;i<players;i++){
                Jugadors.Add(Camel[i]);
            }
        }
    }
    public void game (){
        
    }
    public void end(){

    }
    public int player(){
        var numero = 0;
        Dictionary <Key,int> keymapping = new() {
            {Key.Num2,2},{Key.Num3,3},{Key.Num4,4},{Key.Num5,5},{Key.Num6,6}

        };
        foreach (var key in keymapping){
            if (Input.CheckKey(key.Key,ButtonState.Pressed)){
                numero = key.Value;
            }
        }
        return numero;
    }
}