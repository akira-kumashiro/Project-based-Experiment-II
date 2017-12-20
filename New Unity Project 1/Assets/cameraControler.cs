using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    private GameObject player = null;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 from = player.transform.position;
        Vector3 to = transform.position;
        if (Physics.Linecast(from, to))
        {
            Debug.Log("blocked");
        }
        else
        {
            Debug.Log("");
        }
    }
}
