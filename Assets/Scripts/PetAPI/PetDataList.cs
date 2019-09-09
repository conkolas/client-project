using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pet/Pet data list")]
public class PetDataList : ScriptableObject {
    public int TotalPets;
    public int ReturnedExactMatches;
    [SerializeField]
    public PetData[] Pets;
    [SerializeField]
    public Texture2D[] PhotoTextures;
}
