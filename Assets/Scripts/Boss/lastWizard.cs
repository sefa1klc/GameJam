using System;
using UnityEngine;

namespace DefaultNamespace.Boss
{
    public class lastWizard : MonoBehaviour
    {
        public GameObject wizaard;

        private void Awake()
        {
            wizaard.SetActive(false);
        }

        public void animations()
        {
            wizaard.SetActive(true);
        }
    }
}