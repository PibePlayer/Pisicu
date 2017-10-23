using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace Pisicu{

    public class ScreenLogin{

        Button login;
        InputBox user;
        InputBox pass;

        public ScreenLogin() {

            login = new Button("LOGIN", 0, 0.7f, 0.7f, 0.1f).centerX().setRadius(30, true, true, true, true);

            user = new InputBox(0, 0.3f, 0.7f, 0.1f, "Username").centerX().setRadius(50, true, true, true, true);
            pass = new InputBox(0, 0.45f, 0.7f, 0.1f, "Password").centerX();

            ScreenController.buttons.Add(login);
            ScreenController.inputboxes.Add(user);
            ScreenController.inputboxes.Add(pass);
        }

        public void draw(SpriteBatch sb) {

        }

        public void update(ref Socket ws) {

            if(login.touch) {

                login.touch = false;

                ws.Emit("login", "asd", "123"); // JAJAJAJA

                /*if (user.str != "" && pass.str != ""){
                    ws.Emit("login",user.str,pass.str);
                }*/
            }
        }
    }
}