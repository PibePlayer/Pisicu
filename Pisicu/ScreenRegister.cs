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

using Microsoft.Xna.Framework.Graphics;

using Quobject.SocketIoClientDotNet.Client;

namespace Pisicu
{
    public class ScreenRegister
    {
        Button register;

        InputBox user;
        InputBox pass;

        TextBox user_tbox;
        TextBox pass_tbox;

        public ScreenRegister() {

            register = new Button("Registrar", 0, 0.7f, 0.7f, 0.1f).setColor(ColorBank.alizarin).centerX().setRadius(50, true, true, true, true);

            user_tbox = new TextBox("Usuario", 0, 0.265f, 0.7f, 0.035f).setColor(ColorBank.alizarin).centerX().centerText(TextBox.center.y).setRadius(30,true,true,false,false);
            pass_tbox = new TextBox("Clave", 0, 0.42f, 0.7f, 0.035f).setColor(ColorBank.alizarin).centerX().centerText(TextBox.center.y).setRadius(30,true,true,false,false);
 
            user = new InputBox(0, 0.295f, 0.7f, 0.07f, "Usuario").centerX().setRadius(30, false, false, true, true).setStroke(6,ColorBank.alizarin);
            pass = new InputBox(0, 0.45f, 0.7f, 0.07f,  "Contraseña").centerX().setRadius(30, false, false, true, true).setStroke(6,ColorBank.alizarin);

            ScreenController.add(register);
            ScreenController.add(user_tbox);
            ScreenController.add(pass_tbox);
            ScreenController.add(user);
            ScreenController.add(pass);
        }

        public void draw(SpriteBatch sb) {

        }

        public void update(ref Socket ws) {

            if(register.touch) {

                register.touch = false;

                //ws.Emit("register", "asd", "123"); // JAJAJAJA

                if (user.str != "" && pass.str != ""){
                    ws.Emit("register", user.str, pass.str);
                }
            }
        }
    }
}