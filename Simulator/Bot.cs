using System;
using static Simulator.CoreClass;


namespace Simulator
{

    class Bot
    {
        private Position BotPos;
        public Rotation BotRot;
        Random r = new Random();

        public int Life;

        private int ComandsCounter = 0;
        public byte[] Comands = new byte[64];



        Point[] EnvironmentBot = new Point[8];

        public Bot(Rotation _Rot, int _Life) { BotRot = _Rot; Life = _Life; FillingComands(); }

        public void SetPosition(Position _Pos) { BotPos = _Pos; }
        public Position GetPosition() { return BotPos; }
        private void FillingComands() { for (int i = 0; i < 64; i++) { Comands[i] = (byte)r.Next(32); } }
        public byte[] getCommand(){return Comands;}
        public void setCommand(byte[] _Commands){
            
            for (int i = 0; i < _Commands.Length; i ++){Comands[i] = _Commands[i];}


            
        
        
        }

        public void Mutation(){FillingComands();}

        public Position BotStep(char[,] _field)
        {




            if (ComandsCounter > 63)
            {
                ComandsCounter = 0;
            }

            int commands = Comands[ComandsCounter];
            int ComandEnvi = commands;
            int lr = 0;

            int x = (BotPos.x - 1);
            int y = (BotPos.y - 1);


            while (lr < 8)
            {
                EnvironmentBot[lr].FuledBot = _field[x, y];
                EnvironmentBot[lr].Environment = new Position(x, y);

                if (lr < 2)
                {
                    x++;
                }
                else if (lr < 4)
                {
                    y++;
                }
                else if (lr < 6)
                {
                    x--;
                }
                else if (lr < 8)
                {
                    y--;
                }
                lr++;
            }

            
            for (int i = 0; i < BotRot.GetHashCode(); i++)
            {
                char ch = EnvironmentBot[0].FuledBot;
                Position po = EnvironmentBot[0].Environment;

                for (int j = 1; j < 8; j++)
                {
                    EnvironmentBot[j - 1] = EnvironmentBot[j];

                }
                EnvironmentBot[7].FuledBot = ch;
                EnvironmentBot[7].Environment = po;
            }

            if (commands < 24)
            {

                for (ComandEnvi = commands; ComandEnvi > 7; ComandEnvi -= 8) { }
                
                if (EnvironmentBot[ComandEnvi].FuledBot == '-')
                {
                    ComandsCounter += 1;
                }
                else if (EnvironmentBot[ComandEnvi].FuledBot == '#')
                {
                    ComandsCounter += 2;
                }
                else if (EnvironmentBot[ComandEnvi].FuledBot == 'B')
                {
                    ComandsCounter += 3;
                }
                else if (EnvironmentBot[ComandEnvi].FuledBot == '+')
                {
                    ComandsCounter += 4;
                }
                else if (EnvironmentBot[ComandEnvi].FuledBot == ' ')
                {
                    ComandsCounter += 5;

                }
            }

            if (commands < 8)
            {
                Life--;
                return BotMove(ComandEnvi);

            }
            if (commands < 16 && commands > 7)
            {
                Life--;
                return BotFire(ComandEnvi);

                
            }
            if (commands < 24 && commands > 15)
            {


            }
            if (commands < 32 && commands > 23){

                BotRot = ((Rotation)BotRot.GetHashCode() + (commands - 24));

                if (BotRot.GetHashCode() > 7){BotRot -= 8;}

                ComandsCounter += 1;
            }
            if (commands > 31){
               

                ComandsCounter += (commands - 31);

            }

            Life--;
            return new Position(20, 20);
        }
        //BotPos.x = EnvironmentBot[commands].Environment.x; BotPos.y = EnvironmentBot[commands].Environment.y;
        private Position BotMove(int commands){
            Position buf = new Position(BotPos.x, BotPos.y);

            
            if (EnvironmentBot[commands].FuledBot != '#' && EnvironmentBot[commands].FuledBot != 'B'){

                if (EnvironmentBot[commands].FuledBot == '+'){
                    Life += 100;
                }
                BotPos.x = EnvironmentBot[commands].Environment.x;
                BotPos.y = EnvironmentBot[commands].Environment.y;
                return buf;
            }
            return new Position(0, 0);
        }
        private Position BotFire(int commands){

            
            if (EnvironmentBot[commands].FuledBot == '-') { Life += 100; return new Position(EnvironmentBot[commands].Environment.x , EnvironmentBot[commands].Environment.y); }
            return new Position(0, 0);
        }

    }

}
