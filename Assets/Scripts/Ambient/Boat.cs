using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float waterOffset = 1f;
    public float floatStrength = 3f;
    public float rotationLevel = 3f;
    public int buoyCount;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    public float height;

    private Vector3 pos;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() != null)
        {
            rigidBody = gameObject.GetComponent<Rigidbody>();
        }
        else
        {
            rigidBody = gameObject.transform.parent.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       // rigidBody.AddForceAtPosition(Physics.gravity / buoyCount, transform.position, ForceMode.Acceleration);
        float x = Waves.instance.GetWaveHeight(transform.position.x);
        float z = Waves.instance.GetWaveHeight(transform.position.z);

        pos = transform.position;
        rot = transform.rotation;
        
        rot.x = (Mathf.Acos(x/(Waves.instance.length+ Waves.instance.offset)) * Mathf.Rad2Deg) -90;
        rot.z = (Mathf.Acos(z / (Waves.instance.length + Waves.instance.offset)) * Mathf.Rad2Deg) -90;

        float waveHeight = x + z;
        pos.y = waveHeight + waterOffset;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot.x,0,rot.z);
        
    }
}