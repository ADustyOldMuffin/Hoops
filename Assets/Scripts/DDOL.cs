using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class DDOL : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}