using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleType : MyBaseBehaviour, IObstacle
{
    ObjectType ObsType = ObjectType.Obstackle;
    public void ObstacleInteract(ObjectType type, GameObject _transform, Action<ObjectType, GameObject> action)
    {
        switch (type)
        {
            case ObjectType.StackApple:
                action.Invoke(ObsType, gameObject);
                break;
                case ObjectType.DivisionApple:
                action.Invoke(ObsType, gameObject);
                break;
            default:
                break;
        }
    }
}
