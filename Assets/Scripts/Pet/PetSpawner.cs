using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour {
    public Pet PetPrefab;
    public PetListFetcher PetListFetcher;
    public Transform PlayerTransform;

    public int SpawnCircleRadius = 10;

    public void Spawn() {
        int count = PetListFetcher.PetList.ReturnedExactMatches;
        float angle = 360f / count;
        for (int i = 0; i < count; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
            Vector3 direction = rotation * Vector3.forward;

            Vector3 position = PlayerTransform.position + (direction * SpawnCircleRadius);
            Pet petGo = Instantiate(PetPrefab, position, rotation, transform);
            petGo.InitializePet(PetListFetcher.PetList.Pets[i]);
        }
    }

    private void Start() {
        if (PetListFetcher != null) return;
        Debug.LogError("assign PetListFetcher to PetSpawner in the inspector before resuming");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
