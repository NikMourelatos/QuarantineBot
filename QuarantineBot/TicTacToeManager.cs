using System;
using Discord.WebSocket;

namespace QuarantineBot
{
    public class TicTacToeManager
    {
        private string[,] board;
        private string turn;

        public TicTacToeManager()
        {
            board = new string[3, 3] { { "_", "_", "_" }, { "_", "_", "_" }, { "_", "_", "_" } };
            turn = "X";
        }

        public string handleInput(SocketMessage message)
        {
            string arg = this.getArg(message.Content);
            if (arg == "reset")
            {
                this.resetBoard();
                return "Board reset :)";
            }
            if (!Int32.TryParse(arg, out int number))
            {
                return "Please specify a number representing a position on the board";
            }
            if (number < 0)
            {
                return "Invalid number, must be 1-9";
            }
            if (number <= 3)
            {
                board[0, number - 1] = turn;
            }
            else if (number <= 6)
            {
                board[1, number - 4] = turn;
            }
            else if (number <= 9)
            {
                board[2, number - 7] = turn;
            }
            else
            {
                return "Invalid number, must be 1-9";
            }

            this.toggleTurn();

            string output = this.getBoardString();
            return this.formatOutput(output);
        }

        private void toggleTurn()
        {
            turn = turn == "X" ? "O" : "X";
        }

        private string getBoardString()
        {
            string output = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    output += board[i, j] + " ";
                }
                output += Environment.NewLine;
            }

            return output;
        }

        private string getArg(string input)
        {
            return input.Split(" ")[1];
        }

        private string formatOutput(string message)
        {
            return "```" + Environment.NewLine + message + Environment.NewLine + "```";
        }

        private void resetBoard()
        {
            board = new string[3, 3] { { "_", "_", "_" }, { "_", "_", "_" }, { "_", "_", "_" } };
            turn = "X";
        }
    }
}
