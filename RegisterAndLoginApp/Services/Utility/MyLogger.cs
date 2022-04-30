using NLog;

namespace RegisterAndLoginApp.Services.Utility
{
    public class MyLogger : Ilogger
    {
        // singleton design pattern used here. A singleton is a class that can have only one instance
        private static MyLogger instance;
        private static Logger logger;

        // if the instance is null, then let's generate a new one and we will return that.
        // if it is NOT null, then some other place in the program has already asked for an instance so we will not create a new one.
        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        public Logger GetLogger()
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger("RegisterLoginAppRule");
            return MyLogger.logger;

        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
