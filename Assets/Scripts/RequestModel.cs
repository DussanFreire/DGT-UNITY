using System;
using System.Collections.Generic;

[Serializable]
public class RequestModel
{
	public int version;
	public string graphName;
	public List<Filter> filters;
    public EdgeColorModel edgeColors;
	public NodeColorModel nodeColors;
	public List<NodeRequestModel> nodes;
}