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


        }

        private void MenuRender_Click(object sender, RoutedEventArgs e)
        {
            if(m_renderTask!= null && !m_renderTask.IsFinish)
            {
                MessageBox.Show("Render Not Finish");
                return;
            }
            m_renderTask = new RenderTask(256, 256, RenderImage);


            m_renderTask.Start();
        }


        private void StartRender()
        {

        }

    }
}
