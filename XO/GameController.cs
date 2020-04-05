using System;
using System.Collections.Generic;
using System.Text;

namespace XO
{
    class GameController
    {
        char[,] winningPos = new char[8, 3]
        {
            { '0', '1', '2' },
            { '0', '4', '8' },
            { '0', '3', '6' },
            { '1', '4', '7' },
            { '2', '4', '6' },
            { '2', '5', '8' },
            { '3', '4', '5' },
            { '6', '7', '8' }
        };

        enum Status
        {
            x,
            o,
            clear
        }

        Status[] field = new Status[9];

        bool isWinning = false;

        bool isDraw = false;

        bool Xs = true;

        string message;
        string p1Way;
        string p2Way;
        private string currentPlayer;
        string CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                currentPlayer = value;
            }
        }

        private int pos;
        int Pos
        {
            get { return pos; }
            set
            {
                if ((value > 8) || (value < 0))
                    throw new ArgumentOutOfRangeException("You must input value between 0 and 8!");
                else
                    pos = value;
            }
        }

        public void StartGame()
        {
            for (int i = 0; i < field.Length; i++)
                field[i] = Status.clear;

            while ((isWinning == false) && (isDraw == false))
            {
                OutField();
                try
                {
                    Pos = int.Parse(Console.ReadLine());
                    SetPoint(Pos);
                    isWinning = WinningCheck();
                    isDraw = DrawCheck();
                    Xs = !Xs;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    break;
                }
                Console.WriteLine();
            }

            Console.WriteLine(message);
        }

        private bool DrawCheck()
        {
            if (isWinning == false)
            {
                for (int i = 0; i < field.Length; i++)
                {
                    if (field[i] == Status.clear)
                    {                     
                        return false;
                    }
                }
            }
            Console.WriteLine("Its draw!\n");
            OutField();
            return true;
        }

        void SetPoint(int position)
        {
            if (Xs == true)
            {
                field[position] = Status.x;
                p1Way += Pos.ToString();
            }
            else
            {
                field[position] = Status.o;
                p2Way += Pos.ToString();
            }
        }

        bool WinningCheck()
        {
            if (Xs == true)
                CurrentPlayer = p1Way;
            else
                CurrentPlayer = p2Way;

            for (int i = 0; i < 8; i++)
            {
                if ((CurrentPlayer.Contains(winningPos[i, 0])) && (CurrentPlayer.Contains(winningPos[i, 1])) && (CurrentPlayer.Contains(winningPos[i, 2])))
                {
                    if (Xs == true)
                    {
                        message = "X won!";
                        OutField();
                    }
                    else
                    {
                        message = "O won!";
                        OutField();
                    }
                    return true;
                }
            }
            return false;
        }

        void OutField()
        {
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == Status.clear)
                    Console.Write(i);
                else Console.Write(field[i].ToString());

                if ((i + 1) % 3 != 0)
                {
                    Console.Write('|');
                }
                else if (i < 6)
                {
                    Console.WriteLine("\n- - -");
                }
                else
                    Console.WriteLine('\n');
            }
        }
    }
}
