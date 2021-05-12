
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [SerializeField]
    private RawImage image;

    [SerializeField]
    private Transform camera;

    void Start()
    {

    }

    void Update()
    {
        image.uvRect = new Rect(camera.transform.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
