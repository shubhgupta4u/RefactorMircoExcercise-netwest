namespace TDDMicroExercises.TurnTicketDispenser.Interfaces
{
    public interface ITurnNumberSequence
    {
        /// <summary>
        /// Method return the unique ticket number
        /// </summary>
        /// <returns>Ticket Number</returns>
        int GetNextTurnNumber();
    }
}
