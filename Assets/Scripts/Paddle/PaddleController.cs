using UnityEngine;
using UnityEngine.UIElements;

public class PaddleController : MonoBehaviour
{
    [Header("Varaible for Paddles")]
    [SerializeField] private int paddleSpeed = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
        CheckBarrier();
    }

    private void MovePaddle()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * paddleSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * paddleSpeed * Time.deltaTime);
    }

    private void CheckBarrier()
    {
        // Prevent paddle from going out of bounds
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -8.0f, 8.0f); // Assuming the play area is between -8 and 8 on the x-axis
        transform.position = position;
    }
}
