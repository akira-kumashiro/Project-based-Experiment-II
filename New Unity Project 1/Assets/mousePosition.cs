using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class mousePosition : MonoBehaviour
{
    private Rigidbody rBody;
    private GameObject obj;
    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        obj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float mousePositionXCenter = 0.0f;
        float mousePositionYCenter = 0.0f;
        Vector3 mousePosition = Input.mousePosition;

        /*スクリーン中央を(0,0)に*/
        mousePositionXCenter = (mousePosition.x - Screen.width / 2) / Screen.width * 2;
        mousePositionYCenter = (mousePosition.y - Screen.height / 2) / Screen.height * 2;

        if (System.Math.Abs(mousePositionXCenter) > 1.0f)
        {
            //obj.GetComponent<Renderer>().material.color = Color.red;//new Color(mousePositionXCenter - 1.0f, 0.0f, 0.0f);
            mousePositionXCenter = (mousePositionXCenter > 0.0f) ? 1.0f : -1.0f;
        }

        if (System.Math.Abs(mousePositionYCenter) > 1.0f)
        {
            //obj.GetComponent<Renderer>().material.color = Color.red;//new Color(mousePositionYCenter - 1.0f, 0.0f, 0.0f);
            mousePositionYCenter = (mousePositionYCenter > 0.0f) ? 1.0f : -1.0f;
        }

        rBody.transform.localPosition = new Vector3(mousePositionXCenter * 4.0f, mousePositionYCenter * 3.0f, -0.5f);

        /*rBody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        rBody.transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
        rBody.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);*/
    }
}
