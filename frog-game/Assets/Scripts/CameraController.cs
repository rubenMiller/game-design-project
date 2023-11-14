using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    //public GameOverScreen gameOverScreen;

   
    // Update is called once per frame
    void Update()
    {
        Vector3 movedTarget = new Vector3(target.position.x + 4, target.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, movedTarget, Time.deltaTime * speed);
    }
}
