using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public UnityEvent ColObstacle;
    public UnityEvent ColGoalLine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(collision.gameObject.tag);        
            
            ColObstacle?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoalLine"))
        {
            Debug.Log(collision.gameObject.tag);

            ColGoalLine?.Invoke();
        }
    }
}
