using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerPlantHead : MonoBehaviour
{
    private float elapsedTime = 0f;
    public float dangerTime = 2f;
    public float freindlyTime = 4f;


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        foreach (Transform child in transform)
        {
            bool active = child.gameObject.activeSelf;
            if (elapsedTime >= dangerTime && active)
            {
                child.gameObject.SetActive(false);
                elapsedTime = 0;
            }
            if (elapsedTime >= freindlyTime && !active)
            {
                child.gameObject.SetActive(true);
                elapsedTime = 0;
            }
        }
    }
}
