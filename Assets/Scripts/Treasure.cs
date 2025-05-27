using UnityEngine;

public class Treasure : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectTreasure();
            Destroy(gameObject);
        }
    }
}
