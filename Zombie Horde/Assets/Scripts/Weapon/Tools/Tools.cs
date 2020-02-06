public class Tools
{
    public ToolData tool;
    public int slot;
    public float toolDurability;

    public Tools(ToolData tool, int slot)
    {
        this.tool = tool;
        this.slot = slot;
        this.toolDurability = tool.weaponDurability;
    }
}