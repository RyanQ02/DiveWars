using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfView : MonoBehaviour
{
    public int switchPeriod = 10;
    private bool isInRange = false;
    public bool InRange { get { return isInRange; } }
    private float timer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
            timer = switchPeriod;
        }
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            timer = 0f;
            isInRange = false;
        }
    }
}
