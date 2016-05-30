using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class virtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image bgImage, joystickImage;
    private Vector3 inputVec;

    private void Start()
    {
        bgImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            position.x = (position.x / bgImage.rectTransform.sizeDelta.x);
            position.y = (position.y / bgImage.rectTransform.sizeDelta.y);

            inputVec = new Vector3(position.x*2 + 1, 0, position.y*2 - 1);
            inputVec = (inputVec.magnitude > 1.0f) ? inputVec.normalized : inputVec;

            joystickImage.rectTransform.anchoredPosition = new Vector3(inputVec.x * (bgImage.rectTransform.sizeDelta.x/2),
               inputVec.z * (bgImage.rectTransform.sizeDelta.y / 2));
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVec = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVec.x != 0)
            return inputVec.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVec.z != 0)
            return inputVec.z;
        else
            return Input.GetAxis("Vertical");
    }
}
