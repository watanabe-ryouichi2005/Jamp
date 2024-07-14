
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField] Image arrowImage;
    Vector3 clickPosition;

    void Start()
    {
        // ��������
        arrowImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �h���b�O�J�n�ʒu�i�X�N���[����Ԃ̍��W�j��ۑ�����
            clickPosition = Input.mousePosition;
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            // ����\������
            arrowImage.gameObject.SetActive(true);
        }   // �}�E�X���{�^��(0)���v���X�i�����j���ꂽ���Ƃ����o����
        else if (Input.GetMouseButton(0))
        {
            // �����ړ�����
            arrowImage.rectTransform.position = clickPosition;
            // �h���b�O�Ƌt�����̃x�N�g�����v�Z����
            Vector2 dragVector = clickPosition - Input.mousePosition;
            // �����x�N�g���̕����Ɍ�����
            arrowImage.rectTransform.right = dragVector;
            // �h���b�O�̃x�N�g���̋��������߂�
            float size = dragVector.magnitude;
            // �摜�̃T�C�Y��ς���
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ��������
            arrowImage.gameObject.SetActive(false);
        }
    }
}
