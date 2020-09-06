 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float ScrollSpeed = 15;
    void Update()
    {
        if (Input.mousePosition.y >= Screen.height * 0.95f)
        {
            if (Input.mousePosition.x >= Screen.width * 0.95f)
            {
                if (transform.localPosition.z <= -15)
                {
                }
                else
                {
                    transform.Translate(0, 0, -1 * Time.deltaTime * ScrollSpeed / 2, Space.World);
                }
            }
            else if (Input.mousePosition.x <= 100)
            {
                if (transform.localPosition.z >= 85)
                {
                }
                else
                {
                    transform.Translate(0, 0, 1 * Time.deltaTime * ScrollSpeed / 2, Space.World);
                }
            }
            if (transform.localPosition.x >= 0)
            {
                return;
            }
           
           
            transform.Translate(1 * Time.deltaTime * ScrollSpeed, 0,0, Space.World);
        }
        else if (Input.mousePosition.y <= 100) 
        {
            if (Input.mousePosition.x >= Screen.width * 0.95f)
            {
                if (transform.localPosition.z <= -15)
                {
                }
                else
                {
                    transform.Translate(0, 0, -1 * Time.deltaTime * ScrollSpeed / 2, Space.World);
                }
            }
            else if (Input.mousePosition.x <= 100)
            {
                if (transform.localPosition.z >= 85)
                {
                }
                else
                {
                    transform.Translate(0, 0, 1 * Time.deltaTime * ScrollSpeed / 2, Space.World);
                }
            }
            if (transform.localPosition.x <= -100)
            {
                return;
            }
            transform.Translate(-1 * Time.deltaTime * ScrollSpeed, 0,0 , Space.World);
        }


        else if (Input.mousePosition.x >= Screen.width * 0.95f)
        {
            if (transform.localPosition.z <= -15)
            {
                return;
            }
            transform.Translate(0, 0, -1 * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if (Input.mousePosition.x <= 100)
        {
            if (transform.localPosition.z >= 85)
            {
                return;
            }         
            transform.Translate(0, 0, 1 * Time.deltaTime * ScrollSpeed, Space.World);
        }
    }
}
