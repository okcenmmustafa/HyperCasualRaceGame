using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetPointManager : MonoBehaviour
{
    public List<GameObject> TargetPoints;
    int sizeOfPointList;
    public int instantiateSize = 5;
    private GameObject[,] PointCategorize;

    void Awake()
    {
        sizeOfPointList = TargetPoints.Count;
        PointCategorize = new GameObject[sizeOfPointList, instantiateSize];
        foreach (var item in TargetPoints.Select((value, i) => new { i, value }))
        {
            var value = item.value;
            var index = item.i;
            for (int j = 0; j < instantiateSize; j++)
            {

                PointCategorize[index, j] = Instantiate(value, new Vector3(value.transform.position.x + (2 * j), value.transform.position.y, value.transform.position.z), Quaternion.identity);
            }
        }
       
    }
    public GameObject[,] pointCategorize
    {
        get { return PointCategorize; }
        set { PointCategorize = value; }
    }
}
