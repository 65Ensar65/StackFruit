using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleDinnerType : MyBaseBehaviour, IFemale
{
    ObjectType objectType = ObjectType.Table;
    public void GetDinnerControl(ObjectType type, Transform _transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.StackApple:
                action.Invoke(objectType, transform);
                break;
            case ObjectType.DivisionApple:
                e_femaleAnimation.GetAnimate();
                StartCoroutine(WinDelay());
                action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }

    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(3);
        GameManager.Instance.GetWin();
    }
}
