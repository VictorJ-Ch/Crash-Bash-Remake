using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager
{
    [Header("Player Life System")]
    public int Lives;
    public TextMeshProUGUI LivesUI;
    public GameObject PlayerObject;
    public GameObject BarrierObject;
    public Collider FieldCollider;
    public Color Color;
    public string Name;
}
