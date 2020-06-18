using System;
using Xamarin.Forms;
using Xamarin.Forms.Core;
using System.Windows.Input;

namespace JuceTest
{
    public class TestToneViewModel : BaseViewModel
    {
        public ICommand OnSilderChangedCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand BackCommand { get; set; }

        private const int knobPositions = 51;
        private const float minFrequency = 0f;
        private const float frequencyStep = 40;
        private const float maxFrequency = minFrequency + (frequencyStep * knobPositions);

        private float frequency = 440f;
        public float Frequency
        {
            get => (float)frequency;
            set => SetValue(ref frequency, value);
        }

        private bool isSwitchedOn;
        public bool IsSwitchedOn
        {
            get => (bool)isSwitchedOn;
            set => SetValue(ref isSwitchedOn, value);
        }

        private int sliderValue;
        public int SliderValue
        {
            get => (int)sliderValue;
            set => SetValue(ref sliderValue, value);
        }

        public TestToneViewModel()
        {
            OnSilderChangedCommand = new Command(() => { OnSliderValueChanged(); });
            StartCommand = new Command(() => { StartTone(); });
            StopCommand = new Command(() => { StopTone(); });
            UpdateFrequency(frequency);
        }

        private int lastFreqSliderValue = -1;

        void UpdateFrequency(float f, bool dontChangeSlider = false)
        {
            int newFreqSliderValue = (int)(f / frequencyStep);
            if (newFreqSliderValue != lastFreqSliderValue && newFreqSliderValue >= 0)
            {
                lastFreqSliderValue = newFreqSliderValue;

                if (isSwitchedOn)
                {
                    Api.StartTestTone(f, 0.8f);
                }

                if (!dontChangeSlider)
                {
                    sliderValue = newFreqSliderValue;
                }

                frequency = f;
            }
        }

        void StartTone()
        {
            isSwitchedOn = true;
            Api.StartTestTone(frequency, 0.8f);      
        }

        void StopTone()
        {
            isSwitchedOn = false;
            Api.StopTestTone();
        }

        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void OnSliderValueChanged()
        {
            float newFreq = minFrequency + ((int)sliderValue * frequencyStep);
            UpdateFrequency(newFreq, true);
            Console.WriteLine(frequency);
        }

    }
}
