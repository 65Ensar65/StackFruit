using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStackController : MyBaseBehaviour,IPlayerStacked
{
    private ObjectType PlayerType = ObjectType.Player;

    public List<Transform> Apple = new List<Transform>();
    [SerializeField] float LerpSpeed;
    private void Update()
    {
        GetStackedController();
    }

    public void GetStackedController()
    {
        if (Apple.Count > 1)
        {
            for (int i = 1; i < Apple.Count; i++)
            {
                var FirstPos = Apple.ElementAt(i - 1);
                var SecondPos = Apple.ElementAt(i);

                SecondPos.position = new Vector3(Mathf.Lerp(SecondPos.position.x, FirstPos.position.x, LerpSpeed),
                                                            SecondPos.position.y,
                                                            FirstPos.position.z + 1f);
            }
        }

        if (Apple.Count == 0)
        {
            GameManager.Instance.GetLose();
        }
    }
    public void GateInstantianePrefab(GateType type, int GateSize)
    {
        if (type == GateType.Addition)
        {
            GameObject obj = null;
            for (int i = 0; i < GateSize; i++)
            {
                GetGateStack(obj);
            }
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IGate>()?.GetGateCollection(PlayerType, GateInstantianePrefab);
        other.GetComponent<IInteract>()?.Interact(PlayerType,transform,SelectFunchControl);
    }

    public void SelectFunchControl(ObjectType type, Transform _transform)
    {
        switch (type)
        {
            case ObjectType.StackApple:
                Apple.Add(_transform);
                break;
            default:
                break;
        }
    }

    public GameObject GetGateStack(GameObject obj)
    {
        obj = e_objectPool.ActivePoolObject(ObjectTag.Apple, transform);
        Apple.Add(obj.transform);
        obj.transform.position = new Vector3(Mathf.Lerp(obj.transform.position.x, transform.position.x, LerpSpeed),
                                                    obj.transform.position.y + .95f,
                                                    transform.position.z + 1.2f);

        return obj;
    }

    public GameObject GetGateSelectStack(GameObject obj)
    {
        Apple.Add(obj.transform);
        obj.transform.position = new Vector3(Mathf.Lerp(obj.transform.position.x, transform.position.x, LerpSpeed),
                                                    obj.transform.position.y + .95f,
                                                    transform.position.z + 1.2f);

        return obj;
    }
}
