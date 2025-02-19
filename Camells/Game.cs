using Heirloom;
using Heirloom.Desktop;
namespace Camells;
public class Game{
    private readonly Window _window;
    private Rectangle rect;
    private Random random= new();
    private int numero;
    Camell guanyador;
    private int rnd = 0;
    private int comencacarril = 300;
    private int ampladacarril;
    private Image camelskin;
    private BG bg;
    private Type winner;
    private List <Image> bgskin = new();
    private List <Camell> Camel = new();
    private List <Carril> Carrils = new();
    private List <Camell> Camellstotal = new();
    private int status = 0; // 0 start - 1 Game - 2 End
    public Game(Window finestra){
        _window = finestra;
    }   
    public void Run (GraphicsContext gfx, float dt){
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
            case 3:
            calculguanyador();
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
        Camel.Insert(5,new CamelFondista(Color.Pink,camelskin));
        Camel.Insert(6,new CamelTrampos(Color.Magenta,camelskin));
    }
    public void start (GraphicsContext gfx){
        bg.Spawn(gfx,bgskin[0],rect);
        var players = player();
        gfx.Color=Color.Black;
        gfx.DrawText("Quants jugadors vols?", (_window.Width/2,_window.Height/2-100),Font.Default,100,TextAlign.Center);
        gfx.DrawText($"{players}",(_window.Width/2,_window.Height/2+100),Font.Default,100,TextAlign.Center);
        gfx.Color=Color.White;
        if (Input.CheckKey(Key.Enter,ButtonState.Pressed)&& players!=0){
            ampladacarril = (_window.Height-comencacarril)/players;
            foreach (var llista1 in Camel){
                Camellstotal.Add(llista1);
            }
            for (int i=0; i<players;i++){
                Carrils.Add(new Carril(((0,comencacarril),size:(_window.Width,ampladacarril))));
                Carrils[i].posiciocamel(Camel[rnd],comencacarril+ampladacarril);
                Camel.RemoveAt(rnd);
                comencacarril+=ampladacarril;
                if (Camel.Count-1 >=0){
                    rnd = random.Next(0,Camel.Count-1);
                    continue;
                    }
                    rnd=0;
            }
            status = 1;
            return;
        }
    }
    public void game (GraphicsContext gfx){
        bg.Spawn(gfx,bgskin[1],rect);
        foreach(var carril in Carrils){
            carril.Spawn(gfx);
            if (carril.final){
                status = 3;
            }
        }
    }
    public void calculguanyador(){
        var mesgran = 0.0; 
        foreach (var cam in Carrils){
            var chosed = cam.GetCamell();
            if (chosed.PosicioR.Right>mesgran){
                mesgran=chosed.PosicioR.Right;
                guanyador = chosed;
            }
        }
        winner = guanyador.GetType();
        status = 2;
    }
    public void end(GraphicsContext gfx){
        bg.Spawn(gfx,bgskin[0],rect);
        gfx.Color = Color.Black;
        gfx.DrawText($"{winner.Name} ha guanyat!!!",(rect.Width/2,rect.Height/2-100),Font.Default,100,TextAlign.Center);
        gfx.DrawText($"Prem Enter per tornar a jugar",(rect.Width/2,rect.Height/2+100),Font.Default,100,TextAlign.Center);
        gfx.Color = Color.White;
        if (Input.CheckKey(Key.Enter,ButtonState.Pressed)){
            status = 0;
            Carrils.Clear();
            Camellstotal.Clear();
            Camel.Clear();
            rnd = 0;
            comencacarril=300;
            Camel.Insert(0,new CamelPlayer(Color.White,camelskin));
            Camel.Insert(1,new CamelFlipat(Color.Red,camelskin));
            Camel.Insert(2,new CamelImparell(Color.Blue,camelskin));
            Camel.Insert(3,new CamelParell(Color.Cyan,camelskin));
            Camel.Insert(4,new CamelSprint(Color.Green,camelskin));
            Camel.Insert(5,new CamelFondista(Color.Pink,camelskin));
            Camel.Insert(6,new CamelTrampos(Color.Magenta,camelskin));
            }
    }
    public int player(){
        Dictionary <Key,int> keymapping = new() {
            {Key.Num2,2},{Key.Num3,3},{Key.Num4,4},{Key.Num5,5},{Key.Num6,6},{Key.Num7,7}
        };
        foreach (var key in keymapping){
            if (Input.CheckKey(key.Key,ButtonState.Pressed)){
                numero = key.Value;
            }
        }
        return numero;
    }
}