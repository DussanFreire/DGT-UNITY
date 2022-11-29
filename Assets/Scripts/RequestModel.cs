using System;
using System.Collections.Generic;

[Serializable]
public class RequestModel
{
	public int version;
	public float size;
	public string graphName;
	public Actions actions;
	public List<Filter> filters;
	public List<NodeRequestModel> nodes;
}