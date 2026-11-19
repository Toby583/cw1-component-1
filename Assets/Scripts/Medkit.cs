using UnityEngine;

public class Medkit : MonoBehaviour
{ 
    [SerializeField] private HealthAndDamage healthandDamage;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is close to a health kit!");
            healthandDamage.health += healthandDamage.medkitHealth;
            Destroy(gameObject);
        }
    }
}
