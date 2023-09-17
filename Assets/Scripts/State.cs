using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void StartState(Dancer dancer);
    public abstract void UpdateState(Dancer dancer);

    public abstract void LookedAt(Dancer dancer);

    public abstract void LookedAwayFrom(Dancer dancer);

    public abstract void ExitState(Dancer dancer);
}
