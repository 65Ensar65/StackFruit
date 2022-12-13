using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MyBaseBehaviour,IPlayerMove
{
    public float MoveSpeed;
    [SerializeField] float SwipeClamp;
    void Update()
    {
        GetMoveController();
    }

    public void GetMoveController()
    {
        if (e_joystick.Horizontal != 0)
        {
            e_rigidbody.velocity = new Vector3(0,0,MoveSpeed);

            transform.position = new Vector3(Mathf.Clamp((transform.position.x + e_joystick.Horizontal * GameManager.Instance.SwipeSpeed * Time.deltaTime),-SwipeClamp,SwipeClamp),
                                                          transform.position.y,
                                                          transform.position.z);
        }

        else
        {
            e_rigidbody.velocity = Vector3.zero;
        }
    }
}
