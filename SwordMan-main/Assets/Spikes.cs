using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 20f;
    public float knockbackForce = 5f;

    private bool playerInSpikes = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Spikes triggered by: " + other.name);

        if (!playerInSpikes && other.CompareTag("Player"))
        {
            Debug.Log("Player entered spikes");

            PlayerStats stats = other.GetComponent<PlayerStats>();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (stats != null && rb != null)
            {
                stats.TakeDamage(damage);

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, knockbackForce);

                playerInSpikes = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSpikes = false;
        }
    }
}
