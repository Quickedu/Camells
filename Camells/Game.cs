using System.ComponentModel;
using System.Formats.Asn1;
using System.Net;
using System.Security;
using Heirloom;
using Heirloom.Collections;
using Heirloom.Desktop;

namespace Camells;
public class Game{
    private readonly Window _window;
    private Rectangle rect;
    private int status = 0;
    private int numero;
    private Image camelskin;
    private BG bg;
    private List <Image> bgskin = new();
    private List <Camell> Jugadors = new();
    private List <Camell> Camel = new();
    private List <Carril> Carrils = new();
    private int alturacarrils;
    public Game(Window finestra){
        _window = finestra;
    }   public void Run (GraphicsContext gfx, float dt){
        rect = new Rectangle ((0,0),_window.Size);
        switch (status){
            case 0 :
            start(gfx);
            break;
            case 1:
            game(gfx);
            break;
            case 2:
            end(gfx);
            break;
            default:
            status = 1;
            break;
        }
    }
    public void Load(){
        bg = new BG();
        bgskin.Add(new Image("Objects/BG/Image/BgStart.png"));
        bgskin.Add(new Image("Objects/BG/Image/BgGame.png"));
        camelskin = new Image("Objects/Camell/Image/Camell.png");
        Camel.Insert(0,new CamelPlayer(Color.White,camelskin));
        Camel.Insert(1,new CamelFlipat(Color.Red,camelskin));
        Camel.Insert(2,new CamelImparell(Color.Blue,camelskin));
        Camel.Insert(3,new CamelParell(Color.Cyan,camelskin));
        Camel.Insert(4,new CamelSprint(Color.Green,camelskin));
    }
    public void start (GraphicsContext gfx){
        bg.Spawn(gfx,bgskin[0],rect);
        var players = player();
        gfx.DrawText("Quants jugadors vols?", (_window.Width/2,_window.Height/2-100),Font.Default,100,TextAlign.Center);
        gfx.DrawText($"{players}",(_window.Width/2,_window.Height/2+100),Font.Default,100,TextAlign.Center);
        if (Input.CheckKey(Key.Enter,ButtonState.Pressed)){
            for (int i=0; i<Jugadors.Count;i++){
                Carrils.Add(new Carril(((_window.Width,_window.Height),size:(_window.Width,100)),Camel[i])); //EDITAR, NO ESTA BÉ!!!!!
            }
            status = 1;
            Camel.Clear();
            return;
        }
    }
    public void game (GraphicsContext gfx){
        bg.Spawn(gfx,bgskin[1],rect);
        foreach(var carril in Carrils){
            carril.Spawn(gfx);
        }
    }
    public void end(GraphicsContext gfx){

    }
    public int player(){
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