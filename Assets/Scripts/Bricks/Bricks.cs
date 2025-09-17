using UnityEngine;

public class Bricks : MonoBehaviour
{
    // Collision Detection for Ball
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
