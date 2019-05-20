using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject crystal;
    public float offset = 0.707f;
    public Vector3 lastPos;

    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }
    public void CreateNewRoadPart()
    {
        Vector3 spawnPos = Vector3.zero;

        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);

        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }
        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        lastPos = g.transform.position;
        float crystalPos = Random.Range(-0.5f, 0.5f);
        crystal.transform.position = new Vector3(crystalPos, 0.5f, 0f);
        roadCount++;
        if (roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void CleanUpRoad() // TODO destroy the road as the player passes it
    {
        Destroy(roadPrefab, 2f);
    }
    
}
