using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoLotModel;
using System.Data;
using System.Data.Entity;


namespace Hotel_Catei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        AutoLotEntitiesModel ctx = new AutoLotEntitiesModel();
        CollectionViewSource stapaniVSource;
        CollectionViewSource cainiVSource;
        CollectionViewSource angajatiVSource;
        CollectionViewSource stapaniRezervarisVSource;
       // CollectionViewSource angajatiSarcinisVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stapaniVSource =((System.Windows.Data.CollectionViewSource)(this.FindResource("stapaniViewSource")));
            stapaniVSource.Source = ctx.Stapanis.Local;
            ctx.Stapanis.Load();

            cainiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cainiViewSource")));
            cainiVSource.Source = ctx.Cainis.Local;
            ctx.Cainis.Load();

            angajatiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiViewSource")));
            angajatiVSource.Source = ctx.Angajatis.Local;
            ctx.Angajatis.Load();

            stapaniRezervarisVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stapaniRezervarisViewSource")));
           
           

            //stapaniRezervarisVSource.Source = ctx.Rezervaris.Local;
            // angajatiSarcinisVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiRezervarisViewSource")));

            ctx.Rezervaris.Load();
            ctx.Stapanis.Load();
            ctx.Cainis.Load();
           // ctx.Sarcinis.Load();
