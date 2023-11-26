using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_trigger_script : MonoBehaviour
{
    public GameObject roadSection;
    public GameObject objes;

    // Keep track of instantiated positions
    private List<Vector3> instantiatedPositions = new List<Vector3>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("section_trigger_collider"))
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
