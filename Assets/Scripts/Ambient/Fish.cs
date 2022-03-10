using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    public int radius;

    private GameObject raft;
    private Vector3 pos;
    private float time;

    void Start()
    {
        raft = GameObject.FindGameObjectWithTag("Raft");
        radius = 12;
        speed = 0.1f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        float x = Waves.instance.GetWaveHeight(transform.position.x);
        float z = Waves.instance.GetWaveHeight(transform.position.z);
        float waveHeight = x + z;

        pos = transform.position;

        time += Time.deltaTime;
        
        //Will rotate around the raft slowly
        pos.y = waveHeight;

        pos.x = raft.transform.position.x + (radius * Mathf.Cos(time * speed));
        pos.z = raft.transform.position.z + (radius * Mathf.Sin(time * speed));
        gameObject.transform.position = pos;
    }
}
