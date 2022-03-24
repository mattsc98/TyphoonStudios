using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    float endPos;
    public float timer, timeSpeed, timeToMove;
    public Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        endPos = Random.Range(-5f, 5f);
        newPos = new Vector3(endPos, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * timeSpeed;

        if(timer >= timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * timeSpeed); 
            if (Vector3.Distance(transform.position, newPos) <= 0.1f)
            {
                endPos = Random.Range(-5f, 5f);
                newPos = new Vector3(endPos, transform.position.y, transform.position.z);

                timer = 0;
            }
            
        }


    }
}
