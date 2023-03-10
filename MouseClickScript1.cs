using UnityEngine;
using UnityEngine.UI;

public class MouseClickScript1 : MonoBehaviour
{
    private Vector3 bigScale, smallScale;

    //public Text ScoreAmount; //Assign ScoreAmount object to script (for seperate score specific to game object)
    public AudioSource ButterflyHit; //Assign Audio File to script
    //private int scoreCount; //Integer used with a default of 0 to add to score (for seperate score specific to game object)

    private Vector3 mOffset; //Vector 3 offset used for mouse dragging script

    private float mZCoord; //Z coord variable for mouse dragging script

    void Start()
    {
        bigScale = new Vector3(1.2f, 1.2f, 1.2f); //Make object big when called
        smallScale = new Vector3(1f, 1f, 1f); //Make object small when called

        //scoreCount = 0; //Default score of zero set as integer (for seperate score specific to game object)
        //ScoreAmount.text = "Score: " + scoreCount; //Assign Score string and Score Count in to Score Amount text object (for seperate score specific to game object)
    }

    private void OnMouseDown()
    {
        //scoreCount += 10; //Adds 10 to score when mouse is clicked on object (for seperate score specific to game object)
        //ScoreAmount.text = "Score: " + scoreCount; //Updates the Score Amount text object with the new integer (+10) per click (for seperate score specific to game object)

        GlobalScore.CurrentScore += 5;

        ButterflyHit.GetComponent<AudioSource>().Play(); //Play audio source when mouse is clicked

        transform.localScale = bigScale; //Call statement when mouse is clicked to make object big

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //Store game object transformation to mZCoord variable

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }

    private void OnMouseUp()
    {
        transform.localScale = smallScale; // Transform object back to small size

    }

    //This function is specifically for being able to drag the object while holding down the mouse button
    private Vector3 GetMouseWorldPos()
    {
        // pixel coordinates (x, y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    //This function calls the above function during mouse dragging
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset; //Changes position of game object using the GetMouseWorldPos() function and the mOffset variable

    }
}
