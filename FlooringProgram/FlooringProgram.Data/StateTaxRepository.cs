using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class StateTaxRepository : ITaxRepository
    {
        private const string FileName = "StateTaxesList.txt";
        private const string HeaderRow = "StateAbbreviation, StateName, TaxRate";

        public  List<StateTax> LoadAll()
        {
            var stateTaxList = File.ReadAllLines(FileName);
            var stateInfo = new List<StateTax>();

            // start at position 1, because we don't want the header row
            for (int i = 1; i < stateTaxList.Length; i++)
            {
                // split the csv, this returns a string array of each column value
                var columns = stateTaxList[i].Split(',');

                // need a contact object to put the data in
                var newState = new StateTax();

                // read the data into the objects one column at a time, enums are ints, but we need to cast (int)
                newState.StateAbbreviation = columns[(int) StateTaxColumn.StateAbbreviation];
                newState.StateName = columns[(int) StateTaxColumn.StateName];
                newState.TaxRate = decimal.Parse(columns[(int) StateTaxColumn.Taxrate]);

                stateInfo.Add(newState);
            }

            return stateInfo;
        }

       
    }
}
