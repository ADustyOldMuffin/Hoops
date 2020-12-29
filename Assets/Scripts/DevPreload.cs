using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTemplateProjects
{
    public class DevPreload : MonoBehaviour
    {
        private void Awake()
        {
            var go = GameObject.Find("__app");

            if (go == null)
            {
                SceneManager.LoadScene("_preload");
            }
        }
    }
}