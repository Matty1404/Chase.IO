using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{

    private float rotationSpeed = 50f;
    private float amplitude = 2f;
    private float frequency = 0.5f;
    private float absorbDist; // proportional to player size;
    public float speed = 0.5f;
    private int blobValue;


    // public GameObject blobPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-200f,200f), 5, Random.Range(-200f,200f));
        // transform.position = new Vector3(10, 8, 10);
        blobValue = Random.Range(10,100);

        absorbDist = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        FloatAndRotate();
    }

    void FloatAndRotate() {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude) + 5, transform.position.z);
    }

    public void PlayerEat(GameObject player) 
    {
        Vector3 delta = player.transform.position - transform.position;
        Vector3 direction = delta.normalized;
        float rate = absorbDist * 1.5f / Vector3.Distance(transform.position, player.transform.position);
        transform.position += direction * Time.deltaTime * speed * rate;
    }

    public bool DestroyBlob(GameObject player) {
        if (Vector3.Distance(transform.position, player.transform.position) < 8) {
            InteractWithBlob playerInteraction = player.GetComponent<InteractWithBlob>();
            playerInteraction.interact(blobValue);
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    // private void CreateBlob() {
    //     GameObject blobInstance = (GameObject)Instantiate(blobPrefab);
    //     Blob blob = blobInstance.GetComponent<Blob>();
    // }

}
