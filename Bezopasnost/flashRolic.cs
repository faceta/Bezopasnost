using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxShockwaveFlashObjects;

namespace Bezopasnost
{
    public partial class flashRolic : Form
    {
        public flashRolic()
        {
            InitializeComponent();
        }
        public AxShockwaveFlash fl;
        private void flashRolic_Load(object sender, EventArgs e)
        {
            //Инициализируем новый компонент AxShockwaveFlash
            fl = new AxShockwaveFlash();
            //задаем координаты левого верхнего угла элемента управления
            //относительно левого верхнего угла контейнера. 
            fl.Location = new Point(10, 50);
            //задаем высоту и ширину элемента управления.
            fl.Size = new System.Drawing.Size(500, 200);
            //задаем имя элемента управления.
            fl.Name = "axShockwaveFlash1";
            //Задаем границы контейнера, с которыми связан элемент управления,
            //и определяем способ изменения размеров элемента управления при изменении
            //размеров его родительского элемента.    
            fl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //Добавляем указанный элемент управления в коллекцию элементов
            //управления.      
            this.Controls.Add(fl);
            //Выполняем инициализацию нового экземпляра 
            //класса System.IO.DirectoryInfo для заданного пути.
            System.IO.DirectoryInfo di =
                  new System.IO.DirectoryInfo(Application.StartupPath);
            //Выполняем поиск всех фалов с расширением *.swf
            //в каталоге исполняемого файла.
            foreach (System.IO.FileInfo file in di.GetFiles("*.swf"))
            {
                //Добавляем имена найденных файлов
                //в элемент управления comboBox1
                comboBox1.Items.Add(file.Name);
            }

            //Выбираем первый найденный файл
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fl.Movie = Application.StartupPath
              + "\\" + comboBox1.SelectedItem.ToString();
            fl.Forward();
            fl.Play();
        }
    }
}
