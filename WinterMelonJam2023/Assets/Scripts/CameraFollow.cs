using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private GameObject target;
    private PlayerGameLogic playerLogic;
    int playerHealth;

    private void Start()
    {
        playerLogic = target.GetComponent<PlayerGameLogic>();
    }
    private void Update()
    {
        if (playerLogic.HEALTH > 0)
        {
            Vector3 targetPosition = target.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
