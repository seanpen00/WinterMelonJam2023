using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private GameObject target;
    private PlayerGameLogic playerLogic;
    private Rigidbody2D rb;
    int playerHealth;

    private void Start()
    {
        target = GameObject.Find("The Kevin");
        rb = target.GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (playerLogic == null)
        {
            playerLogic = target.GetComponent<PlayerGameLogic>();
            rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (playerLogic.HEALTH > 0)
        {
            Vector3 targetPosition = target.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
