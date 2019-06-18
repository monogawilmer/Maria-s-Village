using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class glasses : MonoBehaviour
{
    public Transform from;
    public Transform target;
    public float speed;
    public Transform to;
    private Vector3 start, end;

    // Start is called before the first frame update
    void onDrawGizmosSelected()
    {
        Gizmos.color= Color.cyan;
        Gizmos.DrawLine(@from.position,to.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        target.parent = null;
        start = transform.position;
        end = target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float fixedSpeed = speed * Time.deltaTime;
        transform.position=Vector3.MoveTowards(transform.position, target.position,fixedSpeed);
        if (target.position == transform.position)
        {
            target.position = (target.position == start) ? end : start;
        }
    }
}
