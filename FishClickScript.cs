using UnityEngine;
using UnityEngine.UI;

public class FishClickScript : MonoBehaviour
{
    private Vector3 bigScale, smallScale;

    public Text ScoreAmount;
    public AudioSource FishSplash1;
    private int scoreCount;

    private Vector3 mOffset;

    private float mZCoord;

    void Start()
    {
        bigScale = new Vector3(1.8f, 1.8f, 1.8f);
        smallScale = new Vector3(1f, 1f, 1f);

        scoreCount = 0;
        ScoreAmount.text = "Score: " + scoreCount;
    }
    
    private void OnMouseDown()
    {
        scoreCount += 10;
        ScoreAmount.text = "Score: " + scoreCount;

        FishSplash1.GetComponent<AudioSource>().Play();

        transform.localScale = bigScale;

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }

    private void OnMouseUp()
    {
        transform.localScale = smallScale;

    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;

    }
}
