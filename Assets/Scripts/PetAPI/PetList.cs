using System.Collections.Generic;
using UnityEngine;

public class PetList : ScriptableObject {
    public int TotalPets;
    public int ReturnedExactMatches;
    [SerializeField]
    public List<Pet> Pets;
}
