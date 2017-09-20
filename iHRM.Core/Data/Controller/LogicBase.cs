using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.Controller
{
    public enum LogicResultStatus { none, success, fail }
    public class LogicResult
    {
        public LogicResultStatus status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }

    public class LogicProgress
    {
        private int maxValue = 100;
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                if (OnSetMaxValue != null)
                    OnSetMaxValue();
            }
        }
        
        private int currentValue = 0;
        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                if (OnSetValue != null)
                    OnSetValue();
            }
        }

        public void SetTitle(string title) { if (OnSetTitle != null) OnSetTitle(title); }
        public void OutMessage(string message) { if (OnOutMessage != null) OnOutMessage(message); }

        public event Action OnSetMaxValue;
        public event Action OnSetValue;

        public event Action<string> OnSetTitle;
        public event Action<string> OnOutMessage;
    }

    public class LogicBase
    {
    }
}
