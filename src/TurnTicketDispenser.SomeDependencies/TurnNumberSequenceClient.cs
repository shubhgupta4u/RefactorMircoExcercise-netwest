using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnNumberSequenceClient
    {
        // A class with the only goal of simulating a dependency on TurnNumberSequence
        // that has impact on the refactoring.

        public TurnNumberSequenceClient()
        {
            int nextUniqueTicketNumber;
            nextUniqueTicketNumber = DependencyResolver.Instance.Resolve<ITurnNumberSequence>().GetNextTurnNumber();
            nextUniqueTicketNumber = DependencyResolver.Instance.Resolve<ITurnNumberSequence>().GetNextTurnNumber();
            nextUniqueTicketNumber = DependencyResolver.Instance.Resolve<ITurnNumberSequence>().GetNextTurnNumber();
        }
    }
}
