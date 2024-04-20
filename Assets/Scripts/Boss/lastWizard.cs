using System;
using UnityEngine;

namespace DefaultNamespace.Boss
{
    public class lastWizard : MonoBehaviour
    {
        public GameObject wizaard;
        public GameObject dialog;
        private void Awake()
        {
            wizaard.SetActive(false);
            dialog.GetComponent<GameObject>();
            dialog.SetActive(false);
        }

        public void animations()
        {
            wizaard.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                dialog.SetActive(true);
            }
        }
    }
}