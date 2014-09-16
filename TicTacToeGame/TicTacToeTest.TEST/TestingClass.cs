using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToeTest.TEST
{
    [TestFixture]
    public class TestingClass
    {
        [Test]
        public void AssertMarkPlacement( )
        {
            Board board = new Board();
            var status = board.PlaceMark(3, "X");
            Assert.AreEqual(status, BoardPlacementResult.OK);


        }
        [Test]
        public void AssertMarkPlacementInvalid()
        {
            Board board = new Board();
            var status = board.PlaceMark(10, "X");
            Assert.AreEqual(status, BoardPlacementResult.Invalid);


        }





    }// end of class
}//end of namespace
