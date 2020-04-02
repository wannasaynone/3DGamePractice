namespace ShooterGame
{
    public static class Debug
    {
        public enum Level
        {
            Normal,
            Warning,
            Error
        }

        public struct LogStruct
        {
            public string className;
            public string methodName;
            public string message;
            public Level level;
        }

        public static void Log(LogStruct log)
        {
            if(string.IsNullOrEmpty(log.className))
            {
                log.className = "NoClassNameInfo";
            }
            if(string.IsNullOrEmpty(log.methodName))
            {
                log.methodName = "NoMethodName";
            }
            string _message = string.Format("[{0}][{1}] {2}", log.className, log.methodName, log.message);

            switch(log.level)
            {
                case Level.Normal:
                    {
                        UnityEngine.Debug.Log(_message);
                        break;
                    }
                case Level.Warning:
                    {
                        UnityEngine.Debug.LogWarning(_message);
                        break;
                    }
                case Level.Error:
                    {
                        UnityEngine.Debug.LogError(_message);
                        break;
                    }
            }
        }
    }
}
