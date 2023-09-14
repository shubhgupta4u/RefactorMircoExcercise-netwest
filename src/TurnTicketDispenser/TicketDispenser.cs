using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    /// <inheritdoc/>
    public class TicketDispenser : ITicketDispenser
    {
        #region Private Members
        private readonly ITurnNumberSequence _turnNumberSequence;
        #endregion

        #region Constructor
        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            this._turnNumberSequence = turnNumberSequence;
        }
        #endregion

        #region Interfaces.ITicketDispenser Methods
        /// <inheritdoc/>
        public ITurnTicket GetTurnTicket()
        {
            int newTurnNumber = this._turnNumberSequence.GetNextTurnNumber();
            ITurnTicket newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
        #endregion
    }
}
