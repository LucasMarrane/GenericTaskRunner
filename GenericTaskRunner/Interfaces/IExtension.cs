namespace GenericTaskRunner.Interfaces
{
    /// <summary>
    /// <c>IExtension</c>: interface thats allow puglins to run
    /// </summary>
    public interface IExtension
    {
        /// <summary>
        /// <c>HelpCommands</c>: array of commands to use to extend the core program
        /// </summary>        
        string[] HelpCommands { get; }     
        /// <summary>
        /// <c>Run</c>: main method thats run all logic;
        /// </summary>
        /// <param name="args"></param>
        void Run(string[] args);

    }
}
