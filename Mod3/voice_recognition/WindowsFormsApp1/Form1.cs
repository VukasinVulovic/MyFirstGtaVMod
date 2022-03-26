using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new CultureInfo("sr-Latn-RS", false));
        public Form1()
        {

            InitializeComponent();
        }
        private void setOutput(object sender, SpeechRecognizedEventArgs e) => tb_output.Text = e.Result.Words[0].Text;

        private void Form1_Load(object sender, EventArgs e)
        {
            recognizer.SetInputToDefaultAudioDevice();
            //recognizer.LoadGrammar(new DictationGrammar());

            //GrammarBuilder builder = new GrammarBuilder(new Choices("dog", "cat", "snake"));

            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();

            recognizer.LoadGrammar(new Grammar(builder));
            recognizer.SpeechRecognized += setOutput;
        }

        private void recognizeVoice(object sender, EventArgs e)
        {
            Console.WriteLine("START");

            recognizer.RecognizeAsync();
        }
    }
}
