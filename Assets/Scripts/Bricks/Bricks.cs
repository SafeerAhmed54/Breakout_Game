using UnityEngine;

public class Bricks : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
