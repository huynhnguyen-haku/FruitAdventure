using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBackground;
    public Transform sideBackground;
    public float length;

    void Update()
    {
        if (mainCam.position.x > midBackground.position.x)
        {
            UpdatebackgroundPosition(Vector3.right);
        }
        else if (mainCam.position.x < midBackground.position.x)
        {
            UpdatebackgroundPosition(Vector3.left);
        }
    }
    void UpdatebackgroundPosition(Vector3 direction)
    {
        sideBackground.position = midBackground.position + direction * length;
        Transform temp = midBackground;
        midBackground = sideBackground;
        sideBackground = temp;
    }
}
