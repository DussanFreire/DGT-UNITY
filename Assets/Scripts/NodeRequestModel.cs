using System.Collections.Generic;
using System;

[Serializable]
public class NodeRequestModel
{
	public int id;
	public string name;
	public string color;
	public List<string> filters;
    public List<Link> links;
	public List<int> childIds;
	public float x;
	public float y;
	public float z;
}