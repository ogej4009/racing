using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private GameObject track;
    private int trackMaxCount = 2;
    private float trackSpeed = 10f;
    private float trackDuration = 2f;
    private float trackLength = 50f;
    private Queue<GameObject> activeTrack = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < trackMaxCount; i++)
        {
            SpawnTrack(i * trackLength);    
        }
        
        StartCoroutine(SpawnDelay());
    }
    
    void Update()
    {
        foreach (var t in activeTrack)
        {
            t.transform.Translate(Vector3.back * (Time.deltaTime * trackSpeed));
        }

        if (activeTrack.Count > 0 && activeTrack.Peek().transform.position.z <= -trackLength)
        {
            GameObject go = activeTrack.Dequeue();
            RepositionTrack(go);
            activeTrack.Enqueue(go);
        }
    }

    void SpawnTrack(float _Length)
    {
        GameObject newTrack = Instantiate(track, new Vector3(0f, 0f, _Length), Quaternion.identity);
        activeTrack.Enqueue(newTrack);
    }

    void RepositionTrack(GameObject _go)
    {
        float trackPosZ = activeTrack.Count * trackLength;
        _go.transform.position = new Vector3(0,0,trackPosZ);
    }

    private IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(trackDuration);

            if (activeTrack.Count < trackMaxCount)
            {
                SpawnTrack(activeTrack.Count * trackLength);
            }
        }
    }
}
