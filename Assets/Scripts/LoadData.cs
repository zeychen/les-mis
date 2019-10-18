using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Lesmis
{
    public class LoadData : MonoBehaviour
    {
        [SerializeField] private string jsonFile = "lesmis-3d.json";
        [SerializeField] private GameObject characterNode;
        [SerializeField] private Transform characterLink; 
        //This pragma disables the warning in this one case.
#pragma warning disable 0649
        private GameObject linkingNode;
        private Nodes[] characters;
        private Links[] links;
        //private float linkWidth = 0.5f;
        //Camera m_MainCamera;
        // Start is called before the first frame update
        void Start()
        {
            LoadJsonData(jsonFile);
            PlotData();
        }

        void LateUpdate()
        {

        }
        private void PlotData()
        {
            foreach (Nodes charaNode in this.characters)
            {
                // generate a sphere using the x, y, and z coordinate
                var newNode = Instantiate(characterNode, new Vector3(charaNode.x, charaNode.y, charaNode.z), Quaternion.identity);
                newNode.name = charaNode.id;
                newNode.transform.SetParent(this.gameObject.transform);
                newNode.AddComponent<MouseOverController>();
                newNode.AddComponent<LabelNodes>();
                Color nodeColor = new Color();
                ColorUtility.TryParseHtmlString(charaNode.color, out nodeColor);
                newNode.GetComponent<MeshRenderer>().material.SetColor("_Color", nodeColor);
                
            }

            foreach (Links linkNode in this.links)
            {
                
                // calculate link end points
                var startNode = linkNode.source;
                var endNode = linkNode.target;
                Vector3 startNodePos = new Vector3(this.characters[startNode].x, this.characters[startNode].y, this.characters[startNode].z);
                Vector3 endNodePos = new Vector3(this.characters[endNode].x, this.characters[endNode].y, this.characters[endNode].z);
                Vector3 offset = endNodePos - startNodePos;
                var position = startNodePos + (offset / 2.0f);

                // generate a cylinder that connects the nodes
                var cylinder = Instantiate<GameObject>(characterLink.gameObject, position, Quaternion.identity);

                cylinder.transform.position = position;
                cylinder.transform.LookAt(startNodePos);
                Vector3 localScale = cylinder.transform.localScale;

                localScale.z = (endNodePos - startNodePos).magnitude;
                cylinder.transform.localScale = localScale;
                cylinder.transform.SetParent(this.gameObject.transform);
                cylinder.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
            }
        }

        private void LoadJsonData(string jsonFile)
        {
            string fPath = Path.Combine(Application.dataPath, jsonFile);

            if (File.Exists(fPath))
            {
                // read JSON file
                string JSONData = File.ReadAllText(fPath);

                // create array of nodes objects
                this.characters = Helpers.JsonHelper.getNodesArray<Nodes>(JSONData);

                // create array of links objects
                this.links = Helpers.JsonHelper.getLinksArray<Links>(JSONData);
                
            }
            else
            {
                Debug.Log("File does not exist");
            }
        }
    }

}
