string gameTitle = "Tic Tac Toe";

string[] board =
{
    "1", "2", "3",
    "4", "5", "6",
    "7", "8", "9"
};

bool gameRunning = true;

while (gameRunning)
{
    Console.WriteLine();

    Console.WriteLine(gameTitle);

    Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
    Console.WriteLine("---------");
    Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
    Console.WriteLine("---------");
    Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");

    Console.WriteLine("Choose a position from 1 to 9:");

    string input = Console.ReadLine();

    bool isNumber = int.TryParse(input, out int position);

    if (isNumber && position >= 1 && position <= 9)
    {
        int index = position - 1;

        if (board[index] != "X" && board[index] != "O")
        {
            board[index] = "X";


            // Check Player Winner

            bool playerWon =
                (board[0] == "X" && board[1] == "X" && board[2] == "X") ||
                (board[3] == "X" && board[4] == "X" && board[5] == "X") ||
                (board[6] == "X" && board[7] == "X" && board[8] == "X") ||

                (board[0] == "X" && board[3] == "X" && board[6] == "X") ||
                (board[1] == "X" && board[4] == "X" && board[7] == "X") ||
                (board[2] == "X" && board[5] == "X" && board[8] == "X") ||

                (board[0] == "X" && board[4] == "X" && board[8] == "X") ||
                (board[2] == "X" && board[4] == "X" && board[6] == "X");

            if (playerWon)
            {
                Console.WriteLine();

                Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
                Console.WriteLine("---------");
                Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
                Console.WriteLine("---------");
                Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");

                Console.WriteLine("You win!");

                break;
            }


            // Find Empty Cells

            List<int> emptyCells = new List<int>();

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != "X" && board[i] != "O")
                {
                    emptyCells.Add(i);
                }
            }


            // Check Draw

            if (emptyCells.Count == 0)
            {
                Console.WriteLine();

                Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
                Console.WriteLine("---------");
                Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
                Console.WriteLine("---------");
                Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");

                Console.WriteLine("Draw!");

                break;
            }


            // Computer Move

            Random random = new Random();

            int randomIndex = random.Next(emptyCells.Count);

            int computerIndex = emptyCells[randomIndex];

            board[computerIndex] = "O";
        }
        else
        {
            Console.WriteLine("This position is already occupied.");
        }
    }
    else
    {
        Console.WriteLine("Please enter a number from 1 to 9.");
    }
}