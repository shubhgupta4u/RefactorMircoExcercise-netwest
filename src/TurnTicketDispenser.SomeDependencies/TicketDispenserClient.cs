using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TicketDispenserClient
    {
        // A class with the only goal of simulating a dependency on TicketDispenser
        // that has impact on the refactoring.

        public TicketDispenserClient()
        {
            DependencyResolver.Instance.Resolve<ITicketDispenser>().GetTurnTicket();
            DependencyResolver.Instance.Resolve<ITicketDispenser>().GetTurnTicket();
            DependencyResolver.Instance.Resolve<ITicketDispenser>().GetTurnTicket();
        }
    }
}
