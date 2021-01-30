using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBehavior : MonoBehaviour
{
    PaddleMovement paddle;
    LoseCollider losecol;
    private void Start()
    {
        paddle = FindObjectOfType<PaddleMovement>();
        losecol = FindObjectOfType<LoseCollider>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Paddle"|| collision.gameObject.tag=="LoseCollider")
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
