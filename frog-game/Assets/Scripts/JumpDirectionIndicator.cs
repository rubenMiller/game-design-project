using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpDirectionIndicator : MonoBehaviour
{
    public float AngleDeg = 0;
    public Vector3 Direction;
    void Update()
    {
        float x = 0.5f * CrossSceneInformation.frogMousePressedPercentage + 0.5f;

        this.transform.localScale = new Vector3(x, this.transform.localScale.y, this.transform.localScale.z);


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        AngleDeg = (180f / Mathf.PI) * AngleRad;
        //Debug.Log("Degree: " + AngleDeg);
        if (AngleDeg < 10 && AngleDeg >= -90) { AngleDeg = 10; }
        if (AngleDeg > 170 || AngleDeg < -90) { AngleDeg = 170; }

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        Direction = transform.right;
    }
}
