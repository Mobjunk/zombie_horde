public class Tools
{
    public ToolData tool;
    public float toolDurability;

    public Tools(ToolData tool)
    {
        this.tool = tool;
        this.toolDurability = tool.weaponDurability;
    }
}