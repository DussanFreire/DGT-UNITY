using System.Collections.Generic;
using System;

[Serializable]
public class NodeRequestDto
{
	public int id;
	public string name;
	public string color;
	public string background;
	public List<string> filters;
    public List<LinkDto> links;
	public List<int> childIds;
	public bool visible;
	public float x;
	public float y;
	public float z;
}