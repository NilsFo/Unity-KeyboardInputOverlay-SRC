using UnityEngine;

public class IconSwitchControllerBase : MonoBehaviour
{
    [SerializeField] private OverlayIconSwitcher iconSwitcher;

    [SerializeField] private KeyCode keyCode;

    void Start()
    {
        Debug.Assert(iconSwitcher, "No 'icon switcher' assigned to this Controller!", gameObject);
        Debug.Assert(keyCode != KeyCode.None, "The value of 'icon switcher' assigned to this Controller is 'None'!",
            gameObject);
    }

    void Update()
    {
        bool isPressed = Input.GetKey(keyCode);
        iconSwitcher.State = isPressed;
    }
}