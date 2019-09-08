using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pet/Pet list")]
public class PetList : ScriptableObject {
    [SerializeField]
    public List<Pet> Pets;
}
