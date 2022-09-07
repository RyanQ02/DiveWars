using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour
{
    public AudioSource bossMusic;
    // Start is called before the first frame update
    void Start()
    {
        bossMusic.Play();
    }

}
