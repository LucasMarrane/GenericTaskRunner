namespace GenericTaskRunner.Interfaces
{
    /// <summary>
    /// <c>IExtension</c>: interface thats allow puglins to run
    /// </summary>
    public interface IExtension
    {
        string AppName { get; }
        /// <summary>
        /// <c>HelpCommands</c>: array of commands to use to extend the core program
        /// </summary>        
        List<HelpCommand> HelpCommands { get; }     
        /// <summary>
        /// <c>Run</c>: main method thats run all logic;
        /// </summary>
        /// <param name="args"></param>
        dynamic Run(string[] args);

    }

    public class HelpCommand
    {
        public string Shortcut { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
