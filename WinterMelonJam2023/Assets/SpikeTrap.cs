using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Set the damage amount in the Inspector.
    [Tooltip("Publicly set to 10. This will kill the player since the player only has 10 health.")]
    public int damageAmount = 10;

    // This function is called when something enters the trigger collider of the spike.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is the player.
        PlayerGameLogic playerHealth = collision.GetComponent<PlayerGameLogic>();

        if (playerHealth != null)
        {
            // Deal 10 Damage
            playerHealth.HEALTH -= 10;
            Debug.Log("BRUH");
        }
    }
}
