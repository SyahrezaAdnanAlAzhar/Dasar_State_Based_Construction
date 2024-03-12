public enum DoorState { Terkunci, Terbuka };
public enum Trigger { BukaPintu, KunciPintu};

class DoorTransition
{
    public DoorState prevState;
    public DoorState nextState;
    public DoorState currentState;
    public Trigger trigger;

    public DoorTransition(DoorState prevState, DoorState nextState, Trigger trigger)
    {
        this.prevState = prevState;
        this.nextState = nextState;
        this.trigger = trigger;
    }

    DoorTransition[] transitions =
    {
        new DoorTransition(DoorState.Terkunci, DoorState.Terbuka, Trigger.BukaPintu),
        new DoorTransition(DoorState.Terkunci, DoorState.Terkunci, Trigger.KunciPintu),
        new DoorTransition(DoorState.Terbuka, DoorState.Terkunci, Trigger.KunciPintu),
        new DoorTransition(DoorState.Terbuka, DoorState.Terbuka, Trigger.BukaPintu)
    };

    public DoorState getNextState(DoorState prevState, Trigger trigger)
    {
        DoorState nextState = prevState;

        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
            {
                nextState = transitions[i].nextState;
            }
        }
        if (nextState == DoorState.Terkunci)
        {
            Console.WriteLine("Pintu terkunci");
        }else if (nextState == DoorState.Terbuka)
        {
            Console.WriteLine("Pintu tidak terkunci");
        }
        return nextState;
    }

    public void activeTrigger(Trigger trigger)
    {
        DoorState nextState = getNextState(currentState, trigger);
        currentState = nextState;
    }
}

