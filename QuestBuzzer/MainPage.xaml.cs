using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Gpio;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QuestBuzzer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitGPIO();
            Loaded += MainPage_Loaded;
            pressTime = DateTime.Now.Ticks;
        }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            statusByPin[5].ButtonEllipse = whiteEllipse;
            statusByPin[5].TeamDisplay = whiteTeam;
            statusByPin[5].ElapsedDisplay = whiteEllapsed;

            statusByPin[6].ButtonEllipse = redEllipse;
            statusByPin[6].TeamDisplay = redTeam;
            statusByPin[6].ElapsedDisplay = redEllapsed;

            statusByPin[13].ButtonEllipse = greenEllipse;
            statusByPin[13].TeamDisplay = greenTeam;
            statusByPin[13].ElapsedDisplay = greenEllapsed;

            statusByPin[19].ButtonEllipse = yellowEllipse;
            statusByPin[19].TeamDisplay = yellowTeam;
            statusByPin[19].ElapsedDisplay = yellowEllapsed;

            statusByPin[26].ButtonEllipse = blueEllipse;
            statusByPin[26].TeamDisplay = blueTeam;
            statusByPin[26].ElapsedDisplay = blueEllapsed;

            foreach (BuzzerStatus bs in statusByPin.Values)
            {
                buttonStatusGrid.Children.Remove(bs.ButtonEllipse);
            }
        }

        private void InitGPIO()
        {
            pins.Add(createButtonPin(5, "1", 21));
            pins.Add(createButtonPin(6, "2", 20));
            pins.Add(createButtonPin(13, "3", 9));
            pins.Add(createButtonPin(19, "4", 10));
            pins.Add(createButtonPin(26, "5", 11));
        }

        private GpioPin createButtonPin(int pinNumber, string teamNumber, int ledPinNumber)
        {
            var gpio = GpioController.GetDefault();
            GpioPin pin = gpio.OpenPin(pinNumber);
            pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            pin.DebounceTimeout = TimeSpan.FromMilliseconds(2);
            pin.ValueChanged += PinValueChanged;

            GpioPin ledPin = gpio.OpenPin(ledPinNumber);
            ledPin.SetDriveMode(GpioPinDriveMode.Output);
            ledPin.Write(GpioPinValue.Low);
            statusByPin[pinNumber] = new BuzzerStatus() { TeamNumber = teamNumber, LedPin = ledPin };
            return pin;
        }

        private void PinValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            // toggle the state of the LED every time the button is pressed
            if (!alreadyPressed.ContainsKey(sender.PinNumber) && e.Edge == GpioPinEdge.FallingEdge)
            {
                alreadyPressed[sender.PinNumber] = true;
                var thisTeamPosition = Interlocked.Increment(ref teamPosition);
                long now = DateTime.Now.Ticks;

                var buzzerStatus = statusByPin[sender.PinNumber];
                buzzerStatus.ColumnPosition = thisTeamPosition - 1;
                buzzerStatus.TimePressed = now;
                if (thisTeamPosition == 1)
                {
                    buzzerStatus.LedPin.Write(GpioPinValue.High);
                    currentLedPin = buzzerStatus.LedPin;
                }

                var task = Dispatcher.RunIdleAsync((v) => {
                    Ellipse el = buzzerStatus.ButtonEllipse;
                    buttonStatusGrid.Children.Add(el);
                    Grid.SetColumn(el, buzzerStatus.ColumnPosition);

                    buzzerStatus.TeamDisplay.Text = buzzerStatus.TeamNumber;
                    Grid.SetColumn(buzzerStatus.TeamDisplay, buzzerStatus.ColumnPosition);

                    long elapsed = (buzzerStatus.TimePressed - pressTime) / 10000;
                    double seconds = elapsed / 1000.0;
                    buzzerStatus.ElapsedDisplay.Text = seconds.ToString();
                    Grid.SetColumn(buzzerStatus.ElapsedDisplay, buzzerStatus.ColumnPosition);
                });
            }
        }


        private void nextTeamButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (currentLedPin != null)
            {
                int currentTeam = -1;
                foreach (BuzzerStatus bs in statusByPin.Values)
                {
                    if (bs.LedPin == currentLedPin)
                    {
                        currentTeam = bs.ColumnPosition;
                    }
                }
                int nextTeam = currentTeam + 1;
                GpioPin nextLedPin = null;
                foreach (BuzzerStatus bs in statusByPin.Values)
                {
                    if (bs.ColumnPosition == nextTeam)
                    {
                        nextLedPin = bs.LedPin;
                    }
                }
                if (nextLedPin != null)
                {
                    currentLedPin.Write(GpioPinValue.Low);
                    nextLedPin.Write(GpioPinValue.High);
                    currentLedPin = nextLedPin;
                }
            }
        }


        private void resetButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (currentLedPin != null)
            {
                currentLedPin.Write(GpioPinValue.Low);
                currentLedPin = null;
            }
            pressTime = DateTime.Now.Ticks;
            alreadyPressed.Clear();
            teamPosition = 0;
            foreach (BuzzerStatus bs in statusByPin.Values)
            {
                buttonStatusGrid.Children.Remove(bs.ButtonEllipse);
                bs.TeamDisplay.Text = "";
                bs.ElapsedDisplay.Text = "";
            }
        }


        private IDictionary<int, bool> alreadyPressed = new ConcurrentDictionary<int, bool>();
        private IDictionary<int, BuzzerStatus> statusByPin = new Dictionary<int, BuzzerStatus>();

        GpioPin currentLedPin;
        private List<GpioPin> pins = new List<GpioPin>();
        private long pressTime;
        private int teamPosition;

    }
}
