using System;
using System.Collections.Generic;

[Serializable]
public class RequestDto
{
	public int version;
	public float size;
	public string graphName;
	public ActionsDto actions;
	public List<FilterDto> filters;
	public List<NodeRequestDto> nodes;
}