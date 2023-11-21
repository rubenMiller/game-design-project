using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    public GameObject warningObject;
    public GameObject killObject;
    public GameObject groundObject;
    private float elapsedTime = 0f;
    private float stateTime = 1f;
    private string state = "neutral";


    void Start()
    {
        warningObject.SetActive(false);
        killObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (state != "neutral")
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > stateTime)
            {
                changeState();
                elapsedTime = 0;
            }
        }



        
    }

    void changeState()
    {
        switch (state)
        {
            case "neutral":
                // transition to warning state
                state = "warning";
                warningObject.SetActive(true);
                stateTime = 1f;
                elapsedTime = 0;
                break;

            case "warning":
                // transition to kill state
                state = "kill";
                stateTime = 2f;
                elapsedTime = 0;
                killObject.SetActive(true);
                warningObject.SetActive(false);
                //groundObject.SetActive(false);
                break;

            case "kill":
                // transition to neutral state
                state = "neutral";
                killObject.SetActive(false);
                warningObject.SetActive(false);
                groundObject.SetActive(true);
                elapsedTime = 0;
                break;
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.transform.TryGetComponent(out Frog frog) && state == "neutral")
        {
            changeState();
        }
    }

    /*void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.TryGetComponent(out Frog frog))
        {

        }
    }*/
}
