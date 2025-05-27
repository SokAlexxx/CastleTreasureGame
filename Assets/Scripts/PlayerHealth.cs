using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && !isDead)
        {
            isDead = true;
            GameManager.instance.LoseGame();
        }
    }
}
