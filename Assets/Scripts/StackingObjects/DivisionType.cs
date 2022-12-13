using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DivisionType : MyBaseBehaviour,IPlayerPrefab
{
    private ObjectType PlayerType = ObjectType.DivisionApple;
    public void GateInstantianePrefab(GateType type, int GateSize)
    {
        switch (type)
        {
            case GateType.MultiPly:
                e_stackController.Apple.Remove(transform);
                e_objectPool.ReturnPoolObject(ObjectTag.DividedApple, gameObject);
                break;
            default:
                break;
        }
    }

    public void GetObstacle(ObjectType type , GameObject _gameObject)
    {
        switch (type)
        {
            case ObjectType.Obstackle:
                GameObject obj = e_objectPool.ReturnPoolObject(ObjectTag.DividedApple, gameObject);
                e_stackController.Apple.Remove(obj.transform);
                Debug.Log("ObstacleHit");
                break;
            default:
                break;
        }
    }

    public void GetSelectGate(SelectGate type, Transform _transform)
    {
        switch (type)
        {
            case SelectGate.Peeling:
                for (int i = 0; i < transform.childCount; i++)
                {
                    Debug.Log("Peeling");
                    transform.GetChild(i).GetComponent<MeshRenderer>().material = GameManager.Instance.PeelingMat;
                    transform.GetChild(i).GetComponent<MeshRenderer>().materials[1] = GameManager.Instance.PeelingMat;
                }
                break;
            default:
                break;
        }
    }

    public void GetTable(ObjectType type, Transform _transform)
    {
        switch (type)
        {
            case ObjectType.Table:
                e_stackController.Apple.Remove(transform);
                e_rigidbody.useGravity = true;
                e_rigidbody.drag = 10;
                e_sphereCollider.isTrigger = false;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IGate>()?.GetGateCollection(PlayerType, GateInstantianePrefab);
        other.GetComponent<IObstacle>()?.ObstacleInteract(PlayerType, gameObject, GetObstacle);
        other.GetComponent<ISelectGate>()?.GetGateSelection(PlayerType, transform, GetSelectGate);
        other.GetComponent<IFemale>()?.GetDinnerControl(PlayerType, transform, GetTable);
    }
}
