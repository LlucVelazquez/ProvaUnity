using UnityEngine;

public class Axe : MonoBehaviour
{
    private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<IDamageableEx2>(out IDamageableEx2 iDmg))
        {
            iDmg.Hurt(damage);
        }
        Attack();
    }
    public void Attack()
    {

    }
}
