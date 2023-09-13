namespace TDDMicroExercises.TurnTicketDispenser.Interfaces
{
    public interface ITicketDispenser
    {
        /// <summary>
        /// Return next unique turn ticket
        /// </summary>
        /// <returns></returns>
        ITurnTicket GetTurnTicket();
    }
}
