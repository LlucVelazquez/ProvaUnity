using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float timeBetweenEnemies = 0f;
    private float initialTime = 3f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject leftLimit, rightLimit;
    public Stack<GameObject> EnemiesStack = new Stack<GameObject>();
    

    void Start()
    {

    }
    void Update()
    {
        if(Time.time >= timeBetweenEnemies)
        {
            if (EnemiesStack.Count == 0)
            {
                GameObject enem = Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
                enem.GetComponent<Enemy>().LimitL = leftLimit;
                enem.GetComponent<Enemy>().LimitR = rightLimit;
                enem.GetComponent<Enemy>().spawner = this;
            }
            else
            {
                Pop();
            }
            timeBetweenEnemies += initialTime;

        }
    }
    public void Push(GameObject go)
    {
        EnemiesStack.Push(go);
        go.SetActive(false);
    }
    public GameObject Pop()
    {
        GameObject go = EnemiesStack.Pop();
        go.SetActive(true);
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.identity;
        go.GetComponent<Rigidbody2D>().linearVelocityX = 4;
        return go;
        
    }
}
