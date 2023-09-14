using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public sealed class TurnNumberSequence : ITurnNumberSequence
    {
        #region Private Members
        private readonly object _padLock = new object();
        private int _turnNumber = 0;
        #endregion

        #region Constructor
        public TurnNumberSequence()
        {
        }
        #endregion

        /// <inheritdoc/>
        public int GetNextTurnNumber()
        {
            lock (_padLock)
            {
                return this._turnNumber++;
            }

        }
    }
}
