using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestClass()]
    public class TicketDispenserTests
    {
        #region Private Members
        private ITicketDispenser _ticketDispenser;
        private Mock<ITurnNumberSequence> _mockTurnNumberSequence;
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            this._mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            this._ticketDispenser = new TicketDispenser(this._mockTurnNumberSequence.Object);
        }


        [TestMethod("GetTurnTicketSequentialRequestTest")]
        [DataRow(1, 3, new int[] { 2, 3, 4 }, DisplayName = "Should generate incremental unique turn ticket number in sequential request")]
        public void GetTurnTicketTest(int currentTurnNumber, int nextTurnTicketRequestCount, int[] expectedTurnNumbers)
        {
            // Arrange
            var sequencer = this._mockTurnNumberSequence.SetupSequence(generator => generator.GetNextTurnNumber());
            for (int i = 0; i < nextTurnTicketRequestCount; i++)
            {
                sequencer.Returns(currentTurnNumber += 1);
            }

            var ticketDispenser = new TicketDispenser(this._mockTurnNumberSequence.Object);

            // Act
            ITurnTicket[] actualTurnNumbers = new ITurnTicket[nextTurnTicketRequestCount];
            for (int i = 0; i < nextTurnTicketRequestCount; i++)
            {
                actualTurnNumbers[i] = this._ticketDispenser.GetTurnTicket();
            }

            // Assert
            for (int i = 0; i < nextTurnTicketRequestCount; i++)
            {
                Assert.AreEqual<int>(actualTurnNumbers[i].TurnNumber, expectedTurnNumbers[i]);
            }
        }
        [TestMethod("GetTurnTicketParallelRequestTest")]
        [DataRow(1, 3, new int[] { 2, 3, 4 }, DisplayName = "Should generate incremental unique turn ticket number in parallel request")]
        public void GetTurnTicketParallelRequestTest(int currentTurnNumber, int nextTurnTicketRequestCount, int[] expectedTurnNumbers)
        {
            // Arrange
            var sequencer = this._mockTurnNumberSequence.SetupSequence(generator => generator.GetNextTurnNumber());
            for (int i = 0; i < nextTurnTicketRequestCount; i++)
            {
                sequencer.Returns(currentTurnNumber += 1);
            }

            var ticketDispenser = new TicketDispenser(this._mockTurnNumberSequence.Object);

            // Act
            ITurnTicket[] actualTurnNumbers = new ITurnTicket[nextTurnTicketRequestCount];
            Parallel.For(0, nextTurnTicketRequestCount, (idx) =>
               {
                   lock (this)
                   {
                       actualTurnNumbers[idx] = this._ticketDispenser.GetTurnTicket();
                   }

               }
            );

            // Assert
            Assert.IsTrue(actualTurnNumbers.GroupBy(x => x.TurnNumber).All(g => g.Count() == 1));
            Assert.AreEqual<int>(actualTurnNumbers.Count(), expectedTurnNumbers.Count());
            Assert.IsTrue(actualTurnNumbers.All(x => expectedTurnNumbers.ToList().IndexOf(x.TurnNumber) >= 0));
        }
    }
}