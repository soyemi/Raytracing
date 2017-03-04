using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using System.Threading;
using Color = System.Drawing.Color;
using System.Drawing;
using System.Drawing.Imaging;

using RayTracing;
using RayTracing.Utility;
using Microsoft.Win32;

namespace RayTracerWPF
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private RenderTask m_renderTask;



        public MainWindow()
        {
            InitializeComponent();

            menuRender.Click += MenuRender_Click;
            menuSave.Click += MenuSave_Click;

            Left = (SystemParameters.PrimaryScreenWidth - Width)*0.5f;
            Top = (SystemParameters.PrimaryScreenHeight - Height) * 0.5f;
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG(*.png)|*.png";
            if(saveDialog.ShowDialog() == true)
            {
                string fileName = saveDialog.FileName;
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(m_renderTask.Bitmap));
                using (var stream = File.Create(saveDialog.FileName))
                {
                    encoder.Save(stream);
                }
            }
        }

        private RenderConfig RefreshConfig()
        {
            RenderConfig config = new RenderConfig();
            config.width = int.Parse(cfgWidth.Text);
            config.height = int.Parse(cfgHeight.Text);
            config.samples = int.Parse(cfgSamples.Text);
            return config;
        }

        private void MenuRender_Click(object sender, RoutedEventArgs e)
        {
            if(m_renderTask!= null && !m_renderTask.IsFinish)
            {
                MessageBox.Show("Render Not Finish");
                return;
            }

            var config = RefreshConfig();

            m_renderTask = new RenderTask(config, RenderImage);

            m_renderTask.RenderFinish += OnRenderFinish;
            m_renderTask.Start();
        }


        private void OnRenderFinish(string info)
        {
            m_renderTask.RenderFinish -= OnRenderFinish;

            Dispatcher.Invoke(() => { RenderInfoText.Text = info; });
        }


    }
}
