using UnityEngine;

public class BrickRandomPosition : MonoBehaviour
{
    [Header("Random Position Settings")]
    [SerializeField] private Vector2 xRange = new Vector2(-5f, 5f); // Range for x position
    [SerializeField] private Vector2 yRange = new Vector2(1f, 5f);  // Range for y position

    [Header("References")]
    [SerializeField] private BricksInstantiation bricksInstantiation; // Reference to your pool

    private void Start()
    {
        if (bricksInstantiation == null)
        {
            bricksInstantiation = FindObjectOfType<BricksInstantiation>();
        }
        ActivateAllBricks();
    }
    public Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(xRange.x, xRange.y);
        float randomY = Random.Range(yRange.x, yRange.y);
        return new Vector3(randomX, randomY, 0f); // Assuming z=0 for 2D
    }

    // Activate all pooled objects at random positions
    public void ActivateAllBricks()
    {
        foreach (Transform brick in bricksInstantiation.transform)
        {
            brick.gameObject.SetActive(true);
            brick.position = GetRandomPosition();
        }
    }
}
