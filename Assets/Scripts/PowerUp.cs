using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] Rigidbody2D bullets;
    float timer;
    public int i = 0;

    private void Update()
    {
 
        timer += Time.deltaTime;  
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rigidbody2D clone = Instantiate(bullets, transform.position, transform.rotation);
            clone.velocity = new Vector2(0, transform.position.y * 30);
            gameObject.GetComponent<ParticleSystem>().Play();
            i++;
        }
    }
}
