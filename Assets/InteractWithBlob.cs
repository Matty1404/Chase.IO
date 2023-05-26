using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithBlob : MonoBehaviour
{
    // value depends on player size
    private int score;
    public GameObject player;
    private float circleRadius;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        circleRadius = 10;
        Vector3 size = new Vector3(circleRadius, 0.00001f, circleRadius);
        GameObject.Find("PlayerRing").transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> blobs = GameObject.Find("blobCreator").GetComponent<BlobCreator>().GetBlobs();
        List<GameObject> toRemove = new List<GameObject>();
        // checks each elem in blob array and eats if exists
        foreach (GameObject blob in blobs) {
             if (Vector3.Distance(transform.position, blob.transform.position) < circleRadius) {
                blob.GetComponent<Blob>().PlayerEat(gameObject);
                // if blob destroyed, then remove from list at end
                if (blob.GetComponent<Blob>().DestroyBlob(gameObject)) {
                    toRemove.Add(blob);
                }
             }
        }
        //remove blobs that are eaten
        foreach (GameObject blob in toRemove) {
            blobs.Remove(blob);
        }
        
    }

    public void interact(int blobValue) {
        // adds blob value to score
        score += blobValue;
        Debug.Log(score);

        // Changes the size of the cylinder
        circleRadius = (float)(10 + Math.Sqrt(score))/2;        
        Vector3 size = new Vector3(circleRadius, 0.00001f, circleRadius);
        GameObject.Find("PlayerRing").transform.localScale = size;
    }
    public int getScore() {
        return score;
    }
}
