using System.Security.Cryptography;
using UnityEngine;

public class ClickToBig : MonoBehaviour
{
    private Vector3 bigScale, smallScale;

    void Start()
    {
        bigScale = new Vector3(1.8f, 1.8f, 1.8f);
        smallScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseDown()
    {
        transform.localScale = bigScale;
    }

    private void OnMouseUp()
    {
        transform.localScale = smallScale;
    }
}
