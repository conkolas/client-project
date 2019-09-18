using UnityEngine;

public class PetSpawner : MonoBehaviour {
    public Pet PetPrefab;
    public PetList PetList;
    public PetDataList PetDataList;
    public GameEvent OnSpawn;
    public Transform PlayerTransform;

    public int SpawnCircleRadius = 10;

    public void Spawn() {
        int count = PetDataList.ReturnedExactMatches;
        float angle = 360f / count;
        PetList.Pets = new Pet[count];

        for (int i = 0; i < count; i++)
        {
            Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
            Vector3 direction = rotation * Vector3.forward;
            Vector3 position = PlayerTransform.position + direction * SpawnCircleRadius;

            Pet petGo = Instantiate(PetPrefab, position, rotation, transform);
            petGo.InitializePet(PetDataList.Pets[i], PetDataList.PhotoTextures[i]);

            PetList.Pets[i] = petGo;
        }

        OnSpawn.Raise();
    }
}
