using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;

namespace Pisicu{

    public class ScreenGame{

        public static JArray questions;
        private int _question;
        public int question{
            get{return _question;}
            set{
                Game1.output = value + " : " + questions.Count;
                _question = value;
                if(value == questions.Count){
                    ScreenController.set(Screen.FINISH);
                }else{
                setQuestion(
                    questions[value].Value<string>("q"), questions[value].Value<string>("op0"),
                    questions[value].Value<string>("op1"), questions[value].Value<string>("op2"),
                    questions[value].Value<string>("op3"));
                }
            }}
        
        public TextBox tbox;
        public List<Button> buttons = new List<Button>();

        public ScreenGame(string q, string op1, string op2, string op3, string op4){
            
            tbox = new TextBox(q, 0, 0.2f, 0.8f, 0.1f).setColor(ColorBank.alizarin).centerX().centerText(TextBox.center.xy).setRadius(20,true);

            string[] n = {op1, op2, op3, op4};

            for(int i = 0; i < n.Length; i++){
                buttons.Add(new Button(n[i], 0,0.4f + i * 0.1f ,0.7f, 0.08f).centerX().setRadius(40,true));
                ScreenController.add(buttons[i]);
            }

            ScreenController.add(tbox);
            ScreenController.add(ScreenHall.profile);
        }

        private void setQuestion(string q, string op1, string op2, string op3, string op4){
            tbox.str = q;
            tbox.centerText();

            string[] n = {op1, op2, op3, op4};

            for (int i = 0; i < 4; i++)
            {
                buttons[i].str = n[i];
                buttons[i].centerText();
            }
        }

        public void draw(SpriteBatch sb){

        }

        public void update(ref Socket ws) {

            if (buttons[0].touch) {
                ++question;
                buttons[0].touch = false;
            }
        }
    }
}