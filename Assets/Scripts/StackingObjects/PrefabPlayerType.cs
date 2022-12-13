using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabPlayerType : MyBaseBehaviour,IPlayerPrefab
{
    private ObjectType PlayerType = ObjectType.StackApple;
    private bool _isDiving = true;
    public bool IsDivingMat
    { 
        get
        {
            return this._isDiving;
        }
        set
        {
            if (this._isDiving)
            {
                for (int i = 0; i < 1; i++)
                {
                    GameObject obj = e_objectPool.ActivePoolObject(ObjectTag.DividedApple, transform);
                    e_stackController.GetGateSelectStack(obj);
                    transform.parent = null;
                }

                e_objectPool.ReturnPoolObject(ObjectTag.Apple, gameObject);
                e_stackController.Apple.Remove(transform);
            }

            else
            {
                for (int i = 0; i < 1; i++)
                {
                    GameObject obj = e_objectPool.ActivePoolObject(ObjectTag.PeelingApple, transform);
                    e_stackController.GetGateSelectStack(obj);
                    transform.parent = null;
                }

                e_objectPool.ReturnPoolObject(ObjectTag.Apple, gameObject);
                e_stackController.Apple.Remove(transform);
            }
        }
    }

    private void Update()
    {
        Debug.Log(_isDiving + "diving");
    }
    public void GateInstantianePrefab(GateType type, int GateSize)
    {
        switch (type)
        {
            case GateType.MultiPly:
                transform.parent = null;
                e_stackController.Apple.Remove(transform);
                e_objectPool.ReturnPoolObject(ObjectTag.Apple, gameObject);
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
                GameObject obj = e_objectPool.ReturnPoolObject(ObjectTag.Apple, gameObject);
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
            case SelectGate.Divided:
                this.IsDivingMat = true;
                break;

            case SelectGate.Peeling:
                e_meshRenderer.material = GameManager.Instance.PeelingMat;
                this._isDiving = false;
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
