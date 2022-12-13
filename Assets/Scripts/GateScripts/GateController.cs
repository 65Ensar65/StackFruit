using System;
using TMPro;
using UnityEngine;
public class GateController : MyBaseBehaviour,IGate
{
    [SerializeField] TextMeshProUGUI GateText;
    [SerializeField] GateType Gatetype;

    private int number;

    void Start()
    {
        GetGateController();
    }

    public void GetGateController()
    {
        if (Gatetype == GateType.Addition)
        {
            e_meshRenderer.material = GameManager.Instance.GateColorYellow;
            number = UnityEngine.Random.Range(1, 3);
            GateText.text = "+" + number;
        }

        else
        {
            e_meshRenderer.material = GameManager.Instance.GateColorRed;
            number = UnityEngine.Random.Range(-10, -1);
            GateText.text = number.ToString();
        }
    }
    public void GetGateCollection(ObjectType type, Action<GateType,int> action)
    {
        switch (type)
        {
            case ObjectType.Player:
                e_collider.enabled = false;
                GetNumberDecrease();
                action.Invoke(Gatetype,number);
                break;
            case ObjectType.StackApple:
                GetNumberDecrease();
                action.Invoke(Gatetype,number);
                break;
            case ObjectType.DivisionApple:
                GetNumberDecrease();
                action.Invoke(Gatetype,number);
                break;
            default:
                break;
        }
    }

    public void GetNumberDecrease()
    {
        if (Gatetype == GateType.MultiPly)
        {
            number++;
            GateText.text = number.ToString();
        }

        if (number == 0)
        {
            Destroy(gameObject);
        }
    }
}
public enum GateType
{
    Addition,
    MultiPly
}
