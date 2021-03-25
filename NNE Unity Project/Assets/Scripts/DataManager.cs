using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] DataCube[] dataCubes;

    void Awake()
    {
        TextAsset cubeData = Resources.Load<TextAsset>("Metadata");

        string[] data = cubeData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });

            dataCubes[i - 1].ID = int.Parse(row[0]);
            dataCubes[i - 1].Name = row[1];
            dataCubes[i - 1].Info = row[2];
            dataCubes[i - 1].Percentage = float.Parse(row[3]);
            dataCubes[i - 1].LastEdit = row[4];
            dataCubes[i - 1].DetailedDescription = row[5];
        }
    }
}
