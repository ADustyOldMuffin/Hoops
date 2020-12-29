using System;
using Managers;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class HoopInteraction : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("ball"))
                LevelManager.AddScore(other.gameObject.GetComponent<BallInteraction>().GetScore());
        }
    }
}