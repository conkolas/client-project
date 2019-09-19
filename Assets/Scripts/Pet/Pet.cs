using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour {
    private int _id { get; set; }
    public int ID => _id;

    private string _name { get; set; }
    public string Name => _name;

    private string _color { get; set; }
    public string Color => _color;

    private string _size { get; set; }
    public string Size => _size;

    private string _age { get; set; }
    public string Age => _age;

    private string _breed { get; set; }
    public string Breed => _breed;

    private string _description { get; set; }
    public string Description => _description;

    private Texture2D _photo { get; set; }
    public Texture2D Photo => _photo;

    public SkinnedMeshRenderer MeshRenderer;

    [SerializeField] private Material DefaultMaterial;
    [SerializeField] private Color DefaultColor = UnityEngine.Color.gray;
    [SerializeField] private Vector3 DefaultScale = new Vector3(1f, 1f, 1f);

    private NavMeshAgent _agent;
    private StateController _controller;
    private PetSoundEmitter _soundEmitter;

    public void InitializePet(PetData petData, Texture2D petPhoto) {
        _id = petData.PetID;
        _name = petData.PetName;
        _color = petData.Color;
        _size = petData.Size;
        _breed = petData.PrimaryBreed;
        _age = petData.Age;
        _description = petData.Description;
        _photo = petPhoto;
        _agent = GetComponent<NavMeshAgent>();
        _controller = GetComponent<StateController>();
        _soundEmitter = GetComponent<PetSoundEmitter>();

        Material petMaterial = new Material(DefaultMaterial.shader) {color = GetPetColor()};
        Material[] mats = MeshRenderer.materials;
        mats[0] = petMaterial;
        MeshRenderer.materials = mats;
        transform.localScale = GetPetSize();
        _agent.speed = transform.localScale.x;
    }

    private Color GetPetColor() {
        Color petColor = DefaultColor;

        if (_color == null) return petColor;
        if (_color.Contains("Black")) {
            petColor = UnityEngine.Color.black;
        } else if (_color.Contains("White")) {
            petColor = new Color(210, 210, 210, 1);
        } else if (_color.Contains("Gray")) {
            petColor = UnityEngine.Color.gray;
        } else if (_color.Contains("Yellow") || _color.Contains("Gold")) {
            petColor = UnityEngine.Color.yellow;
        } else if (_color.Contains("Brown")) {
            petColor = new Color(205,133,63,1);
        }

        return petColor;
    }

    public void JumpAction() {
//        _controller.JumpAction();
        _soundEmitter.PlaySound();
    }

    public void SitAction() {
//        _controller.SitAction();
        _soundEmitter.PlaySound();
    }

    public void PetAction() {
        _controller.PetAction();
        _soundEmitter.PlaySound();
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
