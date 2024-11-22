using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool verticle;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2d;

    bool broken;

    float timer;
    int direction = 1;

    Animator animator;  
    // Start is called before the first frame update
    void Start()
    {
      rigidbody2d  = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!broken)
        {
            return;
        }
        {
            
        }
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    void FixedUpdate()
    {
        if(!broken)
        {
            return;

        }
        Vector2 position = rigidbody2d.position;
        if(verticle)
        {
            animator.SetFloat("Move space X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * speed * direction;
        }
    

        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
         DuckoController player = other.gameObject.GetComponent<DuckoController>();
        if(player != null) 
        {
            player.ChangeHealth(-1);
        }
    }
    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("Fixed");
    }
}
