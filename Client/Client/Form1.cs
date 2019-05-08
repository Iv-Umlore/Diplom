using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private Bridge bridge;
        private int Root;
        public Form1()
        {
            bridge = new Bridge();
            InitializeComponent();
        }        

        private void ShowFloor_Click(object sender, EventArgs e)
        {
            bridge.DownloadFloor(1);
            // ChangeCurrentFloor
            Console.Write("Завершено.\n");
        }

        private void ShowExponat_Click(object sender, EventArgs e)
        {
            Exhibit CurrentExhib = bridge.GetExhibitAt(1);
            // ShowThisExponat
            Console.Write("Завершено.\n");
        }

        private void Autorization_Click(object sender, EventArgs e)
        {
            int root = bridge.Autorization("admin", "admin");
            Console.Write("Завершено.\n");
        }

        private void AddExponat_Click(object sender, EventArgs e)
        {
            List<string> links = new List<string>();
            string link = "https:\\link_one.php";
            links.Add(link);
            link = "https:\\link_two.php";
            links.Add(link);
            string name = "Экспонат 1";
            string description = "Это тестовый экспонат, чтобы протестировать работоспособность приложения";
            bridge.AddExhibit(name, description, links, 10, 10);
            Console.Write("Завершено.\n");
        }

        private void DeleteExponat_Click(object sender, EventArgs e)
        {
            bridge.DeleteExhibitNumber(1);
            Console.Write("Завершено.\n");
        }

        private void ChangeExponat_Click(object sender, EventArgs e)
        {
            Exhibit exb = new Exhibit();
            string descr = "Новое описание для экспоната";
            bridge.ChangeDescription(exb, descr);
            Console.Write("Завершено.\n");
        }

        private void SetExponat_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void ResetExponat_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void ChangeFloor_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            // Обновить схему
            Console.Write("Завершено.\n");
        }

        private void AddExponatPoint_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void DeleteExponatPoint_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void AddFloor_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void DeleteFloor_Click(object sender, EventArgs e)
        {
            /*
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }
    }
}
