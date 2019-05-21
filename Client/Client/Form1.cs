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
            Client client = new Client();
            
            InitializeComponent();
            client.Activate();
        }        

        private void ShowFloor_Click(object sender, EventArgs e)
        {
            bridge.DownloadFloor(1);
            
            // ChangeCurrentFloor
            Console.Write("Завершено.\n");
        }

        private void ShowExponat_Click(object sender, EventArgs e)
        {
            // Вне сервера
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
            string name = "Экспонат 1";
            string description = "Это тестовый экспонат, чтобы протестировать работоспособность приложения";
            bridge.AddExhibit(name, description);
            Console.Write("Завершено.\n");
        }

        private void DeleteExponat_Click(object sender, EventArgs e)
        {
            bridge.DeleteExhibitNumber(1);
            Console.Write("Завершено.\n");
        }

        private void ChangeExponat_Click(object sender, EventArgs e)
        {
            // Нужно взять id старого экспоната и по нему изменить его
            Exhibit exb = new Exhibit(1);
            string descr = "Новое описание для экспоната";
            exb.ChangeName("new name");
            exb.ChangeDescription(descr);
            bridge.ChangeExhibit(exb);
            Console.Write("Завершено.\n");
        }

        private void SetExponat_Click(object sender, EventArgs e)
        {
            bridge.SetExhibit(1, 1);
            Console.Write("Завершено.\n");
        }

        private void ResetExponat_Click(object sender, EventArgs e)
        {
            /* Снять экспонат
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
            /* Создание нового экспоната и отправка его на сервер
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void DeleteExponatPoint_Click(object sender, EventArgs e)
        {
            /* Удалить конкретный существующий экспонат
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void AddFloor_Click(object sender, EventArgs e)
        {
            /* Создать новую схему этажа
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }

        private void DeleteFloor_Click(object sender, EventArgs e)
        {
            /* удалить существующий этаж из бд
             * Здесь будет реализация
             * 
            */
            Console.Write("Завершено.\n");
        }
        // Добавление и удаление этажей из списка доступных
        /* private void AddFloorToSheme_Click(object sender, EventArgs e)
         {
             /* Добавить схему этажа
              * Здесь будет реализация
              * 
             *//*
             Console.Write("Завершено.\n");
         }*/

        /* private void AddFloorToSheme_Click(object sender, EventArgs e)
        {
            /* Добавить схему этажа
             * Здесь будет реализация
             * 
            *//*
            Console.Write("Завершено.\n");
        }*/

    }
}
