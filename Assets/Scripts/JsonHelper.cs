using System;
using System.IO;
using UnityEngine;

namespace Helpers
{
    public static class JsonHelper
    {
        public static T[] getNodesArray<T>(string json)
        {
            //Debug.Log(json);
            //string newJson = "{ \"nodes\": " + json + "}";
            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);

            return wrapper.nodes;
        }
        public static T[] getLinksArray<T>(string json)
        {
            //Debug.Log(json);
            //string newJson = "{ \"nodes\": " + json + "}";
            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);

            return wrapper.links;
        }
        public static string nodesToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.nodes = array;
            return UnityEngine.JsonUtility.ToJson(wrapper);
        }
        public static string linksToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.links = array;
            return UnityEngine.JsonUtility.ToJson(wrapper);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] nodes;
            public T[] links;
        }
    }
}
