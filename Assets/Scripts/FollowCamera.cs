using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject objectToFollow;
    [SerializeField] int cameraDistance;
    Vector3 cameraDistanceVector;

    void Start()
    {
        cameraDistanceVector = new Vector3(0, 0, cameraDistance);
    }


    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + cameraDistanceVector;
    }
}
