using System;
using UnityEngine;

public interface IPlayerMove
{
    void GetMoveController();
}

public interface IPlayerStacked
{
    void GetStackedController();

    void SelectFunchControl(ObjectType type, Transform _transform);
}

public interface IInteract
{
    void Interact(ObjectType type , Transform _transform , Action<ObjectType,Transform> action);
}

public interface IObstacle
{
    void ObstacleInteract(ObjectType type, GameObject _transform, Action<ObjectType, GameObject> action);
}

public interface IGate
{
    void GetGateController();
    void GetGateCollection(ObjectType type ,Action<GateType,int> action);
}

public interface ISelectGate
{
    void GetGateSelection(ObjectType type, Transform _transform , Action<SelectGate,Transform> action);
}

public interface IPlayerPrefab
{
    void GateInstantianePrefab(GateType type, int GateSize);
    void GetObstacle(ObjectType type, GameObject _gameObject);
    void GetSelectGate(SelectGate type, Transform _transform);
    void GetTable(ObjectType type , Transform _transform);
}

public interface IFemale
{
    void GetDinnerControl(ObjectType type , Transform _transform , Action<ObjectType,Transform> action);
}

public enum ObjectType
{
    Player,
    StackApple,
    DivisionApple,
    Obstackle,
    Table
}
