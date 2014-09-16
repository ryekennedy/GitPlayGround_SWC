using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class TriangleMaker
    {
        Triangle _triangle = new Triangle();

        public void MakeTriangle()
        {
            int numberOfRows = 0;
            Console.WriteLine("How many rows of pascal triangle do want displayed? ");
            int.TryParse(Console.ReadLine(), out numberOfRows);

            CreateRows(numberOfRows);

            PopulateRows();

            DisplayRows();
        }

        private void PopulateRows()
        {
            Row previousrow = new Row();
            foreach (var thisrow in _triangle.rows)
            {
                for (int i = 0; i < thisrow.RowArray.Length; i++)
                {
                    if (thisrow.RowArray.Length == 1)
                    {
                        thisrow.RowArray[0] = 1;
                    }
                    else
                    {
                         if (i == 0 || i == thisrow.RowArray.Length - 1)
                        {
                            thisrow.RowArray[i] = 1;
                        }
                        else
                         {
                             thisrow.RowArray[i] = previousrow.RowArray[i-1] + previousrow.RowArray[i];
                         }
                    }
                   

                }
                previousrow = thisrow;
            }


            //for (int i = 0; i < UPPER; i++)
            //{
                
            //}


        }


        private void CreateRows(int numberOfRows)
        {
           
            for (int i = 1; i <= numberOfRows; i++)
            {
                Row thisRow = new Row();
                thisRow.CreateRowArray(i);
                _triangle.rows.Add(thisRow);
            }
        }

        private void DisplayRows()
        {
            foreach (var row in _triangle.rows)
            {
                for (int i = 0; i < row.RowArray.Length; i++)
                {
                    Console.Write("-{0}-", row.RowArray[i]);
                }
                Console.WriteLine();

            }
        }


    }
}
