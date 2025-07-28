using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;

public class BackgroundScroller : MonoBehaviour
{
    [Header("스크롤 관련 속성값")]
    [SerializeField] private float scollSpeed = 2f;
    [SerializeField] private int visibleTileCount = 2;
    [SerializeField] private float groupWidth = 20.0f;
    [Header("배경 프리펩의 종류")]
    [SerializeField] private GameObject[] backgroundPrefabs;


    private Queue<GameObject> activeGroups = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < visibleTileCount; i++)
        {
            SpawnNextGroup(i * groupWidth);
        }
    }



    void Update()
    {
        foreach (var group in activeGroups)
        {
            group.transform.position += Vector3.left * scollSpeed * Time.deltaTime;
        }
        GameObject firstGroup = activeGroups.Peek();

        if (firstGroup.transform.position.x < -groupWidth)
        {
            Destroy(activeGroups.Dequeue());

            float newx = activeGroups.Peek().transform.position.x + groupWidth;
            SpawnNextGroup(newx);

        }


    }
    void SpawnNextGroup(float posX)
    {
        //어떤
        GameObject prefab = backgroundPrefabs[Random.Range(0, backgroundPrefabs.Length)];
        GameObject newGroup = Instantiate(prefab, new Vector3(posX, 0f, 0f), Quaternion.identity);
        activeGroups.Enqueue(newGroup);
    }
}