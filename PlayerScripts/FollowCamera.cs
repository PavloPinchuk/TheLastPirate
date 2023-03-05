using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void LateUpdate()
    {
        try
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
