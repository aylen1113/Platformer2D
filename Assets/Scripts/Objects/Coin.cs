using UnityEngine;
using UnityEngine.Events;


public class Coin : MonoBehaviour, ICollectable
{
    //public static event System.Action<int> CoinEvent; 

    public delegate void CoinEvent(int add);

    public static CoinEvent coinEvent;

    public int value = 1;
    private int add = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {
       
        coinEvent?.Invoke(add);
        Destroy(this.gameObject);
    
}
}
