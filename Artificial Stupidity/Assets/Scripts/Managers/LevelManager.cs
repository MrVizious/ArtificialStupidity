using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static GameObject AI;

    private void Start()
    {
        AI = GameObject.Find("AI");
    }
}
