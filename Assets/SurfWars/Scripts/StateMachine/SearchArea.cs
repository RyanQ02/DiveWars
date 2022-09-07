using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
    public int switchPeriod = 30;
    bool isSearching = true;
    bool isDoneSearching = false;
    public bool Searching { get { return isSearching; } }
    public bool DoneSearching { get { return isDoneSearching; } }
    float timer = 0f;

    public SearchArea()
    {
        timer = switchPeriod;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isSearching = false;
        }
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 0f;
            isDoneSearching = true;
            isSearching = false;
            Destroy(gameObject);
        }
    }
}
