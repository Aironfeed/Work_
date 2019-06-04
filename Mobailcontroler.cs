using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Mobailcontroler : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public Image JosticBg;
    public Image Jostic;
    private Vector2 imputVector;

    void Start()
    {
        JosticBg = GetComponent<Image>();
        Jostic = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        imputVector = Vector2.zero;
        Jostic.rectTransform.anchoredPosition = Vector2.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JosticBg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / JosticBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JosticBg.rectTransform.sizeDelta.x);


            imputVector = new Vector2(pos.x * 2 - 0, pos.y * 2 - 0);
            imputVector = (imputVector.magnitude > 1.0f) ? imputVector.normalized : imputVector;

            Jostic.rectTransform.anchoredPosition = new Vector2(imputVector.x * (JosticBg.rectTransform.sizeDelta.x / 2), imputVector.y * (JosticBg.rectTransform.sizeDelta.y / 2));
        }
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Horizontal()
    {
        if (imputVector.x != 0) return imputVector.x;
        else return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (imputVector.y != 0) return imputVector.y;
        else return Input.GetAxis("Vertical");
    }
}
