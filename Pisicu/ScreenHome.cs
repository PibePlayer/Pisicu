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

namespace Pisicu {

    public class ScreenHome {

        Button login;
        Button register;

        public ScreenHome() {

            login = new Button("Ingresar", 0, 0.35f, 0.7f, 0.1f).centerX().setColor(ColorBank.alizarin).setRadius(50, true);
            register = new Button("Registrarse", 0, 0.65f, 0.7f, 0.1f).centerX().setColor(ColorBank.alizarin).setRadius(50, true);

            ScreenController.buttons.Add(login);
            ScreenController.buttons.Add(register);
        }

        public void draw(SpriteBatch sb) {

        }

        public void update() {

            if(login.touch) {
                ScreenController.set(Screen.LOGIN);
            }

            if(register.touch) {
                ScreenController.set(Screen.REGISTER);
            }
        }
    }
}