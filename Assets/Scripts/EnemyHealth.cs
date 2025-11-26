using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 1;

    int health;

    float animOffset = -1.5f;

    [SerializeField]
    AudioClip hurtSound;

    [SerializeField]
    AudioClip deathSound;

    [SerializeField]
    GameObject deathObject;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
    }

    public void Hurt(int amount)
    {
        health -= amount;
        if(audioSource != null && hurtSound != null)
        {
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(deathObject != null)
        {
            if(audioSource != null && deathSound != null)
            {
            audioSource.PlayOneShot(deathSound);
            }

            UnityEngine.Vector3 spawnPos = transform.position;
            spawnPos.y += animOffset;

            Instantiate(deathObject, spawnPos, UnityEngine.Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
