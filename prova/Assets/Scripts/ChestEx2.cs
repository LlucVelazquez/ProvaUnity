using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ChestEx2 : MonoBehaviour, IDamageableEx2
{
    public void Hurt(int damage)
    {
        Open();
    }
    public void Open()
    {
        Debug.Log("Obert cofre");
    }
}
