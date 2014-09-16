using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class GameDecisionMaker
    {

        public static GameDecision EvaluateBoard(Board board, string markChar)
        {

        //Win
            if (HorizontalWin(board, markChar) == GameDecision.Win || VerticalWin(board, markChar) == GameDecision.Win ||
                DiagonalWin(board, markChar) == GameDecision.Win)
            {
                return GameDecision.Win;
            }
            if (TieCase(board, markChar) == GameDecision.Tie)
            {
                return GameDecision.Tie;
            }

            return GameDecision.PlayOn;
 
        }



        private static GameDecision HorizontalWin(Board board, string markChar)
        {
            if (board.RetrieveMarkForPosition(1) == markChar && board.RetrieveMarkForPosition(2) == markChar && board.RetrieveMarkForPosition(3) == markChar ||
                board.RetrieveMarkForPosition(4) == markChar && board.RetrieveMarkForPosition(5) == markChar && board.RetrieveMarkForPosition(6) == markChar ||
                board.RetrieveMarkForPosition(7) == markChar && board.RetrieveMarkForPosition(8) == markChar && board.RetrieveMarkForPosition(9) == markChar
                )
                {
                   return  GameDecision.Win;
                }
            return GameDecision.PlayOn;
        }

        private static GameDecision VerticalWin(Board board, string markChar)
        {
            if (board.RetrieveMarkForPosition(1) == markChar && board.RetrieveMarkForPosition(4) == markChar && board.RetrieveMarkForPosition(7) == markChar ||
                board.RetrieveMarkForPosition(2) == markChar && board.RetrieveMarkForPosition(5) == markChar && board.RetrieveMarkForPosition(8) == markChar ||
                board.RetrieveMarkForPosition(3) == markChar && board.RetrieveMarkForPosition(6) == markChar && board.RetrieveMarkForPosition(9) == markChar
                )
                {
                    return GameDecision.Win;

                }

            return GameDecision.PlayOn;
        }

        private static GameDecision DiagonalWin(Board board, string markChar)
        {
            if (board.RetrieveMarkForPosition(1) == markChar && board.RetrieveMarkForPosition(5) == markChar && board.RetrieveMarkForPosition(9) == markChar ||
                board.RetrieveMarkForPosition(3) == markChar && board.RetrieveMarkForPosition(5) == markChar && board.RetrieveMarkForPosition(7) == markChar 
                )
            {
                return GameDecision.Win;
            }
            return GameDecision.PlayOn;
        }

        private static GameDecision TieCase(Board board, string markChar)
        {
            for (int i = 1; i < board.grid.Length; i++)
            {
                if (board.grid[i] == i.ToString())
                {
                    return GameDecision.PlayOn;
                }
            }
            
            return GameDecision.Tie;
        }


    }          

}
