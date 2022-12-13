using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSelectController : MyBaseBehaviour,ISelectGate
{
    public SelectGate SelectGates;

    public void GetGateSelection(ObjectType type, Transform _transform, Action<SelectGate, Transform> action)
    {
        switch (type)
        {
            case ObjectType.StackApple:
                action.Invoke(SelectGates, transform);
                break;

            case ObjectType.DivisionApple:
                action.Invoke(SelectGates, transform);
                break;
            default:
                break;
        }
    }
}

public enum SelectGate
{
    Divided,
    Peeling
}
