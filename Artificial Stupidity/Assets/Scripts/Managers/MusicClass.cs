using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GetComponent<AudioSource>().Play();
    }
}