using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesmis
{
    [System.Serializable]
    public class Nodes
    {
        public string id;
        public int group;
        public Color color;
        public float x;
        public float y;
        public float z;    
    }

    [System.Serializable]
    public class Links
    {
        public int source;
        public int target;
        public int value;
    }
}


