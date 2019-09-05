using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Pet : MonoBehaviour {
    private string _name;
    public string Name => _name;

    private string _color;
    public string Color => _color;

    private string _size;
    public string Size => _size;

    [SerializeField] private Material DefaultMaterial;

    public void InitializePet(PetData petData) {
        _name = petData.PetName;
        _color = petData.Color;
        _size = petData.Size;

        Material petMaterial = new Material(DefaultMaterial.shader);
        GetComponent<MeshRenderer>().material = petMaterial;

        if (_color != null) {
            if (_color.Contains("Black")) {
                petMaterial.color = UnityEngine.Color.black;
            } else if (_color.Contains("White")) {
                petMaterial.color = UnityEngine.Color.white;
            } else if (_color.Contains("Gray")) {
                petMaterial.color = UnityEngine.Color.gray;
            } else if (_color.Contains("Yellow")) {
                petMaterial.color = UnityEngine.Color.yellow;
            } else if (_color.Contains("Brown")) {
                petMaterial.color = new Color(205,133,63,1);
            }
        }

        if (_size != null) {
            if (_size.Contains("Small")) {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            } else if (_size.Contains("Large")) {
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
        }
    }
}
