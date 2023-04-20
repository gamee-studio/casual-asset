using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeControl : MonoBehaviour
{
    void OnTriggerEnter (Collider trig)
    {
        if(trig.gameObject.tag == "Ground")
        {
            GetComponent<VisualEffect>().Play();
        }
    }    
}
