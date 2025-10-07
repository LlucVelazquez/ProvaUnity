using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float speed;
    public GameObject LimitL;
    public GameObject LimitR;
    public SpawnEnemy spawner;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = 4;
        _rb.linearVelocityX = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject);
            spawner.EnemiesStack.Push(gameObject);
            gameObject.SetActive(false);
        }
    }
    
    private void Update()
    {
        
        if (LimitL.transform.position.x >= _rb.transform.position.x)
        {
            _rb.linearVelocityX = speed;
        }
        else if(LimitR.transform.position.x <= _rb.transform.position.x)
        {
            _rb.linearVelocityX = speed * -1;
        }
    }
}
