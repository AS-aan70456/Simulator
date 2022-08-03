using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.CoreClass;

namespace Simulator
{
    class Filed
    { 
        int Size = 7;

        public int fX = 0;
        public int fY = 0;

        private int fieldX;
        private int fieldY;
        public char[,] field;

        private Texture txr;
        private Sprite spr;



        public Filed(int _X, int _Y, string t)
        {

            txr = new Texture(t);
            spr = new Sprite(txr);

            fieldX = _X;
            fieldY = _Y;
            field = new char[fieldX, fieldY];

            spr.Scale = new Vector2f(
                Size / spr.GetGlobalBounds().Height,
                Size / spr.GetGlobalBounds().Height
            );
        }

        public int GetFieldX() { return fieldX; }
        public int GetFieldY() { return fieldY; }


        public void CreateBoundaries(char ch)
        {
            for (int y = 0; y < fieldY; y++)
            {
                for (int x = 0; x < fieldX; x++)
                {
                    if (y == 0 || y == fieldY - 1 || x == 0 || x == fieldX - 1) { field[x, y] = ch; }
                    else if (true) {  field[x, y] = ' ';  }
                }

            }
            field[3, 3] = ch;
        }

        public void SetBlock(Position _Pos, char ch) { field[_Pos.x, _Pos.y] = ch; }
        private void DrawBlock(RenderWindow window, int PosX, int PosY, int NumTail)
        {
            spr.TextureRect = new IntRect(NumTail * 32, 0, 32, 32);
            spr.Position = new Vector2f((PosX * Size) + fX, (PosY * Size) + fY);
            window.Draw(spr);
        }


        public void Show(RenderWindow window)
        {



            window.DispatchEvents();
            window.Clear();

            for (int y = 0; y < fieldY; y++)
            {
                for (int x = 0; x < fieldX; x++)
                {

                    if (field[x, y] == 'H')
                    {
                        DrawBlock(window, x, y, 0);
                    }
                    if (field[x, y] == '#')
                    {
                        DrawBlock(window, x, y, 1);
                    }
                    if (field[x, y] == ' ')
                    {
                        DrawBlock(window, x, y, 2);
                    }
                    if (field[x, y] == '+')
                    {
                        DrawBlock(window, x, y, 3);
                    }
                    if (field[x, y] == '-')
                    {
                        DrawBlock(window, x, y, 4);
                    }
                    if (field[x, y] == 'B')
                    {
                        DrawBlock(window, x, y, 5);
                    }

                    if (field[x, y] == 'B')
                    {
                        DrawBlock(window, x, y, 5);
                    }
                }
            }

            window.Display();
        }

    }
}
