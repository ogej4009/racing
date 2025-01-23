using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum eITEMSPAWNTYPE
{
    NONE = 0,
    LEFT, 
    MIDDLE,
    RIGHT,
    MAX
}

[
    RequireComponent(typeof(RacingObject))
]

public class Gas : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private eITEMSPAWNTYPE eSpawnType = eITEMSPAWNTYPE.MAX;
    private float Speed = 3f;
    private readonly float duration = 1.2f;
    private readonly float Distance = 10f;
    private readonly int maxCount = 10;
    private readonly int minCount = 0;
    private readonly float spawnInterval = 0.2f;
    
    private List<GameObject> activeItems = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            
            if (activeItems.Count < maxCount)
                Spawn();
        }
        
    }

    private void Spawn()
    {
        GameObject g = Instantiate(prefab, RandomPosition(), Quaternion.identity);
        activeItems.Add(g);
        g.GetComponent<RacingObject>().OnDestroyed += ObjDestoryed;
    }
    
    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(0, (int)eITEMSPAWNTYPE.MAX), Random.Range(-Distance, Distance), 0f);
    }

    private void RandomSpawnTypeSetting(eITEMSPAWNTYPE eType)
    {
        int index = Random.Range(0, (int)eITEMSPAWNTYPE.MAX);
        
        switch (eType)
        {
            case eITEMSPAWNTYPE.NONE:
                break;
            case eITEMSPAWNTYPE.LEFT:
                break;
            case eITEMSPAWNTYPE.MIDDLE:
                break;
            case eITEMSPAWNTYPE.RIGHT:
                break;
            case eITEMSPAWNTYPE.MAX:
                break;
            default:
                break;
        }        
    }

    private void ObjDestoryed(GameObject g)
    {
        if(activeItems.Contains(g))
            activeItems.Remove(g);
    }
    
    
    void Update()
    {
        
    }

    
}
