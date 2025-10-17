using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void MoveCharacter(Vector2 direction)
    {
        _rb.linearVelocityX = direction.x * speed;
    }
    public void JumpCharacter(Vector2 direction)
    {
        _rb.AddForce(direction, ForceMode2D.Impulse);
    }
}
