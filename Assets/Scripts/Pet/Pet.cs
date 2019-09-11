using TMPro;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Pet : MonoBehaviour {
    private int _id { get; set; }
    public int ID => _id;

    private string _name { get; set; }
    public string Name => _name;

    private string _color { get; set; }
    public string Color => _color;

    private string _size { get; set; }
    public string Size => _size;

    private Texture2D _photo { get; set; }
    public Texture2D Photo => _photo;


    [SerializeField] private Material DefaultMaterial;
    [SerializeField] private Color DefaultColor = UnityEngine.Color.gray;
    [SerializeField] private Vector3 DefaultScale = new Vector3(1f, 1f, 1f);

    public void InitializePet(PetData petData, Texture2D petPhoto) {
        _id = petData.PetID;
        _name = petData.PetName;
        _color = petData.Color;
        _size = petData.Size;
        _photo = petPhoto;

        Material petMaterial = new Material(DefaultMaterial.shader) {color = GetPetColor()};
        GetComponent<MeshRenderer>().material = petMaterial;
        transform.localScale = GetPetSize();
    }

    private Color GetPetColor() {
        Color petColor = DefaultColor;

        if (_color == null) return petColor;
        if (_color.Contains("Black")) {
            petColor = UnityEngine.Color.black;
        } else if (_color.Contains("White")) {
            petColor = UnityEngine.Color.white;
        } else if (_color.Contains("Gray")) {
            petColor = UnityEngine.Color.gray;
        } else if (_color.Contains("Yellow") || _color.Contains("Gold")) {
            petColor = UnityEngine.Color.yellow;
        } else if (_color.Contains("Brown")) {
            petColor = new Color(205,133,63,1);
        }

        return petColor;
    }

    private Vector3 GetPetSize() {
        Vector3 petSize = DefaultScale;

        if (_size == null) return petSize;
        if (_size.Contains("Small")) {
            petSize = new Vector3(0.5f, 0.5f, 0.5f);
        } else if (_size.Contains("Large")) {
            petSize = new Vector3(1.5f, 1.5f, 1.5f);
        }

        return petSize;
    }
}
