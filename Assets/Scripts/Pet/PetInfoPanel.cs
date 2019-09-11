using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI PetName;
    public TextMeshProUGUI PetBreed;
    public TextMeshProUGUI PetAge;
    public TextMeshProUGUI PetColor;
    public TextMeshProUGUI PetSize;
    public Image PetPhoto;

    private Animator _animator;

    void Start() {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
