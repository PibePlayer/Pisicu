using Android.App;
using Android.Util;
using Android.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using System.Threading.Tasks;

using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;

namespace Pisicu{

    public class Game1 : Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int WIDTH;
        public static int HEIGHT;

        public static int COUNT = 0;

        public static SpriteFont font;
        public static Texture2D point;

        public static Texture2D corner_solid_ul;
        public static Texture2D corner_solid_ur;
        public static Texture2D corner_solid_dr;
        public static Texture2D corner_solid_dl;

        public static Texture2D corner_ul;
        public static Texture2D corner_ur;
        public static Texture2D corner_dr;
        public static Texture2D corner_dl;

        public static Texture2D stroke_ul;
        public static Texture2D stroke_ur;
        public static Texture2D stroke_dr;
        public static Texture2D stroke_dl;

        public static Texture2D icon_activity;
        
        public static string output = "-";
        public static string output2 = "--";

        ScreenController sc;

        Task<string> kB;

        Socket ws;

        public Game1() {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            WIDTH = Window.ClientBounds.Width;
            HEIGHT = Window.ClientBounds.Height;

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;

        }

        protected override void Initialize() {

            base.Initialize();

            sc = new ScreenController();
            ScreenController.set(Screen.LOAD);
            
        }

        protected override void LoadContent() {

            IO.Options op = new IO.Options(){AutoConnect = true};
            ws = IO.Socket("http://192.168.0.12:8081", op);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("font/SourceCodePro48SB");
            point = createTexture(1, 1);
            
            corner_solid_ul = Content.Load<Texture2D>("corner_solid_ul");
            corner_solid_ur = Content.Load<Texture2D>("corner_solid_ur");
            corner_solid_dr = Content.Load<Texture2D>("corner_solid_dr");
            corner_solid_dl = Content.Load<Texture2D>("corner_solid_dl");

            corner_ul = Content.Load<Texture2D>("corner_ul");
            corner_ur = Content.Load<Texture2D>("corner_ur");
            corner_dr = Content.Load<Texture2D>("corner_dr");
            corner_dl = Content.Load<Texture2D>("corner_dl");

            stroke_ul = Content.Load<Texture2D>("stroke_ul");
            stroke_ur = Content.Load<Texture2D>("stroke_ur");
            stroke_dl = Content.Load<Texture2D>("stroke_dl");
            stroke_dr = Content.Load<Texture2D>("stroke_dr");

            icon_activity = Content.Load<Texture2D>("icon_activity");

            /*****************I'M GOING TO BUILD A WALL, AND MEXICO WILL PAY FOR IT*******************/
            #region Connection


            ws.On(Socket.EVENT_CONNECT, () => {
                output = "Connected";
                ScreenController.set(Screen.HOME);
            });

            ws.On("success", (data) => {
                System.Console.WriteLine("Data:" + data);
                if ((bool)data){
                    output = "Registered!";
                    ScreenController.set(Screen.LOGIN);
                }else{
                    output = "Error en el Registro";
                }
            });

            ws.On("logged", (data) => {
                output = data.ToString();
                if ((bool)data){
                    ScreenController.set(Screen.HALL);
                }
            });

            ws.On("profile", (data) => {
                var Json = data as JToken;

                //User.id = Json.Value<int>("id");
                User.name = Json.Value<string>("name");
                output = "@" +  User.name;
            });

            /*ws.On("text", (data) => {

                var Json = data as JToken;
                output = "Loading Question";

                ScreenController.setQuestion(
                    Json.Value<string>("q"), Json.Value<string>("op1"),
                    Json.Value<string>("op2"), Json.Value<string>("op3")
                );

                ScreenController.set(Screen.GAME);
            });*/

            ws.On("question", (data) => {
                var Jarray = data as JArray;
                ScreenGame.questions = Jarray;

                output = Jarray.Count.ToString();
                var Json = Jarray.First;

                ScreenController.setQuestion(
                    Json.Value<string>("q"), Json.Value<string>("op0"),
                    Json.Value<string>("op1"), Json.Value<string>("op2"), 
                    Json.Value<string>("op3")
                );

                ScreenController.set(Screen.GAME);
            });

            ws.On("finish", (data) => {
                ScreenController.set(Screen.FINISH);
            });

            #endregion
            /***************************************** THE WALL **************************************/

        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime){

            base.Update(gameTime);

            //output = ScreenController.SCREEN.ToString();
            sc.update(ref ws);    
        }

        protected override void Draw(GameTime gameTime){

            GraphicsDevice.Clear(ColorBank.wetasphalt);

            spriteBatch.Begin();

                sc.draw(spriteBatch);
                spriteBatch.DrawString(font, output, new Vector2(50, 200), ColorBank.clouds);
                spriteBatch.DrawString(font, output2, new Vector2(50, Game1.HEIGHT - 100), ColorBank.clouds);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Texture2D createTexture(int width, int height) {

            Texture2D tex = new Texture2D(GraphicsDevice, width, height);

            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++) {
                data[i] = Color.White;
            }

            tex.SetData(data);

            return tex;

        }

    }
}
