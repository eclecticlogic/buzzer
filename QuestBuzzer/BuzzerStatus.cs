using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;

namespace QuestBuzzer
{
    class BuzzerStatus
    {
        private int columnPosition;
        private long timePressed;
        private Ellipse buttonEllipse;
        private TextBlock teamName;
        private TextBlock elapsedName;
        private string teamNumber;

        public int ColumnPosition
        {
            get { return columnPosition; }
            set { columnPosition = value; }
        }

        public long TimePressed
        {
            get { return timePressed; }
            set { timePressed = value; }
        }


        public Ellipse ButtonEllipse
        {
            get { return buttonEllipse; }
            set { buttonEllipse = value; }
        }

        public string TeamNumber
        {
            get { return teamNumber; }
            set { teamNumber = value; }
        }

        public TextBlock TeamDisplay
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public TextBlock ElapsedDisplay
        {
            get { return elapsedName; }
            set { elapsedName = value; }
        }
    }
}
