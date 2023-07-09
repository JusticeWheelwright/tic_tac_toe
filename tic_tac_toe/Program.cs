// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static string[] board = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    static string player = "x";
    static int move;
    static bool end = false;
    static void Main(string[] args)
    {
        while (end==false)
        {
            Console.WriteLine("\nit is {0} turn", player);
            draw();
            if (player == "x")
            {
                player = player_move();
            }
            else
            {
                player = computer_move();
            }
            end = check_end(board);
        }
        Console.WriteLine("\nPlayer {0} loses", player);
        draw();
    }
    static void draw()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("------------");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("------------");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
    }
    static string player_move()
    {
        Console.WriteLine("\nWhat spot would you like to take?");
        move = Int32.Parse(Console.ReadLine());
        while (board[move-1] != move.ToString())
        {
            Console.WriteLine("\nThat spot is not open. What spot would you like to take?");
            move = Int32.Parse(Console.ReadLine());
        }
        board[move-1] = player;
        return "o";
    }

    static string computer_move()
    {
        bool cont = true;
        for (int a=0; a<=8;  a++)
        {
            if (board[a] == (a + 1).ToString())
            {
                string[] board_check = (string[]) board.Clone();
                board_check[a] = "x";
                bool win = check_end(board_check);
                if (win)
                {
                    move = a;
                    cont = false;
                    break;
                }
                board_check[a] = "o";
                win = check_end(board_check);
                if (win)
                {
                    move = a;
                    cont=false;
                    break;
                }
            }
        }
        if (cont)
        {
            Random rnd = new Random();
            int sample = rnd.Next(0,8);
            while (board[sample]!= (sample + 1).ToString())
            {
                rnd = new Random();
                sample = rnd.Next(0, 8);
            }
            move = sample;
        }
        board[move] = player;
        Console.WriteLine("The computer took spot {0}", (move+1));
        return "x";
    }
    static bool check_end(string[] board)
    {
        if (board[0] == board[1] && board[0] == board[2])
        {
            return true;
        }
        if (board[3] == board[4] && board[3] == board[5])
        {
            return true;
        }
        if (board[6] == board[7] && board[6] == board[8])
        {
            return true;
        }
        if (board[0] == board[3] && board[0] == board[6])
        {
            return true;
        }
        if (board[1] == board[4] && board[1] == board[7])
        {
            return true;
        }
        if (board[2] == board[5] && board[2] == board[8])
        {
            return true;
        }
        if (board[0] == board[4] && board[0] == board[8])
        {
            return true;
        }
        if (board[6] == board[4] && board[6] == board[2])
        {
            return true;
        }
        for (int i=0; i<=8; i++)
        {
            if (board[i] == (i + 1).ToString())
            {
                return false;
            }
        }
        return false;
    }

}

