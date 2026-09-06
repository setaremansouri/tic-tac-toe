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
    Console.Clear();

    Console.WriteLine(gameTitle);

    DisplayBoard(board);


    Console.WriteLine("Choose a position from 1 to 9:");

    string input = Console.ReadLine();


    bool isNumber = int.TryParse(input, out int position);


    if (isNumber && position >= 1 && position <= 9)
    {
        int index = position - 1;


        if (board[index] != "X" && board[index] != "O")
        {
            // Player Move
            board[index] = "X";


            // Check Player Winner
            if (CheckWinner(board, "X"))
            {
                DisplayBoard(board);

                Console.WriteLine("You win!");

                break;
            }


            // Check Draw
            if (IsDraw(board))
            {
                DisplayBoard(board);

                Console.WriteLine("Draw!");

                break;
            }


            // Computer Move
            ComputerMove(board);


            // Check Computer Winner
            if (CheckWinner(board, "O"))
            {
                DisplayBoard(board);

                Console.WriteLine("Computer wins!");

                break;
            }


            // Check Draw after Computer Move
            if (IsDraw(board))
            {
                DisplayBoard(board);

                Console.WriteLine("Draw!");

                break;
            }
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





// ================= METHODS =================



void DisplayBoard(string[] board)
{
    Console.WriteLine();

    Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
    Console.WriteLine("---------");
    Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
    Console.WriteLine("---------");
    Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
}





bool CheckWinner(string[] board, string symbol)
{
    bool won =
        (board[0] == symbol && board[1] == symbol && board[2] == symbol) ||
        (board[3] == symbol && board[4] == symbol && board[5] == symbol) ||
        (board[6] == symbol && board[7] == symbol && board[8] == symbol) ||

        (board[0] == symbol && board[3] == symbol && board[6] == symbol) ||
        (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
        (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||

        (board[0] == symbol && board[4] == symbol && board[8] == symbol) ||
        (board[2] == symbol && board[4] == symbol && board[6] == symbol);


    return won;
}





bool IsDraw(string[] board)
{
    for (int i = 0; i < board.Length; i++)
    {
        if (board[i] != "X" && board[i] != "O")
        {
            return false;
        }
    }


    return true;
}





void ComputerMove(string[] board)
{
    List<int> emptyCells = new List<int>();


    for (int i = 0; i < board.Length; i++)
    {
        if (board[i] != "X" && board[i] != "O")
        {
            emptyCells.Add(i);
        }
    }


    Random random = new Random();


    int randomIndex = random.Next(emptyCells.Count);


    int computerIndex = emptyCells[randomIndex];


    board[computerIndex] = "O";
}