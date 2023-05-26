using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobCreator : MonoBehaviour
{
    public GameObject blobPrefab;
    // Start is called before the first frame update
    private List<GameObject> blobs;
    void Start()
    {
        blobs = new List<GameObject>();
    }

    public GameObject CreateBlob() {
        GameObject blobInstance = Instantiate(blobPrefab);
        Blob blob = blobInstance.GetComponent<Blob>();
        return blobInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            for (int i = 0; i < 10; i++) {
                blobs.Add(CreateBlob());
            }
        }
    }

    public List<GameObject> GetBlobs() {
        return blobs;
    }
}
