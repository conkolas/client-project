using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetAvatar : MonoBehaviour {

    public TextMeshProUGUI NameLabel;
    public Image PhotoIcon;


    public void SetName(string name) {
        NameLabel.text = name;
    }

    public void SetPhoto(Texture2D texture) {
        PhotoIcon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}
