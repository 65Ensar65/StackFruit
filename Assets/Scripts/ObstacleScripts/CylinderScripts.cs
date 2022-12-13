using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScripts : MonoBehaviour
{
    void Update()
    {
        GetObstacleController();
    }

    public void GetObstacleController()
    {
        transform.Rotate(new Vector3(0, 0,GameManager.Instance.CylindeSpeed));
    }
}
