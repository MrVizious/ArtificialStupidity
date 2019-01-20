using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SimplePlatformController : MonoBehaviour
{

    private Collider2D platformCollider;
    private Collider2D stickManCheckCollider;
    [SerializeField]
    private int stickManCheck;
    public string enableKeyName;
    public string customKeyName;
    public bool startEnabled;



    void Start()
    {
        //Searches for both of the colliders, and assigns the trigger one to the stickManCheckCollider and the normal collider to the platformCollider
        foreach(Collider2D col in GetComponents<Collider2D>()){
            if(col.isTrigger){
                stickManCheckCollider = col;
            } else {
                platformCollider = col;
            }
        }
        platformCollider.enabled = startEnabled;
        stickManCheck = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stickManCheck < 0 ) stickManCheck = 0;
        if ((Input.GetKeyDown(enableKeyName) && Input.GetKey(customKeyName))
            || (Input.GetKey(enableKeyName) && Input.GetKeyDown(customKeyName))){
            if(platformCollider.enabled){
                platformCollider.enabled = false;
            } else {
                if(stickManCheck == 0) platformCollider.enabled = true;
            }
            if(debugKeyPressed) Debug.Log(enableKeyName + " key was pressed and " + customKeyName + " too");
            if(debugActivation) Debug.Log("Is the platform enabled? : " + platformCollider.enabled);
        }


    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("StickMan")) stickManCheck++;
        if(debugCount) Debug.Log("TriggerEnter: " + stickManCheck);
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag.Equals("StickMan")) stickManCheck--;
        if(debugCount) Debug.Log("TriggerExit: " + stickManCheck);
    }

    /***************************************************************************
     *                               DEBUGGING                                 *
     ***************************************************************************/

    public bool debugKeyPressed;
    public bool debugActivation;
    public bool debugCount;

}
