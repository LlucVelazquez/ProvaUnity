using UnityEngine;
[RequireComponent(typeof(MoveBehaviour))]
public class Enemy2 : MonoBehaviour
{ 
    private MoveBehaviour _mb;
    public GameObject LimitL;
    public GameObject LimitR;
    private Vector2 direction = new Vector2(1,0);
    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
        
    }
    private void Update()
    {
        _mb.MoveCharacter(direction);
        if (LimitL.transform.position.x >= transform.position.x)
        {
            direction = new Vector2(1,0);
        }
        else if (LimitR.transform.position.x <= transform.position.x)
        {
            direction = new Vector2 (-1,0);
        }
    }
}
