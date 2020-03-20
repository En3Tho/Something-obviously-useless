namespace ExtensionsAndStuff.HelperClasses.WorkflowHelpers
{
    public class NextStep
    {
        private NextStep() {}
        
        public static NextStep Instance { get; } = new NextStep();
    }
}