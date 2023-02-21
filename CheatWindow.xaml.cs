using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace A2TszFungChan
{
    public partial class CheatWindow : Window
    {
        private FifaWorldCupDataSetTableAdapters.TeamsTableAdapter adpTeams;
        private FifaWorldCupDataSet.TeamsDataTable tblTeams;

        public CheatWindow()
        {
            InitializeComponent();

            adpTeams = new FifaWorldCupDataSetTableAdapters.TeamsTableAdapter();
            tblTeams = adpTeams.GetTeams();

            List<string> teams = new List<string>();

            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeams)
            {
                teams.Add(team.TeamName);
            }

            CBTeams.ItemsSource = teams;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int cheatTeam = CBTeams.SelectedIndex;
            adpTeams.UpdateCheatTeam(cheatTeam + 1);
            MessageBox.Show(tblTeams.FindByTeamId(cheatTeam + 1).TeamName + " is  the Cheating Team! ");

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
