using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnTicket : ITurnTicket
    {
        #region Private Members
        private readonly int _turnNumber;
        #endregion

        #region Constructor
        public TurnTicket(int turnNumber)
        {
            _turnNumber = turnNumber;
        }
        #endregion

        #region Properties
        /// <inheritdoc/>
        public int TurnNumber
        {
            get { return _turnNumber; }
        }
        #endregion
    }
}