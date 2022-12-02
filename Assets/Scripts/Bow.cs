using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bow : MonoBehaviour
    {
        [Header("Assets")] public GameObject m_ArrowPrefab;

        private Arrow m_currentArrow;

        private float m_pullValue;

        [Header("Camera")]
        [SerializeField] Camera m_playerCamera;

        private float m_fov;

        private void Start()
        {
            StartCoroutine(CreateArrow(0.0f));
            m_pullValue = 0.0f;
            m_fov = m_playerCamera.fieldOfView;
        }

        private void Update()
        {
            if(!m_currentArrow) return;

            m_playerCamera.fieldOfView += m_pullValue;
        }

        private IEnumerator CreateArrow(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            //Instantiate the new arrow
            GameObject arrowObject = Instantiate(m_ArrowPrefab, transform);

            arrowObject.transform.localPosition = new Vector3(0.2f, 0, 0);
            arrowObject.transform.localEulerAngles = Vector3.zero;

            arrowObject.transform.localPosition = new Vector3(0, 1, .5f);

            m_currentArrow = arrowObject.GetComponent<Arrow>();
        }

        public void Pull()
        {
            //Increase camera FOV when pulling
            if (m_currentArrow)
            {
                m_pullValue += 0.1f;
            }
        }

        public void Release()
        {
           
            //Set FOV back to normal
            if (m_pullValue > 0.25f)
            {
                FireArrow();
                m_playerCamera.fieldOfView = m_fov;
            }

            m_pullValue = 0.0f;

            if (!m_currentArrow)
            {
                StartCoroutine(CreateArrow(2f));
            }
        }

        public void FireArrow()
        {
            m_currentArrow.Fire(m_pullValue);
            m_currentArrow = null;
        }
    }
}