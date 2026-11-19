using UnityEngine;
using TMPro;

public class HealthAndDamage : MonoBehaviour
{ 
    private float xOne, XTwo, ZOne, ZTwo;
    private float sumOne, sumTwo;
    private float xSquared, zSquared;
    private bool takeDamage;
    public GameObject character, enemy;
    public float distance, distanceToCheckFor, damage, health, maxHealth, medkitHealth;
    private float roundedHealth;
    public TMP_Text currentHealth;

    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        roundedHealth = Mathf.Round(health);
        currentHealth.text = "Health: " + roundedHealth.ToString();

        if(health < 50)
        {
            currentHealth.color = Color.red;
        }
        else
        {
            currentHealth.color = Color.blue;
        }

        //enemy distance calculation
        sumOne = (XTwo - xOne);
        sumTwo = (ZTwo - ZOne);

        xOne = character.transform.position.x;
        XTwo = enemy.transform.position.x;

        ZOne = character.transform.position.z;
        ZTwo = enemy.transform.position.z;

        xSquared = Mathf.Pow(sumOne, 2);
        zSquared = Mathf.Pow(sumTwo, 2);

        distance = Mathf.Sqrt(xSquared + zSquared);
        //Debug.Log(Mathf.Round(distance));

        //take damage
        if (distance <= distanceToCheckFor)
        {
            takeDamage = true;
            health -= damage;
            Debug.Log(Mathf.Round(damage));
        }

        //kill character
        if(health <= 0)
        {
            health = 0;
            Debug.Log("Character has died.");
            character.SetActive(false);
            currentHealth.text = "You're dead. GG";
            currentHealth.color = Color.black;
        }

        //constantly check if health goes over the allowed amount
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }   
}
