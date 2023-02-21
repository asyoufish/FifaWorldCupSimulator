using A2TszFungChan.FifaWorldCupDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
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

namespace A2TszFungChan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // table adapter
        private FifaWorldCupDataSetTableAdapters.TeamsTableAdapter adpTeams;
        private FifaWorldCupDataSetTableAdapters.MatchesTableAdapter adpMatches;

        // data table
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsA;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsB;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsC;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsD;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsE;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsF;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsG;
        private FifaWorldCupDataSet.TeamsDataTable tblTeamsH;

        private FifaWorldCupDataSet.TeamsDataTable tblTeams;
        private FifaWorldCupDataSet.MatchesDataTable tblMatches;

        // Randomized Groups
        List<int> groupAId = new List<int>();
        List<int> groupBId = new List<int>();
        List<int> groupCId = new List<int>();
        List<int> groupDId = new List<int>();
        List<int> groupEId = new List<int>();
        List<int> groupFId = new List<int>();
        List<int> groupGId = new List<int>();
        List<int> groupHId = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            adpTeams = new FifaWorldCupDataSetTableAdapters.TeamsTableAdapter();
            adpMatches = new FifaWorldCupDataSetTableAdapters.MatchesTableAdapter();

            // Reset
            adpTeams.ResetTeams();
            adpMatches.ResetMatches();

            tblTeamsA = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsB = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsC = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsD = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsE = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsF = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsG = new FifaWorldCupDataSet.TeamsDataTable();
            tblTeamsH = new FifaWorldCupDataSet.TeamsDataTable();

            tblMatches = adpMatches.GetMatches();
            tblTeams = adpTeams.GetTeams();

            GetAllTeams();
        }

        private void GetAllTeams()
        {
            // Clear Entry
            lstA.Items.Clear();
            lstB.Items.Clear();
            lstC.Items.Clear();
            lstD.Items.Clear();
            lstE.Items.Clear();
            lstF.Items.Clear();
            lstG.Items.Clear();
            lstH.Items.Clear();

            tblTeamsA = adpTeams.GetTeamsByGroup("A");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsA)
                lstA.Items.Add(team.TeamName);

            tblTeamsB = adpTeams.GetTeamsByGroup("B");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsB)
                lstB.Items.Add(team.TeamName);

            tblTeamsC = adpTeams.GetTeamsByGroup("C");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsC)
                lstC.Items.Add(team.TeamName);

            tblTeamsD = adpTeams.GetTeamsByGroup("D");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsD)
                lstD.Items.Add(team.TeamName);

            tblTeamsE = adpTeams.GetTeamsByGroup("E");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsE)
                lstE.Items.Add(team.TeamName);

            tblTeamsF = adpTeams.GetTeamsByGroup("F");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsF)
                lstF.Items.Add(team.TeamName);

            tblTeamsG = adpTeams.GetTeamsByGroup("G");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsG)
                lstG.Items.Add(team.TeamName);

            tblTeamsH = adpTeams.GetTeamsByGroup("H");
            foreach (FifaWorldCupDataSet.TeamsRow team in tblTeamsH)
                lstH.Items.Add(team.TeamName);
        }

        private void btnDraw16_Click(object sender, RoutedEventArgs e)
        {
            GetAllTeams();

            // Initilize all the list of groups
            RandomTeam(tblTeamsA, groupAId);
            RandomTeam(tblTeamsB, groupBId);
            RandomTeam(tblTeamsC, groupCId);
            RandomTeam(tblTeamsD, groupDId);
            RandomTeam(tblTeamsE, groupEId);
            RandomTeam(tblTeamsF, groupFId);
            RandomTeam(tblTeamsG, groupGId);
            RandomTeam(tblTeamsH, groupHId);

            tbMatch1A.Text = tblTeams.FindByTeamId(groupAId[0]).TeamName;     tbMatch1B.Text = tblTeams.FindByTeamId(groupBId[1]).TeamName;
            tbMatch2C.Text = tblTeams.FindByTeamId(groupCId[0]).TeamName;     tbMatch2D.Text = tblTeams.FindByTeamId(groupDId[1]).TeamName;
            tbMatch3B.Text = tblTeams.FindByTeamId(groupBId[0]).TeamName;     tbMatch3A.Text = tblTeams.FindByTeamId(groupAId[1]).TeamName;
            tbMatch4D.Text = tblTeams.FindByTeamId(groupDId[0]).TeamName;     tbMatch4C.Text = tblTeams.FindByTeamId(groupCId[1]).TeamName;
            tbMatch5E.Text = tblTeams.FindByTeamId(groupEId[0]).TeamName;     tbMatch5F.Text = tblTeams.FindByTeamId(groupFId[1]).TeamName;
            tbMatch6G.Text = tblTeams.FindByTeamId(groupGId[0]).TeamName;     tbMatch6H.Text = tblTeams.FindByTeamId(groupHId[1]).TeamName;
            tbMatch7F.Text = tblTeams.FindByTeamId(groupFId[0]).TeamName;     tbMatch7E.Text = tblTeams.FindByTeamId(groupEId[1]).TeamName;
            tbMatch8H.Text = tblTeams.FindByTeamId(groupHId[0]).TeamName;     tbMatch8G.Text = tblTeams.FindByTeamId(groupGId[1]).TeamName;
            btnDraw16.IsEnabled = false;
            btnPlayRound16.IsEnabled = true;
        }

        
        private void RandomTeam(FifaWorldCupDataSet.TeamsDataTable teams, List<int> group)
        {
            // Hard Coded Probability:
            // 1st in the list: 40%, 2nd: 30%, 3rd: 20%, 4th: 10%
            // First two teams have higher probability to be selected
            foreach (FifaWorldCupDataSet.TeamsRow team in teams)
            {
                if (team.CheatTeam == true)
                {
                    group.Add(team.TeamId);
                    break;
                }
            }

            while(group.Count != 4)
            {
                Random rand = new Random();
                int randF = rand.Next(0, 10) + 1;
                int teamIndex;
                if (randF <= 4)
                    teamIndex = 0;
                else if (randF <= 7)
                    teamIndex = 1;
                else if (randF <= 9)
                    teamIndex = 2;
                else teamIndex = 3;
                if (!group.Contains(teams[teamIndex].TeamId))
                    group.Add(teams[teamIndex].TeamId);
            }
        }

        private void btnPlayRound16_Click(object sender, RoutedEventArgs e)
        {
            tblTeams = adpTeams.GetTeams();
            int[] match1TeamId = { groupAId[0], groupBId[1] };
            int[] match2TeamId = { groupCId[0], groupDId[1] };
            int[] match3TeamId = { groupBId[0], groupAId[1] };
            int[] match4TeamId = { groupDId[0], groupCId[1] };
            int[] match5TeamId = { groupEId[0], groupFId[1] };
            int[] match6TeamId = { groupGId[0], groupHId[1] };
            int[] match7TeamId = { groupFId[0], groupEId[1] };
            int[] match8TeamId = { groupHId[0], groupGId[1] };

            int[] match1 = playMatch(match1TeamId[0], match1TeamId[1]);
            int[] match2 = playMatch(match2TeamId[0], match2TeamId[1]);
            int[] match3 = playMatch(match3TeamId[0], match3TeamId[1]);
            int[] match4 = playMatch(match4TeamId[0], match4TeamId[1]);
            int[] match5 = playMatch(match5TeamId[0], match5TeamId[1]);
            int[] match6 = playMatch(match6TeamId[0], match6TeamId[1]);
            int[] match7 = playMatch(match6TeamId[0], match6TeamId[1]);
            int[] match8 = playMatch(match6TeamId[0], match6TeamId[1]);

            showResult(tbResult1A, tbResult1B, match1);
            showResult(tbResult2C, tbResult2D, match2);
            showResult(tbResult3B, tbResult3A, match3);
            showResult(tbResult4D, tbResult4C, match4);
            showResult(tbResult5E, tbResult5F, match5);
            showResult(tbResult6G, tbResult6H, match6);
            showResult(tbResult7F, tbResult7E, match7);
            showResult(tbResult8H, tbResult8G, match8);

            // Add results to the Matches database
            string stage = "Round of 16";
            adpMatches.AddMatch(1, stage, match1TeamId[0], match1TeamId[1], match1[0], match1[1], winningTeam(match1TeamId[0], match1TeamId[1], match1, stage));
            adpMatches.AddMatch(2, stage, match2TeamId[0], match2TeamId[1], match2[0], match2[1], winningTeam(match2TeamId[0], match2TeamId[1], match2, stage));
            adpMatches.AddMatch(3, stage, match3TeamId[0], match3TeamId[1], match3[0], match3[1], winningTeam(match3TeamId[0], match3TeamId[1], match3, stage));
            adpMatches.AddMatch(4, stage, match4TeamId[0], match4TeamId[1], match4[0], match4[1], winningTeam(match4TeamId[0], match4TeamId[1], match4, stage));
            adpMatches.AddMatch(5, stage, match5TeamId[0], match5TeamId[1], match5[0], match5[1], winningTeam(match5TeamId[0], match5TeamId[1], match5, stage));
            adpMatches.AddMatch(6, stage, match6TeamId[0], match6TeamId[1], match6[0], match6[1], winningTeam(match6TeamId[0], match6TeamId[1], match6, stage));
            adpMatches.AddMatch(7, stage, match7TeamId[0], match7TeamId[1], match7[0], match7[1], winningTeam(match7TeamId[0], match7TeamId[1], match7, stage));
            adpMatches.AddMatch(8, stage, match8TeamId[0], match8TeamId[1], match8[0], match8[1], winningTeam(match8TeamId[0], match8TeamId[1], match8, stage));

            btnDrawQF.IsEnabled = true;
            btnPlayRound16.IsEnabled = false;
        }

        private int winningTeam(int teamAId, int teamBId, int[] matchResult, string stage)
        {
            int winningTeam = compareScore(teamAId, teamBId, matchResult); ;
            if (stage.Equals("Round of 16"))
            {
                adpTeams.Update16TeamWinner(winningTeam);
            }
            else if (stage.Equals("Quarter-Final"))
            {
                adpTeams.UpdateQFTeamWinner(winningTeam);
            }
            else if (stage.Equals("Semi-Final"))
            {
                adpTeams.UpdateSFTeamWinner(winningTeam);
            }
            else if (stage.Equals("Final"))
            {
                adpTeams.UpdateFTeamWinner(winningTeam);
            }
            return winningTeam;
        }

        private int compareScore(int teamAId, int teamBId, int[] matchResult)
        {
            if (matchResult[0] > matchResult[1])
                return teamAId;
            else
                return teamBId;
        }

        private void showResult(TextBox textBoxA, TextBox textBoxB, int[] match)
        {
            textBoxA.Text = match[0].ToString();
            textBoxB.Text = match[1].ToString();
            if (match[0] > match[1])
            {
                textBoxA.Background = Brushes.LightGreen;
                textBoxB.Background = Brushes.LightCoral;
            }
            else
            {
                textBoxA.Background = Brushes.LightCoral;
                textBoxB.Background = Brushes.LightGreen;
            }
        }

        private int[] playMatch(int teamAID, int teamBID)
        {
            double winningFacA = tblTeams.FindByTeamId(teamAID).WinningFactor;
            double winningFacB = tblTeams.FindByTeamId(teamBID).WinningFactor;
            int scoreA = 0;
            int scoreB = 0;

            /*The probability here is that winning factor contribute to chance to score
            * Assuming there are 7 chances for both teams to shoot a goal. (Leaving chances that there will be 0-7 result)
            * 
            * Higher winning factor have a higher chance to score,
            * there are chances that the shoot will be missed
            * Therefore, extra chances will be added, which is 20 to lower the chance shooting will be scored everytime
            * 
            * The formular is that:
            * Total Chance = Chance of Team A (Winning Factor * 10) + Chance of Team B (Winning Factor * 10) + 20 (Chance to miss)
            * 
            * i.e.:
            * Team A winning factor = 0.7; Team B winning factor = 0.7;
            * Total Chance = 7 + 7 + 25 = 39
            * If random number is equal or between 1-7, Team A score.
            * If random number is equal or between 8-14, Team B score.
            * If random number is equal or between 15-39, no one score.
            * 
            */

            // Case 1: Team A is cheat team
            if (tblTeams.FindByTeamId(teamAID).CheatTeam == true)
            {
                MessageBox.Show(tblTeams.FindByTeamId(teamAID).TeamName + " will always win!!");
                do
                {
                    scoreA = scoreB = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        Random rand = new Random();

                        int totalChance = (int)((winningFacA + winningFacB) * 10) + 20;

                        int randF = rand.Next(0, totalChance) + 1;

                        if (randF <= winningFacA * 10)
                            scoreA++;
                        else if (randF <= (winningFacA + winningFacB) * 10)
                            scoreB++;
                    }
                } while (scoreA == scoreB || scoreA < scoreB);
            }
            // Case 2: Team B is Cheat Team
            else if (tblTeams.FindByTeamId(teamBID).CheatTeam == true)
            {
                MessageBox.Show(tblTeams.FindByTeamId(teamBID).TeamName + " will always win!!");
                do
                {
                    scoreA = scoreB = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        Random rand = new Random();

                        int totalChance = (int)((winningFacA + winningFacB) * 10) + 20;

                        int randF = rand.Next(0, totalChance) + 1;

                        if (randF <= winningFacA * 10)
                            scoreA++;
                        else if (randF <= (winningFacA + winningFacB) * 10)
                            scoreB++;
                    }
                } while (scoreA == scoreB || scoreA > scoreB);
            }
            // Case 3: No Cheat Team
            else
            {
                do
                {
                    scoreA = scoreB = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        Random rand = new Random();

                        int totalChance = (int)((winningFacA + winningFacB) * 10) + 20;

                        int randF = rand.Next(0, totalChance) + 1;

                        if (randF <= winningFacA * 10)
                            scoreA++;
                        else if (randF <= (winningFacA + winningFacB) * 10)
                            scoreB++;
                    }
                } while (scoreA == scoreB);
            }

            int[] result = new int[] { scoreA, scoreB };

            return result;
        }

        private void btnDrawQF_Click(object sender, RoutedEventArgs e)
        {
            tblMatches = adpMatches.GetMatches();

            tbMatch9A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(1).WinningTeamId).TeamName;
            tbMatch9B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(2).WinningTeamId).TeamName;
            tbMatch10A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(3).WinningTeamId).TeamName;
            tbMatch10B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(4).WinningTeamId).TeamName;
            tbMatch11A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(5).WinningTeamId).TeamName;
            tbMatch11B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(6).WinningTeamId).TeamName;
            tbMatch12A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(7).WinningTeamId).TeamName;
            tbMatch12B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(8).WinningTeamId).TeamName;

            btnDrawQF.IsEnabled = false;
            btnPlayQF.IsEnabled = true;
        }

        private void btnPlayQF_Click(object sender, RoutedEventArgs e)
        {
            int[] match9TeamId = { tblMatches.FindByMatchId(1).WinningTeamId, tblMatches.FindByMatchId(2).WinningTeamId };
            int[] match10TeamId = { tblMatches.FindByMatchId(3).WinningTeamId, tblMatches.FindByMatchId(4).WinningTeamId };
            int[] match11TeamId = { tblMatches.FindByMatchId(5).WinningTeamId, tblMatches.FindByMatchId(6).WinningTeamId };
            int[] match12TeamId = { tblMatches.FindByMatchId(7).WinningTeamId, tblMatches.FindByMatchId(8).WinningTeamId };

            int[] match9 = playMatch(match9TeamId[0], match9TeamId[1]);
            int[] match10 = playMatch(match10TeamId[0], match10TeamId[1]);
            int[] match11 = playMatch(match11TeamId[0], match11TeamId[1]);
            int[] match12 = playMatch(match12TeamId[0], match12TeamId[1]);

            showResult(tbResult9A, tbResult9B, match9);
            showResult(tbResult10A, tbResult10B, match10);
            showResult(tbResult11A, tbResult11B, match11);
            showResult(tbResult12A, tbResult12B, match12);

            string stage = "Quarter-Final";
            adpMatches.AddMatch(9, stage, match9TeamId[0], match9TeamId[1], match9[0], match9[1], winningTeam(match9TeamId[0], match9TeamId[1], match9, stage));
            adpMatches.AddMatch(10, stage, match10TeamId[0], match10TeamId[1], match10[0], match10[1], winningTeam(match10TeamId[0], match10TeamId[1], match10, stage));
            adpMatches.AddMatch(11, stage, match11TeamId[0], match11TeamId[1], match11[0], match11[1], winningTeam(match11TeamId[0], match11TeamId[1], match11, stage));
            adpMatches.AddMatch(12, stage, match12TeamId[0], match12TeamId[1], match12[0], match12[1], winningTeam(match12TeamId[0], match12TeamId[1], match12, stage));

            btnPlayQF.IsEnabled = false;
            btnDrawSF.IsEnabled = true;
        }

        private void btnDrawSF_Click(object sender, RoutedEventArgs e)
        {
            tblMatches = adpMatches.GetMatches();

            tbMatch13A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(9).WinningTeamId).TeamName;
            tbMatch13B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(10).WinningTeamId).TeamName;
            tbMatch14A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(11).WinningTeamId).TeamName;
            tbMatch14B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(12).WinningTeamId).TeamName;

            btnDrawSF.IsEnabled = false;
            btnPlaySF.IsEnabled = true;
        }

        private void btnPlaySF_Click(object sender, RoutedEventArgs e)
        {
            int[] match13TeamId = { tblMatches.FindByMatchId(9).WinningTeamId, tblMatches.FindByMatchId(10).WinningTeamId };
            int[] match14TeamId = { tblMatches.FindByMatchId(11).WinningTeamId, tblMatches.FindByMatchId(12).WinningTeamId };

            int[] match13 = playMatch(match13TeamId[0], match13TeamId[1]);
            int[] match14 = playMatch(match14TeamId[0], match14TeamId[1]);

            showResult(tbResult13A, tbResult13B, match13);
            showResult(tbResult14A, tbResult14B, match14);

            string stage = "Semi-Final";
            adpMatches.AddMatch(9, stage, match13TeamId[0], match13TeamId[1], match13[0], match13[1], winningTeam(match13TeamId[0], match13TeamId[1], match13, stage));
            adpMatches.AddMatch(10, stage, match14TeamId[0], match14TeamId[1], match14[0], match14[1], winningTeam(match14TeamId[0], match14TeamId[1], match14, stage));

            btnPlaySF.IsEnabled = false;
            btnDrawF.IsEnabled = true;
        }

        private void btnDrawF_Click(object sender, RoutedEventArgs e)
        {
            tblMatches = adpMatches.GetMatches();

            tbMatch15A.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(13).WinningTeamId).TeamName;
            tbMatch15B.Text = tblTeams.FindByTeamId(tblMatches.FindByMatchId(14).WinningTeamId).TeamName;

            btnDrawF.IsEnabled = false;
            btnPlayF.IsEnabled = true;
        }

        private void btnPlayF_Click(object sender, RoutedEventArgs e)
        {
            int[] match15TeamId = { tblMatches.FindByMatchId(13).WinningTeamId, tblMatches.FindByMatchId(14).WinningTeamId };

            int[] match15 = playMatch(match15TeamId[0], match15TeamId[1]);

            showResult(tbResult15A, tbResult15B, match15);

            string stage = "Final";
            adpMatches.AddMatch(15, stage, match15TeamId[0], match15TeamId[1], match15[0], match15[1], winningTeam(match15TeamId[0], match15TeamId[1], match15, stage));

            btnPlayF.IsEnabled = false;
        }

        private void btnCheat_Click(object sender, RoutedEventArgs e)
        {
            if (adpTeams.CheckCheatTeam().Rows.Count == 0)
            {
                CheatWindow cheatWindow = new CheatWindow();
                cheatWindow.Show();
            }
            else
            {
                MessageBox.Show("Only One Cheating Team Allowed");
            }
        }
    }
}
