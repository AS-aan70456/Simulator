using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Threading;
using static Simulator.CoreClass;
using static Simulator.Bot;
using static Simulator.Filed;


namespace Simulator{


    class MainProgram{
        static void Main(string[] args){
            MyProgram app = new MyProgram();
            app.StartProgram();
            Console.WriteLine("Hello World!");
        }
    }

    class MyProgram {




        static Random r = new Random();
        RenderWindow window;

        public void StartProgram(){
            window = new RenderWindow(new VideoMode(800, 800), "SFML window");
            window.SetVisible(true);
            window.Closed += new EventHandler(OnClosed);

            Filed field = new Filed(114, 114 , "C:/Users/Pavlo/Desktop/IT_Projet/Simulator/Simulator/Tilemaps.png");

            field.fX = 0;
            field.fY = 0;


            field.CreateBoundaries('#');

            

            

            while (true) {


                Bot[] bot = new Bot[64];
                for (int i = 0; i < bot.Length; i++)
                {
                    bot[i] = new Bot((Rotation)r.Next(7), 100);
                    bool OFF = true;

                    while (OFF)
                    {
                        int x = r.Next(field.GetFieldX() - 10) + 3;
                        int y = r.Next(field.GetFieldY() - 10) + 3;
                        bot[i].SetPosition(new Position(x, y));
                        OFF = false;

                    }

                }




                field.CreateBoundaries('#');
                for (int i = 0; i < 300; i++) field.SetBlock(new Position(r.Next(field.GetFieldX() - 2) + 1, r.Next(field.GetFieldY() - 2) + 1), '-');

                while (bot.Length > 0) {

                    field.SetBlock(new Position(r.Next(field.GetFieldX() - 2) + 1, r.Next(field.GetFieldY() - 2) + 1), '-');
                    

                    for (int i = 0; i < bot.Length; i++) {


                        field.SetBlock(bot[i].GetPosition(), 'B');
                        field.SetBlock(new Position(0, 0), '#');
                        field.SetBlock(bot[i].BotStep(field.field), ' ');


                        




                        if (bot[i].Life > 1000) {bot[i].Life -= 500;Insert(ref bot, bot[i], 0);bot[i].BotRot = (Rotation)((int)bot[i].BotRot - 2); }

                        if (bot[i].Life < 1) { field.SetBlock(bot[i].GetPosition(), '-'); RemoveAd(ref bot, i); }


                    }
                    field.Show(window);
                    
                }
                Console.WriteLine(bot.Length);

            }

        }



        static void RemoveAd(ref Bot[] arrayBot, int index){
            

            Bot[] NewArrayBot = new Bot[arrayBot.Length - 1];


            for (int i = 0; i < index; i++)
                NewArrayBot[i] = arrayBot[i];
            

            for (int i = index + 1; i < arrayBot.Length; i++)
                NewArrayBot[i - 1] = arrayBot[i];
            

            arrayBot = NewArrayBot;

            
        }

        static void Insert(ref Bot[] arrayBot, Bot valueBot, int index){
            
            Bot[] NewArrayBot = new Bot[arrayBot.Length + 1];
            
            NewArrayBot[index] = new Bot((Rotation)r.Next(7), 500);
            NewArrayBot[index].SetPosition(valueBot.GetPosition());
            NewArrayBot[index].Comands = valueBot.Comands;
            if (r.Next(8) == 8) { NewArrayBot[index].Mutation(); }

            for (int i = 0; i < index; i++)
                NewArrayBot[i] = arrayBot[i];

            for (int i = index; i < arrayBot.Length; i++)
                NewArrayBot[i + 1] = arrayBot[i];

            arrayBot = NewArrayBot;
            
        }



        void OnClosed(object sender, EventArgs e) { window.Close(); }
    }
}
