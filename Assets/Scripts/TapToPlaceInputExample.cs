using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;

public class TapToPlaceInputExample : MonoBehaviour
{


	public GameObject graphPrefab;
    private  GameObject logoGraphGameObj;
    private GameObject graph;
    private TapToPlace tapToPlace;
    void Start()
    {
        graph = FindInActiveObjectByName("HandleGraph");
        logoGraphGameObj = Instantiate(graphPrefab, new Vector3(0, -0.5f, 0), Quaternion.identity);
        logoGraphGameObj.transform.localScale = Vector3.one * 0.02f;
        logoGraphGameObj.transform.position = Vector3.forward * 0.1f;
        tapToPlace = logoGraphGameObj.AddComponent<TapToPlace>();
        tapToPlace.StartPlacement();
        tapToPlace.DefaultPlacementDistance =0.7f;
        tapToPlace.OnPlacingStopped.AddListener( SetColorsListener);
    }
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
    
    public void SetColorsListener( )
    {
        NodesManager.GraphPos = logoGraphGameObj.transform.position;
        logoGraphGameObj.transform.GetChild(1).transform.GetComponent<TextMesh>().text = "Loading Graph ...";
        graph.SetActive(true);
    
    }

    void Update()
    {
        logoGraphGameObj.transform.GetChild(0).Rotate(0, 0, 0.4f, Space.Self);
    }
}