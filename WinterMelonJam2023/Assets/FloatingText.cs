using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Transform target; // Reference to the 2D game object this text will float above.
    public Vector3 offset = new Vector3(0f, 1.5f, 0f); // Offset to adjust the height of the text above the target.

    private void Update()
    {
        if (target != null)
        {
            // Position the text above the target object.
            transform.position = target.position + offset;
        }
    }
}
