using UnityEngine;
using UnityEngine.UI;

public class PetInfoPanelCloseButton : MonoBehaviour
{
    public PetInfoPanel Panel;
    private Button _button;

    private void Start() {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Panel.ClosePanel();
    }
}
