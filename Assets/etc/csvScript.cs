using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csvScript : MonoBehaviour
{

    public TextAsset mapCSV;
    public GameObject[] tilePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        LoadMap();
    }

    // Update is called once per frame
    void Update()
{

}
    void LoadMap()
    {
        string[] lines = mapCSV.text.Split('\n');
        List<List<int>> mapData = new List<List<int>>();

        foreach (string line in lines)
        {
            List<int>row=new List<int>();
            string[] entries= line.Trim().Split(',');

            foreach (string emtry in entries)
            {
                int value;
                if(int.TryParse(emtry, out value))
                {
                    row.Add(value);
                }
            }

            mapData.Add(row);
        }
        GenerateMap(mapData);
    }

    void GenerateMap(List<List<int>> mapData)
    {
        for (int y = 0; y < mapData.Count; y++)
        {
            for (int x = 0; x < mapData[y].Count; x++)
            {
                int tileType = mapData[y][x];

                if (tileType < tilePrefabs.Length)
                {
                    // プレハブからタイルを生成
                    GameObject tile = Instantiate(tilePrefabs[tileType], new Vector3(x, -y, 0), Quaternion.identity);
                }
            }
        }
    }
}
