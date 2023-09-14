using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnTicketAndSequenceClient
    {
        // A class with the only goal of simulating a dependencies on 
        // TurnNumberSequence and TurnTicket that have impact on the refactoring.

        public TurnTicketAndSequenceClient()
        {
            var singletonTurnNumberSequence = DependencyResolver.Instance.Resolve<ITurnNumberSequence>();
            var turnTicket1 = new TurnTicket(singletonTurnNumberSequence.GetNextTurnNumber());
            var turnTicket2 = new TurnTicket(singletonTurnNumberSequence.GetNextTurnNumber());
            var turnTicket3 = new TurnTicket(singletonTurnNumberSequence.GetNextTurnNumber());
        }
    }
}
