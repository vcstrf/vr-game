using System.Collections;
using UnityEngine;

public class TriggerChasing : MonoBehaviour
{
    public GameObject chaser;
    public float moveSpeed = 4f;
    public float maxDist = 10f;
    private bool triggered = false;
    private GameObject player;

    private void Start()
    {
        chaser.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            triggered = true;
        }
    }

    IEnumerator Chasing()
    {
        chaser.SetActive(true);

        yield return new WaitForSeconds(3f);

        if (player != null) {
            chaser.SetActive(true);
            chaser.transform.LookAt(player.transform);
            chaser.transform.position += chaser.transform.forward * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(player.transform.position, chaser.transform.position) <= maxDist)
            {
                Destroy(player);
            }
        }
    }

    private void Update()
    {
        if (triggered)
        {
            StartCoroutine(Chasing());
        }
    }
}
