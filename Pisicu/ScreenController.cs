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

namespace Pisicu{

    public class ScreenController{
        
        public static Screen SCREEN = Screen.HOME; 

        public static List<Button> buttons = new List<Button>();
        public static List<TextBox> textboxes = new List<TextBox>();
        public static List<InputBox> inputboxes = new List<InputBox>();

        public static ScreenHome screen_home;
        public static ScreenLoad screen_load;
        public static ScreenGame screen_game;
        public static ScreenFinish screen_finish;
        public static ScreenLogin screen_login;
        public static ScreenRegister screen_register;
        public static ScreenHall screen_hall;
        public static ScreenActivity screen_activity;
        public static ScreenJoinActivity screen_join_activity;
        public static ScreenCreateActivity screen_create_activity;

        public static string[] question = {"Cuando nacio Albert Einstein","1920","1921","1910"};

        public void draw(SpriteBatch sb){

            if (SCREEN == Screen.HOME) {
                screen_home.draw(sb);
            }else if (SCREEN == Screen.GAME) {
                screen_game.draw(sb);
            }else if(SCREEN == Screen.LOAD) {
                screen_load.draw(sb);
            }else if(SCREEN == Screen.FINISH) {
                screen_finish.draw(sb);
            }else if(SCREEN == Screen.LOGIN) {
                screen_login.draw(sb);
            }else if(SCREEN == Screen.REGISTER) {
                screen_register.draw(sb);
            }else if(SCREEN == Screen.HALL) {
                screen_hall.draw(sb);
            }else if(SCREEN == Screen.ACTIVITY) {
                screen_activity.draw(sb);
            }else if(SCREEN == Screen.JOIN_ACTIVITY) {
                screen_join_activity.draw(sb);
            }else if(SCREEN == Screen.CREATE_ACTIVITY) {
                screen_create_activity.draw(sb);
            }

            foreach(Button b in buttons){
                b.draw(sb);
            }

            foreach(TextBox tbox in textboxes){
                tbox.draw(sb);
            }

            foreach(InputBox ibox in inputboxes) {
                ibox.draw(sb);
            }
        }

        public void update(ref Socket ws){
            
            TouchCollection touch = TouchPanel.GetState();

            if (touch.Count > 0){

                float tx = touch[0].Position.X;
                float ty = touch[0].Position.Y;

                Game1.output2 = "X: " + Math.Round(touch[0].Position.X / Game1.WIDTH,3) + " | Y: " + Math.Round(touch[0].Position.Y / Game1.HEIGHT,3);

                if (touch[0].State == TouchLocationState.Pressed){
                    
                    foreach(Button b in buttons){

                        if (tx > b.x && tx < b.x + b.w && ty > b.y && ty < b.y + b.h){
                            b.touch = true;
                        }else {
                            b.touch = false;
                        }
                    }

                    foreach(InputBox b in inputboxes){

                        if (tx > b.x && tx < b.x + b.w && ty > b.y && ty < b.y + b.h){
                            b.touch = true;
                        }else {
                            b.touch = false;
                        }
                    }

                }else if(touch[0].State == TouchLocationState.Released){
                    
                    foreach(Button b in buttons){
                        b.touch = false;
                    }  
                    
                    foreach(InputBox b in inputboxes){
                        b.touch = false;
                    }                 
                }
            }

            if(SCREEN == Screen.HOME) {
                screen_home.update();
            }else if (SCREEN == Screen.GAME) {
                screen_game.update(ref ws);
            }else if(SCREEN == Screen.LOAD) {
                screen_load.update(ref ws);
            }else if(SCREEN == Screen.FINISH) {
                screen_finish.update();
            }else if(SCREEN == Screen.LOGIN) {
                screen_login.update(ref ws);
            }else if(SCREEN == Screen.REGISTER) {
                screen_register.update(ref ws);
            }else if(SCREEN == Screen.HALL) {
                screen_hall.update(ref ws);
            }else if(SCREEN == Screen.ACTIVITY) {
                screen_activity.update(ref ws);
            }else if(SCREEN == Screen.JOIN_ACTIVITY) {
                screen_join_activity.update(ref ws);
            }else if(SCREEN == Screen.CREATE_ACTIVITY) {
                screen_create_activity.update(ref ws);
            }
        }

        public static void setQuestion(params string[] q) {

            question = new string[]{q[0], q[1], q[2], q[3], q[4]};
        }

        public static void add(Button b) {
            buttons.Add(b);
        }

        public static void add(TextBox tb) {
            textboxes.Add(tb);
        }

        public static void add(InputBox ib) {
            inputboxes.Add(ib);
        }

        public static void set(Screen SCREEN){

            buttons.Clear();
            textboxes.Clear();
            inputboxes.Clear();

            if(SCREEN == Screen.HOME) {
                screen_home = new ScreenHome();
            }else if(SCREEN == Screen.GAME) {
                screen_game = new ScreenGame(question[0], question[1], question[2], question[3], question[4]);
            }else if(SCREEN == Screen.LOAD) {
                screen_load = new ScreenLoad();
            }else if(SCREEN == Screen.FINISH) {
                screen_finish = new ScreenFinish();
            }else if(SCREEN == Screen.LOGIN) {
                screen_login = new ScreenLogin();
            }else if(SCREEN == Screen.REGISTER) {
                screen_register = new ScreenRegister();
            }else if(SCREEN == Screen.HALL) {
                screen_hall = new ScreenHall();
            }else if(SCREEN == Screen.ACTIVITY) {
                screen_activity = new ScreenActivity();
            }else if(SCREEN == Screen.JOIN_ACTIVITY) {
                screen_join_activity = new ScreenJoinActivity();
            }else if(SCREEN == Screen.CREATE_ACTIVITY) {
                screen_create_activity = new ScreenCreateActivity();
            }

            ScreenController.SCREEN = SCREEN;
        }
    }
}