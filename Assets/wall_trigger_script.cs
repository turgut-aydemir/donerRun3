using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_trigger_script : MonoBehaviour
{
    public GameObject roadSection;
    public GameObject[] objects = new GameObject[7];
    public GameObject objes;
    public static bool generateRoad = true;

    // Keep track of instantiated positions
    private List<Vector3> instantiatedPositions = new List<Vector3>();


    private void Awake()
    {
        //not needed, but here as backup
        /*
        objects = new GameObject[] {
        GameObject.FindGameObjectWithTag("Bird"),
        GameObject.FindGameObjectWithTag("NewCoin"),
        GameObject.FindGameObjectWithTag("Puddle"),
        GameObject.FindGameObjectWithTag("Pothole"),
        GameObject.FindGameObjectWithTag("Ayrab"),
        GameObject.FindGameObjectWithTag("Rat"),
        GameObject.FindGameObjectWithTag("Trashcan")
        Resources.Load("Bird") as GameObject,
        Resources.Load("NewCoin") as GameObject,
        Resources.Load("Puddle") as GameObject,
        Resources.Load("Pothole") as GameObject,
        Resources.Load("Ayrab") as GameObject,
        Resources.Load("Rat") as GameObject,
        Resources.Load("Trashcan") as GameObject
        };
        */
        
    }
       
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("section_trigger_collider") && generateRoad)
        {

            // Instantiate road section
            Instantiate(roadSection, new Vector3(0, 0, -21), Quaternion.identity);

            int numberOfObjes = Random.Range(3, 7);

            for (int i = 0; i < numberOfObjes; i++)
            {
                Vector3 randomSpawnPosition;

                do
                {
                    randomSpawnPosition = new Vector3(
                        GetRandomFromArray(new float[] { 12f, 6f, 0f }),
                        -1f,
                        GetRandomFromArray(new float[] { -21f, -24f, -27f, -30f})
                    );
                } while (PositionAlreadyUsed(randomSpawnPosition));

                int randomNumber = Random.Range(0, 7);
                objes = objects[randomNumber];

                // Instantiate objes at the new position
                Instantiate(objes, randomSpawnPosition, Quaternion.identity);
                //Debug.Log("randomSpawnPosition: " + randomSpawnPosition);
                instantiatedPositions.Add(randomSpawnPosition);
            }
        }

        instantiatedPositions.Clear();
    }

    // Helper function to get exact values for random spawns
    float GetRandomFromArray(float[] array)
    {
        int randomIndex = Random.Range(0, array.Length);
        return array[randomIndex];
    }

    // Check if the position has already been used
    bool PositionAlreadyUsed(Vector3 position)
    {
        return instantiatedPositions.Contains(position);
    }
}