//
            cmbStapani.ItemsSource = ctx.Stapanis.Local;
           // cmbStapani.DisplayMemberPath = "Nume";
            cmbStapani.SelectedValuePath = "id_stapan";

            cmbCaini.ItemsSource = ctx.Cainis.Local;
           // cmbCaini.DisplayMemberPath = "nume_caine";
            cmbCaini.SelectedValuePath = "Id_caine";

            cmbAngajati.ItemsSource = ctx.Angajatis.Local;
            // cmbCaini.DisplayMemberPath = "nume_caine";
            cmbAngajati.SelectedValuePath = "Id";


            BindDataGrid();
            //BindDataGridSarcini();



            System.Windows.Data.CollectionViewSource stapaniViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("stapaniViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // stapaniViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource cainiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cainiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // cainiViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource angajatiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // angajatiViewSource.Source = [generic data source]
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;

        }

        private void SaveStapani()
        {
            Stapani stapan = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    stapan = new Stapani()
                    {
                        Nume_stapan = nume_stapanTextBox.Text.Trim(),
                        Prenume_stapan = prenume_stapanTextBox.Text.Trim(),
                        mail_stapan = mail_stapanTextBox.Text.Trim(),
                        nrtel_stapan = nrtel_stapanTextBox.CaretIndex,    // Aici de intrebat la ora???
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Stapanis.Add(stapan);
                    stapaniVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    stapan = (Stapani)stapaniDataGrid.SelectedItem;
                    stapan.Nume_stapan = nume_stapanTextBox.Text.Trim();
                    stapan.Prenume_stapan = prenume_stapanTextBox.Text.Trim();
                    stapan.mail_stapan = mail_stapanTextBox.Text.Trim();
                    stapan.nrtel_stapan = nrtel_stapanTextBox.CaretIndex ;        //???????????????


                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    stapan = (Stapani)stapaniDataGrid.SelectedItem;
                    ctx.Stapanis.Remove(stapan);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                stapaniVSource.View.Refresh();
            }

        }
        private void SaveCaini()
        {
            Caini caine = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    caine = new Caini()
                    {
                        nume_caine = nume_caineTextBox.Text.Trim(),
                        rasa_caine = rasa_caineTextBox.Text.Trim(),
                       
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Cainis.Add(caine);
                    cainiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    caine = (Caini)cainiDataGrid.SelectedItem;
                    caine.nume_caine = nume_caineTextBox.Text.Trim();
                    caine.rasa_caine = rasa_caineTextBox.Text.Trim();
                          


                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    caine = (Caini)cainiDataGrid.SelectedItem;
                    ctx.Cainis.Remove(caine);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cainiVSource.View.Refresh();
            }

        }
        private void SaveAngajati()
        {
            Angajati angajat = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    angajat = new Angajati()
                    {
                        nume_angajat = nume_angajatTextBox.Text.Trim(),
                        prenume_angajat = prenume_angajatTextBox.Text.Trim(),

                    };
                    //adaugam entitatea nou creata in context
                    ctx.Angajatis.Add(angajat);
                    angajatiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    angajat = (Angajati)angajatiDataGrid.SelectedItem;
                    angajat.nume_angajat = nume_angajatTextBox.Text.Trim();
                    angajat.prenume_angajat = prenume_angajatTextBox.Text.Trim();



                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    angajat = (Angajati)angajatiDataGrid.SelectedItem;
                    ctx.Angajatis.Remove(angajat);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                angajatiVSource.View.Refresh();
            }

        }
        private void SaveRezervari()
        {
            Rezervari rezervare = null;
            if (action == ActionState.New)
            {
                try
                {
                    Stapani stapan = (Stapani)cmbStapani.SelectedItem;
                    Caini caini = (Caini)cmbCaini.SelectedItem;
                    //instantiem Order entity
                    rezervare = new Rezervari()
                    {

                        id_stapan = stapan.id_stapan,
                        id_caine = caini.Id_caine,
                        data_start = rezervare.data_start,
                        data_final = rezervare.data_final
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Rezervaris.Add(rezervare);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                dynamic selectedRezervare = rezervarisDataGrid.SelectedItem;
                try
                {
                    int rrez_id = selectedRezervare.id_rezervare;
                    var editedRezervare = ctx.Rezervaris.FirstOrDefault(s => s.Id_rezervare == rrez_id);
                    if (editedRezervare != null)
                    {
                        editedRezervare.id_stapan = Int32.Parse(cmbStapani.SelectedValue.ToString());
                        editedRezervare.id_caine = Convert.ToInt32(cmbCaini.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                stapaniRezervarisVSource.View.MoveCurrentTo(selectedRezervare);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedRezervare = rezervarisDataGrid.SelectedItem;
                    int rrez_id = selectedRezervare.id_rezervare;
                    var deletedRezervare = ctx.Rezervaris.FirstOrDefault(s => s.Id_rezervare == rrez_id);
                    if (deletedRezervare != null)
                    {
                        ctx.Rezervaris.Remove(deletedRezervare);
                        ctx.SaveChanges();
                        MessageBox.Show("Rezervare stearsa cu Succes !!", "Mesaj");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

            private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            angajatiVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            angajatiVSource.View.MoveCurrentToNext();
        }

        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }
        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlHotelCatei.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Stapani":
                    SaveStapani();
                    break;
                case "Caini":
                    SaveCaini();
                    break;
                case "Angajati":
                    SaveAngajati();
                    break;
                case "Rezervari":
                    SaveRezervari();

                    break;
                case "":
                    break;
            }
            ReInitialize();
        }

        private void BindDataGrid()
        {
            var queryRezervari = from rez in ctx.Rezervaris
                             join stap in ctx.Stapanis on rez.id_stapan equals stap.id_stapan
                             join cni in ctx.Cainis on rez.id_caine equals cni.Id_caine
                             select new
                             {
                                 rez.Id_rezervare,
                                 rez.id_caine,
                                 rez.id_stapan,
                                 stap.Nume_stapan,
                                 stap.Prenume_stapan,
                                 cni.nume_caine,
                                 cni.rasa_caine
                             };
            stapaniRezervarisVSource.Source = queryRezervari.ToList();
        }
       /* private void BindDataGridSarcini()
        {
            var querySarcini = from sarc in ctx.Sarcinis
                                 join angj in ctx.Angajatis on sarc.Id_angajat equals angj.Id
                              
                                 select new
                                 {
                                     sarc.Id_sarcina,
                                     sarc.Id_angajat,
                                    
                                     angj.nume_angajat,
                                     angj.prenume_angajat,
                                     
                                 };
            angajatiSarcinisVSource.Source = querySarcini.ToList();
        }
       */



    }
}
