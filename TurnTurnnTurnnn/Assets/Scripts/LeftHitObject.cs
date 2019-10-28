using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHitObject : MonoBehaviour
{
    public bool hit;


    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            hit = false;
        }
    }
}
