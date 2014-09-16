using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe.BLL
{
    class GameManger
    {

        public string userInput;
        public string Player1Name;
        public string Player2Name;
        public string markChar;
        public string XplayerName;
        public string OPlayerName;
        public string currentPlayerName;

        private Board _board;


        bool Xplayerturn = true;

        public int validatedInput = 0;
        GameDecision gameResult;

        public void PlayGame()
        {
            _board = new Board();
            _board.SetupGrid();
           

            GetUserNames();
            ChooseFirstPlayer();
            PlayerTurnKeeper();
            DrawBoard();
            GetUserInput();
            EndofGame();

        }

        private void EndofGame()
        {
            string playagain;
            if (gameResult == GameDecision.Win)
            {
                Console.WriteLine("{0}!  You are a Winner. {1} win", currentPlayerName, markChar);
                Console.ReadLine();
            }
            if (gameResult == GameDecision.Tie)
            {
                Console.WriteLine("The Game is a Tie");
                Console.ReadLine();
            }
            Console.WriteLine("\n Press P to play again");
            playagain = Console.ReadLine();
            if (playagain == "P" || playagain == "p")
            {
                PlayGame();
            }
        }

        private void PlayerTurnKeeper()
        {
            if (Xplayerturn)
            {
                currentPlayerName = XplayerName;
                markChar = "X";
            }
            else
            {
                currentPlayerName = OPlayerName;
                markChar = "O";
               
            }
        }

        //public void SetupBoard()
        //{

        //}

 
        private void GetUserInput()
        {
            do
            {
                
                Console.WriteLine("Player {0}, {1}'s, choose your tile position (1-9):", currentPlayerName, markChar);
                if (int.TryParse(Console.ReadLine(), out validatedInput)) //update to check if 1-9  && validatedInput >=1 && validatedInput<=9
                {
                    var result = _board.PlaceMark(validatedInput, markChar);

                    if (result == BoardPlacementResult.Invalid)
                    {
                        //Console.WriteLine("{0}! that was an invalid number, try another (1-9):", currentPlayerName);
                        Console.WriteLine("{0} that was an invalid number, press a key to continue", currentPlayerName);
                        Console.ReadLine();
                        continue;
                    }

                    if (result == BoardPlacementResult.Overlap)
                    {
                        Console.WriteLine("{0}! that tile has been already chosen, try a different one:", currentPlayerName);
                        Console.WriteLine("{0} press a key to continue", currentPlayerName);
                        Console.ReadLine();
                        continue;
                        
                    }
                   if (result == BoardPlacementResult.OK)
                    {
                         Xplayerturn = !Xplayerturn;
                    }
                  
                    
                    
                }
                else
                {
                    Console.WriteLine("That was not a valid input, try inputting a number (1-9)");
                    continue;
                }

               // DrawBoard();

                gameResult = GameDecisionMaker.EvaluateBoard(_board, markChar);
                if(gameResult == GameDecision.PlayOn )
                {
                    PlayerTurnKeeper();
                }
                
                DrawBoard();


            } while (gameResult == GameDecision.PlayOn);  
            Console.ReadLine();
        }

        private void ChooseFirstPlayer()
        {
            if (FlipCoin() == 1)
            {
                XplayerName = Player1Name;
                OPlayerName = Player2Name;
            }
            else
            {
                XplayerName = Player2Name;
                OPlayerName = Player1Name;
            }
        }
        
        
        public void GetUserNames()
        {
            do
            {
                Console.WriteLine("Player 1 please input your name: ");
                Player1Name = (Console.ReadLine());               
            } while (Player1Name == "");

            do
            {
                Console.WriteLine("Player 2 please input your name: ");
                Player2Name = (Console.ReadLine());                
            } while (Player2Name == "");

                        
        }

        public int FlipCoin()
        {
            Random rng = new Random();
            return rng.Next(0,2); 
        }      
        
        
        
        
        
        
        private void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("      |      |      ");
            Console.WriteLine("   {0}  |   {1}  |  {2}  ", _board.RetrieveMarkForPosition(1), _board.RetrieveMarkForPosition(2), _board.RetrieveMarkForPosition(3));
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |      ");
            Console.WriteLine("   {0}  |   {1}  |  {2}  ", _board.RetrieveMarkForPosition(4), _board.RetrieveMarkForPosition(5), _board.RetrieveMarkForPosition(6));
            Console.WriteLine("______|______|______");
            Console.WriteLine("      |      |      ");
            Console.WriteLine("   {0}  |   {1}  |  {2}  ", _board.RetrieveMarkForPosition(7), _board.RetrieveMarkForPosition(8), _board.RetrieveMarkForPosition(9));
            Console.WriteLine("      |      |      ");
            
        }

    }
}
