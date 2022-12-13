using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleAnimation : MonoBehaviour
{
    public void GetAnimate()
    {
        transform.PlayAnim((int)AnimState.CLAP);
    }
}
public enum AnimState
{
    IDLE,
    CLAP
}
