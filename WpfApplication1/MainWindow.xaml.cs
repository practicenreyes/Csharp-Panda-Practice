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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        State Zoos = new State();
        Zoo selectedZoo = new Zoo();
    
        public MainWindow() 
        {
            InitializeComponent();
            
            Zoo ValenciaZoo = new Zoo("Valencia Statal Zoo");
            ValenciaZoo.NewPanda(new Panda("Osito") { likesDogs = false, likesHumans = true });
            ValenciaZoo.NewPanda(new Panda("Fatty") { likesDogs = true, likesHumans = false });
            ValenciaZoo.NewPanda(new Panda("Snow") { likesDogs = false, likesHumans = true });
            ValenciaZoo.NewPanda(new Panda("Fancy") { likesDogs = true, likesHumans = false });
            ValenciaZoo.NewPanda(new Panda("Meaty") { likesDogs = false, likesHumans = true });
            ValenciaZoo.NewPanda(new Panda("Blondy") { likesDogs = true, likesHumans = false });
            Panda panda = ValenciaZoo.SearchPanda("Osito");
            panda.PandaMate(ValenciaZoo.SearchPanda("Fancy"));

            Zoo GuacaraZoo = new Zoo("Guacara Statal Zoo");
            GuacaraZoo.NewPanda(new Panda("Osazo") { likesDogs = true, likesHumans = true });
            GuacaraZoo.NewPanda(new Panda("Punky") { likesDogs = true, likesHumans = false });
            GuacaraZoo.NewPanda(new Panda("Sunny") { likesDogs = false, likesHumans = true });
            GuacaraZoo.NewPanda(new Panda("Funky") { likesDogs = true, likesHumans = false });
            GuacaraZoo.NewPanda(new Panda("Meann") { likesDogs = true, likesHumans = true });
            GuacaraZoo.NewPanda(new Panda("Iris") { likesDogs = false, likesHumans = false });
            GuacaraZoo.NewPanda(new Panda("Louis") { likesDogs = true, likesHumans = true });
            GuacaraZoo.NewPanda(new Panda("Freddie") { likesDogs = false, likesHumans = true });
            panda = GuacaraZoo.SearchPanda("Iris");
            panda.PandaMate(GuacaraZoo.SearchPanda("Punky"));
            panda = GuacaraZoo.SearchPanda("Sunny");
            panda.PandaMate(GuacaraZoo.SearchPanda("Louis"));

            Zoos.AddZoo(ValenciaZoo);
            Zoos.AddZoo(GuacaraZoo);


        }

        private void main_load(object sender, RoutedEventArgs e)
        {

            loadZoos();

        }

        public void loadZoos()
        {
            List<string> names = Zoos.ZooNames();

            foreach (string name in names)
            {
                cbx_zoos.Items.Add(name);                
            }
        }

        public void LoadPandas(string zooName)
        {
            lst_pandas.Items.Clear();

            selectedZoo = Zoos.SearchZoo(zooName);

            List<string> pandaNames = selectedZoo.PandaNames();

            foreach (string name in pandaNames)
            {
                lst_pandas.Items.Add(name);
            }
        }

        public void LoadZooSpecs()
        {
            ZooStats SelectedStats = selectedZoo.Stats();

            txt_quantity.Text = SelectedStats.PandaQuantity.ToString();
            txt_married.Text = SelectedStats.MarryedPandas.ToString();
            txt_singles.Text = SelectedStats.SinglePandas.ToString();
            txt_likeshumans.Text = SelectedStats.likesHuman.ToString();
            txt_pandalikedogs.Text = SelectedStats.likesDogs.ToString();

        }

        public void LoadSpecs(string pandaName)
        {
            Panda selectedPanda = selectedZoo.SearchPanda(pandaName);

            txt_pandaname.Text = selectedPanda.pName;
            txt_ismarried.Text = selectedPanda.hasMate.ToString();
            txt_pandalikesh.Text = selectedPanda.likesHumans.ToString();

            if (selectedPanda.hasMate == true)
            {
                txt_matename.Text = selectedPanda.pMate.pName;
            }
            else
            {
                txt_matename.Text = "None";
            }
        }

        private void lst_panda_selection(object sender, SelectionChangedEventArgs e)
        {
            if (lst_pandas.SelectedItem != null)
            {
                string name = lst_pandas.SelectedItem.ToString();
                LoadSpecs(name);
            }
        }

        private void cbx_zoosChangeSelection(object sender, SelectionChangedEventArgs e)
        {
            string zoo = cbx_zoos.SelectedItem.ToString();
            LoadPandas(zoo);
            LoadZooSpecs();
        }               
    }
}
