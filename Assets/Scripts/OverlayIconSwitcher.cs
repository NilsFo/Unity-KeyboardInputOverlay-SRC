using UnityEngine;
using UnityEngine.UI;

public class OverlayIconSwitcher : MonoBehaviour
{
    public Sprite imageOff;
    public Sprite imageOn;

    private Image _myImage;
    private bool _stateOn;

    public bool State
    {
        get => _stateOn;
        set => _stateOn = value;
    }

    private void Awake()
    {
        _myImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(imageOff, "imageOff has not been set!", gameObject);
        Debug.Assert(imageOn, "imageOn has not been set!", gameObject);
        Debug.Assert(_myImage, "There is no UI Image component on the game object this one is attached to!",
            gameObject);
        State = false;
    }

    // Update is called once per frame
    void Update()
    {
        Sprite usedImg = imageOff;
        if (State)
        {
            usedImg = imageOn;
        }

        _myImage.sprite = usedImg;
    }
}