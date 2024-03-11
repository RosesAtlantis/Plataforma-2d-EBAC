using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptsforfutureprojects.Learning.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<T>(); // Instance = script

            else
                Destroy(gameObject);
        }
    }
}
