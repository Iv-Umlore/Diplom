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
   struct User
    {
        public string login;
        public string pass;
    }

    public partial class Client : Form
    {
        const string empty = "Экземпляры отсутствуют";
        const string DeletePoint = "Удалить точку";
        const string AddExhibit = "Повесить экспонат";
        const string ResetExhibit = "Снять экспонат";
        const int PointSize = 7;

        const string SetFloo = "Добавить этаж";
        const string ResetFloo = "Убрать этаж";

        bool isManager;
        bool isAdmin;
        bool isChange = false;
        int root;

        User client;

        ExhibitSpace currentSpace;
        Floor currentFloor = null;
        Bridge bridge;
        //Bitmap Default;
        Bitmap OriginalScheme;
        Bitmap Scheme;

        List<floore> floors;

        private void RefreshFloor()
        {
            if (currentFloor == null)
                currentFloor = bridge.DownloadFloor(1);
            else currentFloor = bridge.DownloadFloor(currentFloor.GetId());
            for (int i = 0; i < Scheme.Width; i++)
                for (int j = 0; j < Scheme.Height; j++)
                {
                    Scheme.SetPixel(i, j, Color.Pink);
                }
            OriginalScheme = Scheme;
            DrawScheme();
            Floor_Name.Text = currentFloor.FloorName;
            floors = Bridge.GiveValidFloor();
            SetAllUseableFloor();
        }

        private void SetAllUseableFloor()
        {
            GoodFloorList.Items.Clear();
            if (isManager) GoodFloorList.Items.Add(SetFloo);
            if ( floors == null) floors = Bridge.GiveValidFloor();
            for (int i = 0; i < floors.Count; i++)
                GoodFloorList.Items.Add(floors[i].name);
            if (isManager) GoodFloorList.Items.Add(ResetFloo);
            if (isManager) GoodFloorList.SelectedItem = GoodFloorList.Items[1];
            else GoodFloorList.SelectedItem = GoodFloorList.Items[0];
        }

        public Client()
        {            
            root = 0;
            bridge = new Bridge();
            isManager = false;
            isAdmin = false;
            InitializeComponent();
            Cansel.Hide();
            LB.Hide();
            ManagerPanel.Hide();
            AdministratorPanel.Hide();
            SetAllUseableFloor();
            Scheme = new Bitmap(Floore_Scheme.Width, Floore_Scheme.Height);
            RefreshFloor();    
        }

        private void Autorization_Click(object sender, EventArgs e)
        {
            AutorizationLogin AL = new AutorizationLogin();
            this.Hide();
            AL.ShowDialog();
            this.Show();
            root = AL.root;
            client = new User();
            client.login = AL._login;
            client.pass = AL._pass;
            UseRoot(root);
        }

        private void UseRoot(int root)
        {
            switch (root)
            {                
                case 0:
                    {
                        Autorization.Show();
                        AdministratorPanel.Hide();
                        ManagerPanel.Hide();
                        isManager = false;
                        isAdmin = false;
                        break;
                    }
                case 1:
                    {
                        Autorization.Hide();
                        AdministratorPanel.Hide();
                        ManagerPanel.Show();
                        isManager = true;
                        isAdmin = false;
                        break;
                    }
                case 2:
                    {
                        Autorization.Hide();
                        AdministratorPanel.Show();
                        ManagerPanel.Show();
                        isManager = true;
                        isAdmin = true;
                        break;
                    }
                default:
                    {
                        Autorization.Show();
                        AdministratorPanel.Hide();
                        ManagerPanel.Hide();
                        isManager = false;
                        isAdmin = false;
                        break;
                    }
            }
            RefreshFloor();
        }

        private void DeleteFloor_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            root = 0;
            UseRoot(0);
        }        

        private void Floore_Scheme_MouseMove(object sender, MouseEventArgs e)
        {
            ExhibitSpace ex = IsPoint(e);
            currentSpace = ex;
            if (ex != null)
                DrawPoint(ex, Color.Red);
            else
            {
                DrawScheme();
            }
            MousePosition.Text = "Текущая позиция : " + (e.X + e.Y);
        }

        private void DrawPoint(ExhibitSpace ES, Color pointColor)
        {
            for (int i = -PointSize; i <= PointSize; i++)
                for (int j = -PointSize; j <= PointSize; j++)
                    Scheme.SetPixel(ES.XCoord + i, ES.YCoord + j, pointColor);
            Floore_Scheme.Image = Scheme;
        }

        private void DrawScheme()
        {
            for (int currPos = 0; currPos < currentFloor.GetFloore().Count; currPos++)
                DrawPoint(currentFloor.GetFloore()[currPos], Color.Aquamarine);
        }

        private ExhibitSpace IsPoint(MouseEventArgs e)
        {
            ExhibitSpace ex;
            for (int i = 0; i < currentFloor.GetFloore().Count; i++)
            {
                ex = currentFloor.GetFloore()[i];
                if (e.X < ex.XCoord + PointSize && e.X > ex.XCoord - PointSize && e.Y < ex.YCoord + PointSize && e.Y > ex.YCoord - PointSize)
                    return ex;
            }
            return null;
        }
        
        private void Floore_Scheme_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isChange)
            {
                LB.Items.Clear();
                if (isManager) LB.Items.Add(DeletePoint);
                if (currentSpace != null)
                {
                    LB.SetBounds(currentSpace.XCoord, currentSpace.YCoord, 150, 65);
                    for (int pos = 0; pos < currentSpace.GetExhibits().Count; pos++)
                    {
                        LB.Items.Add(currentSpace.GetExhibits()[pos].exhibit_name);
                    }
                    if (isManager)
                    {
                        if (LB.Items.Count == 1) LB.Items.Add(empty);
                    }
                    else
                        if (LB.Items.Count == 0) LB.Items.Add(empty);

                    if (isManager)
                    {
                        LB.Items.Add(AddExhibit);
                        LB.Items.Add(ResetExhibit);
                    }

                    Scheme_Panel.Controls.Add(LB);
                    LB.Show();
                    LB.BringToFront();
                    System.Threading.Thread.Sleep(1000);
                }
                else LB.Hide();
            }
            else
            {
                bridge.AddNewExhibitSpace(e.X, e.Y, currentFloor.GetId());
                CanselFunction();
                RefreshFloor();
            }
        }

        private int GetSelectedItemID(string name)
        {
            for (int i=0; i < currentSpace.GetExhibits().Count; i++)
                if (currentSpace.GetExhibits()[i].exhibit_name == name) return currentSpace.GetExhibits()[i].exhibit_id;
            return -1;
        }

        private void LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (LB.SelectedItem.ToString())
            {
                case empty:
                    {
                        LB.Hide();
                        break;
                    }
                case DeletePoint:
                    {
                        bridge.DeleteExhibitSpase(currentSpace.GetId());
                        LB.Hide();
                        RefreshFloor();
                        break;
                    }
                case AddExhibit:
                    {
                        SetExhibit SE = new SetExhibit(currentSpace.GetId());
                        this.Hide();
                        SE.ShowDialog();
                        this.Show();
                        RefreshFloor();
                        break;
                    }
                case ResetExhibit:
                    {
                        ResetExhibit RE = new ResetExhibit(currentSpace);
                        this.Hide();
                        RE.ShowDialog();
                        this.Show();
                        RefreshFloor();
                        break;
                    }
                default:
                    {
                        int id = GetSelectedItemID(LB.SelectedItem.ToString());
                        if (id == -1) MessageBox.Show("Возникла ошибка!");
                        else
                        {
                            Exponat exhib = new Exponat(new Exhibit(id));
                            this.Hide();
                            exhib.ShowDialog();
                            this.Show();
                        }
                        break;
                    }
            }
             

        }

        private void CreateNewExhibit_Click(object sender, EventArgs e)
        {
            CreateExhibitWindows CE = new CreateExhibitWindows();
            this.Hide();
            CE.ShowDialog();
            this.Show();
        }

        private void AddExhibitSpase_Click(object sender, EventArgs e)
        {
            Floore_Scheme.Image = OriginalScheme;
            isChange = true;
            Floor_Name.Text = "Выберите позицию новой точки на схеме";
            AdministratorPanel.Hide();
            ManagerPanel.Hide();
            Cansel.Show();
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            CanselFunction();
        }

        private void CanselFunction()
        {
            UseRoot(root);
            isChange = false;
            Cansel.Hide();
            Floor_Name.Text = currentFloor.FloorName;
        }

        private void ChangePass_Click(object sender, EventArgs e)
        {
            ChangePass CP = new ChangePass(client.login,client.pass);
            this.Hide();
            CP.ShowDialog();
            this.Show();
        }

        private void CreateManager_Click(object sender, EventArgs e)
        {
            CreateUser CU = new CreateUser();
            this.Hide();
            CU.ShowDialog();
            this.Show();
        }

        private void DeleteManager_Click(object sender, EventArgs e)
        {
            DeleteManager DM = new DeleteManager();
            this.Hide();
            DM.ShowDialog();
            this.Show();
        }

        private void GoToNextFloor_Click(object sender, EventArgs e)
        {
            int selectedflooreID = currentFloor._NumberOfFloor;
            for (int i = 0; i < floors.Count; i++)
            {
                if (floors[i].name == GoodFloorList.SelectedItem.ToString())
                {
                    selectedflooreID = floors[i].id;
                    break;
                }
            }
            currentFloor = bridge.DownloadFloor(selectedflooreID);
            RefreshFloor();
        }

        private int GetNextNumberOfFloor()
        {
            for (int i = 0; i < floors.Count; i++)
            {
                if (floors[i].number_of_floor != i + 1) return i + 1;
            }
            return floors.Count + 1;
        }

        private void GoodFloorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (GoodFloorList.SelectedItem.ToString() == SetFloo) {
                AddFloor AF = new AddFloor(GetNextNumberOfFloor());
                this.Hide();
                AF.ShowDialog();
                this.Show();
                flag = true;
            };
            if (GoodFloorList.SelectedItem.ToString() == ResetFloo) {
                DeleteFloor DF = new DeleteFloor();
                this.Hide();
                DF.ShowDialog();
                this.Show();
                flag = true;
            };
            if (flag) RefreshFloor();
        }
    }
}
