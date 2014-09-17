using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    class Display
    {
        DisplayOrdersWorkflow displayOrdersWorkflow = new DisplayOrdersWorkflow();
        AddAnOrderWorkflow addAnOrderWorkflow = new AddAnOrderWorkflow();
        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();


        public void DisplayMenu()
        {
            string menuChoice;

            do
            {
                Console.Clear();
                Console.WriteLine("Flooring Program");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");

                Console.WriteLine("4. Remove an Order");

                Console.WriteLine("5. Quit");

                Console.Write("\nEnter Choice #: ");
                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        
                        displayOrdersWorkflow.Execute();
                        break;
                    case "2":
                        addAnOrderWorkflow.Execute();
                        break;
                    case "3":
                        editOrderWorkflow.Execute();
                        break;
                    case "4":
                        //removeOrderWorkflow.Execute();
                        break;
                }

            } while (menuChoice != "5");
        }
    }
}
