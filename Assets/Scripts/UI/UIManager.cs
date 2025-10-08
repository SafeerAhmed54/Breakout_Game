using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelNum;
    [SerializeField] private TextMeshProUGUI scoreNum;
    void Start()
    {
        levelNum.text = "Level " + 1;
        scoreNum.text = "Score " + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
