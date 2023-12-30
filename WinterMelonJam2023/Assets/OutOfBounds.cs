using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Set the damage amount in the Inspector.
    [Tooltip("Kills the player.")]
    public int damageAmount = 100;

    // This function is called when something enters the trigger collider of the spike.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is the player.
        PlayerGameLogic playerHealth = collision.GetComponent<PlayerGameLogic>();

        if (playerHealth != null)
        {
            // Deal 10 Damage
            playerHealth.HEALTH -= 100;
            Debug.Log("Dead");
        }
    }
}
