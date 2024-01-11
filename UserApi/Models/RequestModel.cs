public class RequestModel
{
    public PanelMember PanelMemberNew { get; set;}
    public Caretaker? Caretaker { get; set; }
}

public class RequestModelPut : RequestModel
{
    public PanelMember PanelMemberCurrent { get; set;}
}