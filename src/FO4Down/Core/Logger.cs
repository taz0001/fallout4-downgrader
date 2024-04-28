﻿namespace FO4Down.Core
{
    public interface ILogger
    {
        void Info(string message, params object[] args);
        void Debug(string message, params object[] args);
        void Warning(string message, params object[] args);
        void Error(string message, params object[] args);

    }

    public class ConsoleLogger : ILogger
    {
        public void Debug(string message, params object[] args)
        {
            WriteColoredLine((ConsoleColor.Cyan, "[DBG] " + message), args);
        }

        public void Error(string message, params object[] args)
        {
            WriteColoredLine((ConsoleColor.Red, "[ERR] " + message));
        }

        public void Info(string message, params object[] args)
        {
            WriteColoredLine((ConsoleColor.White, "[INFO] " + message));
        }

        public void Warning(string message, params object[] args)
        {
            WriteColoredLine((ConsoleColor.Yellow, "[WRN] " + message));
        }

        private void WriteColored((ConsoleColor, string) input, params object[] args)
        {
            Console.ForegroundColor = input.Item1;
            var str = input.Item2;
            for (var i = 0; i < args.Length; ++i)
            {
                str = str.Replace("{" + i + "}", args[i].ToString());
            }
            Console.Write(str);
        }

        private void WriteColoredLine((ConsoleColor, string) input, params object[] args)
        {
            WriteColored(input, args);
            Console.WriteLine();
        }

        private void WriteColoredLine((ConsoleColor, string)[] values, params object[] args)
        {
            foreach (var v in values)
            {
                WriteColored(v, args);
            }

            Console.WriteLine();
        }
    }
}
