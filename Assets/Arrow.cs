using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pullingJump :MonoBehaviour
{
    Rigidbody rb;
}


public class Arrow : MonoBehaviour
{
    [SerializeField]Image arrowImage; 
    private Vector3 clickPostion;
    // Start is called before the first frame update
    void Start()
    {
        arrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            clickPostion = Input.mousePosition;
            arrowImage.gameObject.SetActive(true);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPostion = Input.mousePosition;
            
            arrowImage.rectTransform.right = dragVector;
            float size = dragVector.magnitude;
           
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false);

        }
    }
}
