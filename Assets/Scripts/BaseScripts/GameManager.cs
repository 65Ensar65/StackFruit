using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MyBaseSingleton<GameManager>
{
    [Title("Player And Parent Rotate Values")]
    public float RotateSpeed;
    public float RotateClamp;
    [Range(0, 1)] public float RotateSmhoot;
    public Transform Player;

    [Title("Player Stack And Swipe Values")]
    public float SwipeSpeed;
    public float AppleDistance;


    [Title("Gate Number Color Values")]
    public Material GateColorRed;
    public Material GateColorYellow;

    [Title("Gate Material Values")]
    public Material DividedMat;
    public Material PeelingMat;

    [Title("Obstacle Values")]
    public float CylindeSpeed;

    [Title("Win And Lose Values")]
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject CanvasGroup;

    public void GetLose()
    {
        LosePanel.SetActive(true);
        CanvasGroup.SetActive(false);
        e_moveController.MoveSpeed = 0;
    }

    public void GetWin()
    {
        WinPanel.SetActive(true);
        CanvasGroup.SetActive(false);
        e_moveController.MoveSpeed = 0;
    }
}
