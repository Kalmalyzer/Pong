using UnityEngine;

public class PaddleInput
{
    private readonly string axisName;

    public PaddleInput(string axisName)
    {
        this.axisName = axisName;
    }

    public float ReadInput()
    {
        return Input.GetAxis(axisName);
    }
}
