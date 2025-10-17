using UnityEngine;
using System.Collections.Generic;

public class TreeEx2 : MonoBehaviour, IDamageableEx2
{
    [SerializeField] private List<string> _items;  //0 fulla 1:fusta 2:poma
    [SerializeField] private int _maxNumberOfDrops = 5;
    private int _currentDrops = 0;
    public void Hurt(int damage)
    {
        Drop();
    }
    public void Drop()
    {
        Debug.Log("drop " + _items[0]);
        Debug.Log("drop " + _items[1]);
        int rand = Random.Range(0, 5);
        if(rand == 0 && _currentDrops < _maxNumberOfDrops)
        {
            _currentDrops++;
            Debug.Log("drop " + _items[2]);
        }
    }
}
