namespace ExtensionsAndStuff.HelperClasses.WorkflowHelpers
{
    public sealed class NextStep
    {
        private NextStep() {}
        
        public static NextStep Instance { get; } = new NextStep();
    }
}