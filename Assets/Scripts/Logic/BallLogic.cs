public class BallLogic
{
    private readonly BallSimulation ballSimulation;

    public BallLogic(BallSimulation ballSimulation)
    {
        this.ballSimulation = ballSimulation;
    }

    public bool Hit(string tag)
    {
        if (tag == "HorizontalWall")
        {
            ballSimulation.ReflectVelocityVertically();
            return true;
        }
        if (tag == "VerticalWall")
        {
            return false;
        }
        if (tag == "Paddle")
        {
            ballSimulation.ReflectVelocityHorizontally();
            return true;
        }

        throw new System.NotImplementedException();
    }
}
