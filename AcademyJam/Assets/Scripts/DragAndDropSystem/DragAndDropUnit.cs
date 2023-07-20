using System;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DragAndDropSystem
{
    public class DragAndDropUnit : MonoBehaviour
    {
        public bool IsDropped { set; get; } = false;

        public int ID { private set; get;} 

        private void Awake()
        {
            ID = Random.Range(0, 1000);
        }
    }
}