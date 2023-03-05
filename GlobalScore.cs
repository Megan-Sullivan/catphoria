using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    public static int CurrentScore;
    public int InternalScore;
    public Text ScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InternalScore = CurrentScore;
        ScoreDisplay.text = "Score: " + InternalScore;
    }
}