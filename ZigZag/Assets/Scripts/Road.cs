using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;

    public Vector3 lastPos;

    public float offset = 0.707f;

    private int RoadCount = 0;
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, .5f);
    }
    // Start is called before the first frame update
    public void CreateNewRoadPart()
    {
        Debug.Log("Create new road part");

        Vector3 spawnPos = Vector3.zero;

        float chance = Random.Range(0, 100);
        if (chance < 50){
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos=new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }
        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        lastPos = g.transform.position;

        RoadCount++;
        if(RoadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
