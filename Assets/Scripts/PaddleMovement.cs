using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float min;
    [SerializeField] float max;
    [SerializeField] GameObject cannons;
    bool PowerUpActive=false;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosx = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(mousePosx, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePosx, min, max);
        transform.position = paddlePosition;
        num = 0;
        
        if(PowerUpActive)
        {
            num = cannons.GetComponentInChildren<PowerUp>().i;
            if(num>5)
            {
                PowerUpActive = false;  
                cannons.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Icon")
        {
           
            PowerUpActive = true;
            cannons.SetActive(true);
            
            cannons.GetComponentsInChildren<PowerUp>();
            cannons.GetComponentInChildren<PowerUp>().i = 0;
            
        }
    }
}
