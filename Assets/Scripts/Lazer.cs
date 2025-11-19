using System.Collections;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] GameObject LazerSmall;
    [SerializeField] GameObject LazerLarge;
    [SerializeField] float lazerAlertTime;
    [SerializeField] float lazerActiveTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Errors to make sure everything is present
        if (LazerSmall != null)
        {
            Debug.LogError("LazerSmall not assinged");
        }
        if (LazerLarge != null)
        {
            Debug.LogError("LazerLarge not assinged");
        }
        if (LazerLarge.GetComponent<Collider>() != null)
        {
            Debug.LogError("LazerLarge not assinged hitbox");
        }

        StartCoroutine(LazerFire());
    }
    //Ienumorator for lazer fire
    IEnumerator LazerFire()
    {
        //Create lazer warning
        Instantiate(LazerSmall);

        yield return new WaitForSeconds(lazerAlertTime);

        //create lazer and destroy warning
        Instantiate(LazerLarge);
        Destroy(LazerSmall);

        yield return new WaitForSeconds(lazerActiveTime);

        //Destroy lazer
        Destroy(LazerLarge);
        yield break;
    }
}
