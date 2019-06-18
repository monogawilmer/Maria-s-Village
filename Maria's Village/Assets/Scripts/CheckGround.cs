using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called before the first frame update1
    private Character player;
    void Start()
    {
        player = GetComponentInParent<Character>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        player.grounded = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        player.grounded = false;
    }
}
