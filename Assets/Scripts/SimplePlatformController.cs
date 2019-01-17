using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SimplePlatformController : MonoBehaviour
{

    private Collider2D platformCollider;

    public string keyName;
    public bool startEnabled;


    // Start is called before the first frame update
    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        platformCollider.enabled = startEnabled;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(keyName))
        {
            platformCollider.enabled = !platformCollider.enabled;
            if(debugKeyPressed) Debug.Log(keyName + " key was pressed");
            if(debugActivation) Debug.Log("Is the platform enabled? : " + platformCollider.enabled);
        }
    }



    /***************************************************************************
     *                               DEBUGGING                                 *
     **************************************************************************/

    public bool debugKeyPressed;
    public bool debugActivation;

}
