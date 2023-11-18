using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpDirectionIndicator : MonoBehaviour
{
    public float AngleDeg = 0;
    public Vector3 Direction;
    public GameObject ParabolaPoonts;
    private List<GameObject> Circles;

    void Start()
    {
        
    }
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 distanceV = -1 * new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        float distance = distanceV.magnitude / 3;
        if (distance < 0.5f) {distance = 0.5f;}
        if (distance > 2f) {distance = 2f;}
        CrossSceneInformation.frogJumpForce = distance;

        // set the length
        float x = 0.5f * distance + 0.5f;
        this.transform.localScale = new Vector3(x, this.transform.localScale.y, this.transform.localScale.z);

        // set the angle
        float AngleRad = Mathf.Atan2(distanceV.y, distanceV.x);
        AngleDeg = (180f / Mathf.PI) * AngleRad;
        //Debug.Log("Degree: " + AngleDeg);
        if (AngleDeg < 10 && AngleDeg >= -90) { AngleDeg = 10; }
        if (AngleDeg > 170 || AngleDeg < -90) { AngleDeg = 170; }

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        Direction = transform.right;

        //Vecor3 Direction = jdi.Direction * frog.upForce * CrossSceneInformation.frogJumpForce;

        PlotTrajectory(transform.position, CrossSceneInformation.dir, 0.06f);
    }

    public void PlotTrajectory (Vector3 start, Vector3 startVelocity, float timestep) {
    Vector3 prev = start;
    for (int i=0; i < ParabolaPoonts.transform.childCount ;i++) {

        float t = timestep*(i + 2);
        //if (t > maxTime) break;
        Vector3 pos = PlotTrajectoryAtTime (start, startVelocity, t);
        var circle = ParabolaPoonts.transform.GetChild(i);
        circle.transform.position = pos;
        Debug.DrawLine (prev,pos,Color.red);
        prev = pos;
    }
}


    public Vector3 PlotTrajectoryAtTime (Vector3 start, Vector3 startVelocity, float time) 
    {
        return start + startVelocity*time + Physics.gravity*time*time*0.5f;
    }
}
