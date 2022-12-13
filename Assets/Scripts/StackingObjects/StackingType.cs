using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingType : MyBaseBehaviour,IInteract
{
    ObjectType StackType = ObjectType.StackApple;

    public void Interact(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                Destroy(GetComponent<StackingType>());
                transform.parent = null;
                action.Invoke(StackType, transform);
                break;
            default:
                break;
        }
    }
}
