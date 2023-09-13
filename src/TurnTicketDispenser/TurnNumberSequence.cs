using System;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public sealed class TurnNumberSequence : ITurnNumberSequence
    {
        #region Private Members
        private static readonly Lazy<TurnNumberSequence> lazy = new Lazy<TurnNumberSequence>(() => new TurnNumberSequence());
        private readonly object _padLock = new object();
        private int _turnNumber = 0;
        #endregion

        #region Constructor
        private TurnNumberSequence()
        {
        }
        #endregion

        #region Properties
        public static TurnNumberSequence Instance
        {
            get
            {
                return lazy.Value;
            }
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
