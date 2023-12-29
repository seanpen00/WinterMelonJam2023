using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float distanceX = cam.transform.position.x * parallaxEffect;
        float distanceY = cam.transform.position.y * parallaxEffect;

        transform.position = new Vector3(startpos + distanceX, startpos + distanceY, transform.position.z);
    }
}
