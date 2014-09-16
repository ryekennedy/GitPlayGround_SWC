using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class Board
    {
        //bool playerXTurn;
        //bool playerOTurn;

        public string[] grid = new string[10];

        public void SetupGrid()
        {
            for (int i = 1; i <= 9; i++)
            {
                grid[i] = i.ToString();
            }

        }


        public BoardPlacementResult PlaceMark(int index, string in_markChar)
        {
            if (index<1  || index>=10)
            {
                return BoardPlacementResult.Invalid; //Invalid
            }

            if (grid[index] == "X" || grid[index] == "O")
            {
                return BoardPlacementResult.Overlap ; //Overlap
            }

           

            if (index>=1 && index<=9)
            {
                grid[index] = in_markChar;
                return BoardPlacementResult.OK;
            }

            return BoardPlacementResult.Invalid; //Invalid
            
        }

        public string RetrieveMarkForPosition(int index)
        {
          return  grid[index];
        }




 

    }//end of Board class
}
