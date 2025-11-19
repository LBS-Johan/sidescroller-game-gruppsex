using System.Collections;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] GameObject lazerIndicator;
    [SerializeField] GameObject lazer;

    [SerializeField] float lazerOffsetX;
    [SerializeField] float lazerOffsetY;

    [SerializeField] float lazerIndicatorTime;
    [SerializeField] float lazerActiveTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LazerFire());
    }
    //IeNum for lazer fire
    IEnumerator LazerFire()
    {
        //create copy of lazer and indicator
        GameObject lazerIndicatorClone = Instantiate(lazerIndicator, new Vector2(transform.position.x + lazerOffsetX, transform.position.y + lazerOffsetY), Quaternion.identity, transform);
        GameObject lazerClone = Instantiate(lazer, new Vector2(transform.position.x + lazerOffsetX, transform.position.y + lazerOffsetY), Quaternion.identity, transform);
        //temporarily set lazer indicator to innactive
        lazerClone.SetActive(false);

        //Wait before making lazer appear and removing indicator
        yield return new WaitForSeconds(lazerIndicatorTime);

        Destroy(lazerIndicatorClone);
        lazerClone.SetActive(true);

        //wait before removing rest of lazer
        yield return new WaitForSeconds(lazerActiveTime);

        Destroy(lazerClone);
        Destroy(gameObject);
    }

}
