using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace GolfEspData
{
	/// <summary>
	///////////////////////////////////////////////////////////////////////
	/// Database.cs - Contains all database access functions
	/// Copyright (c) 2002, golfESP
	/// Created for Palm by Joshua Buergel
	/// Modified for .NET by Melvin Lervick 
	///////////////////////////////////////////////////////////////////////
	/// </summary>
	public class GolfEspDatabase
	{
		// used by the appliance to contain user specified data.
        //public PROGRAM_STATE g_State = new PROGRAM_STATE();
        //public MASTER_COURSE_INFORMATION cCourse = new MASTER_COURSE_INFORMATION();
        //public PLAYER_INFORMATION [] cPlayers = new PLAYER_INFORMATION[Global.MAX_PLAYERS];
        //public GAME_INFORMATION [] cGames;
        //// Resize when the TEE information is retrieved from the TEES TABLE.
        //public TEE_INFORMATION [] cTees;
		// Tournament GameScore Adapter
//		public OleDbDataAdapter tlGameScoreAdapter = null;

		// Dataset for golfESP tables
		DataSet dsGolfESP = new DataSet();

		// the table of strings for the stat names
		public string [] g_StatLabels = 
			{
				"Greens",
				"Fairways",
				"Putts",
				"Birdies",
				"Eagles",
				"Sand Saves",
				"Chips In",
				"Greenies",
				"Pole Putts",
				"Other"
			};

		// the table of team game strings
		public string [] g_TeamGameStrings = 
			{
				"Best Ball",
				"High/Low",
				"Best Ball/Aggregate",
				"Team Skins",
				"Wolf High/Low",
				"Wolf Best Ball",
				"Tournament"
			};	

		// the table of individual game strings
		public string [] g_IndividualGameStrings = 
			{
				"Match",
				"Skins",
				"Stats",
				"9s / 16s / 25s"
			};	

		// the table of team game strings
		public string [] g_TLTeamGameStrings = 
			{
				"Best Ball",
				"1-2-3 Rotation",
				"3-2-1 Rotation",
				"Scramble",
				"Team Skins",
				"Best Ball (2-Man)",
				"Team Skins (2-Man Gross)",
				"Team Skins (2-Man Net)",
				"Team Skins (Gross)",
				"Team Skins (Net)",
				"Scramble (2-Man)",
				"Scramble"
		};	

		// the table of individual game strings
		public string [] g_TLIndividualGameStrings = 
			{
				"Skins",
				"Skins (Gross)",
				"Skins (Net)"
			};	

		public GolfEspDatabase()
		{
			//
			// TODO: Add constructor logic here
			//
			//GetCourseNames();
		}

//        public string GetConnection()
//        {
//            //The connection path is specified in web.config.  Get PROVIDER and
//            // DSN and return as conn String.
//            string strConnection = ConfigurationSettings.AppSettings["PROVIDER"];
//            strConnection += ConfigurationSettings.AppSettings["DSN"];
//            return strConnection;
//        }

//        public void GetCourseNames()
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "SELECT * FROM courses";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of CourseNames (subset of Table Courses).
//            objAdapter.Fill( dsGolfESP,"Courses" );

//            // UUUUUUUUUUUUUUUUUUUUUUUUUUU
//            // Update "UnprintedRounds" table
//            UpdateUnprintedRoundsTable();

//            // Update "g_State" to latest date in the RoundDates table for the course selected.
//            DataTable tblUnprintedRounds;
//            DataRow[] rowUnprintedRounds;

//            tblUnprintedRounds = dsGolfESP.Tables["UnprintedRounds"];
//            rowUnprintedRounds = tblUnprintedRounds.Select();
//            // UUUUUUUUUUUUUUUUUUUUUUUUUUU

//            // Set number of Courses, and if only 1 course set the Course ID and Name
//            DataTable tblCourses;
//            DataRow[] rowCourses;

//            tblCourses = dsGolfESP.Tables["Courses"];
//            g_State.NumberOfCourses = tblCourses.Rows.Count;
//            if (g_State.NumberOfCourses > 0)
//            {
//                if (rowUnprintedRounds.Length > 0)
//                {
//                    //g_State.TeeTime = rowRoundTimes[0]["RoundTime"].ToString();
//                    rowCourses = tblCourses.Select("CourseID="+rowUnprintedRounds[0]["CourseID"].ToString());
//                }
//                else
//                {
//                    if (g_State.NumberOfCourses == 1)
//                    {
//                        // Only one row
//                        rowCourses = tblCourses.Select();
//                    }
//                    else
//                    {
//                        // More than one row, so set the course to the course designated
//                        // as the PRIMARY course, if there are no unprinted tee time data.
//                        rowCourses = tblCourses.Select("Primary=1");
//                    }
//                }
//                g_State.CourseID = (int)rowCourses[0]["CourseID"];
//                g_State.CurrentCourseName = rowCourses[0]["Name"].ToString();
//                g_State.ShortCourseName = rowCourses[0]["ShortCourseName"].ToString();

//                rowUnprintedRounds = null;
//                tblUnprintedRounds = null;

//                // Update COURSE class data and DATES
//                UpdateCourseData();

//                // By the time we get to this point, the default system date should already
//                // have been set in "g_States".  Get all of the rounds played on the date
//                // currently specified in "g_States".
//                // UpdateRoundTimesTable();
//            }

//            rowCourses = null;
//            tblCourses = null;

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        // Return DataSet which contains all of the Tables.
//        public DataSet GetDS()
//        {
//            return dsGolfESP;
//        }

//        /// <summary>
//        /// Load CourseID, Round Date, and Tee Time
//        /// </summary>
//        /// <param name="id"></param>
//        public void UnprintedRoundSelect(uint id)
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT DISTINCT Format([RoundDate],""mm/dd/yyyy"") AS rdate";
//            strSQL = strSQL + @", CourseID, RoundTime, CourseStart";
//            strSQL = strSQL + @" FROM Rounds";
//            strSQL = strSQL + @" WHERE (((Rounds.RoundID)=" + id.ToString() + "))";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Rounds (1 record)
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["Rounds"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"Rounds" );

//            // Get RoundID
//            DataTable tblRounds;
//            DataRow[] rowRounds;

//            tblRounds = dsGolfESP.Tables["Rounds"];
//            rowRounds = tblRounds.Select();

//            g_State.CourseID = (int)rowRounds[0]["CourseID"];
//            g_State.DatePlayed = rowRounds[0]["rdate"].ToString();
//            g_State.TeeTime = rowRounds[0]["RoundTime"].ToString();
//            g_State.StartHole = Byte.Parse(rowRounds[0]["CourseStart"].ToString());

//            // ROUNDS table no longer needed
//            dsGolfESP.Tables["Rounds"].Clear();
//            rowRounds = null;
//            tblRounds = null;

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        // Using the COURSEID specified in g_State, update the COURSE data
//        public void UpdateCourseData()
//        {
//            // Get the Course data for the selected course
//            GetCourseData(g_State.CourseID);

//            // Course was selected, so load the course tables
//            UpdateAllOtherCourseData(g_State.CourseID);

//            // Get the DATES when rounds were played and store in a data table
//            // called "RoundDates".
//            UpdateRoundDatesTable();

//            // Update "g_State" to latest date in the RoundDates table for the course selected.
//            DataTable tblRoundDates;
//            DataRow[] rowRoundDates;

//            tblRoundDates = dsGolfESP.Tables["RoundDates"];
//            rowRoundDates = tblRoundDates.Select();
//            if (rowRoundDates.Length > 0)
//            {
//                g_State.DatePlayed = rowRoundDates[0]["rdate"].ToString();
//                g_State.sDatePlayed = rowRoundDates[0]["dispdate"].ToString();
//            }

//            rowRoundDates = null;
//            tblRoundDates = null;

//            // Update "RoundTimes" table
//            UpdateRoundTimesTable();

//            // Update "g_State" to latest date in the RoundDates table for the course selected.
//            DataTable tblRoundTimes;
//            DataRow[] rowRoundTimes;

//            tblRoundTimes = dsGolfESP.Tables["RoundTimes"];
//            rowRoundTimes = tblRoundTimes.Select();
//            if (rowRoundTimes.Length > 0)
//                g_State.TeeTime = rowRoundTimes[0]["RoundTime"].ToString();

//            rowRoundTimes = null;
//            tblRoundTimes = null;

//            return;
//        }

//        public void GetCourseData(int CourseID)
//        {
//            DataTable tblCourses;
//            DataRow[] rowCourses;

//            tblCourses = dsGolfESP.Tables["Courses"];
//            rowCourses = tblCourses.Select("CourseID=" + CourseID.ToString());

//            cCourse.CourseName = rowCourses[0]["CourseName"].ToString();
//            switch ((byte)rowCourses[0]["DefaultHandicapType"])
//            {
//                case 0:
//                    cCourse.DefaultHandicapType = HANDICAP_TYPE.HomeHandicap;
//                    break;
//                case 1:
//                    cCourse.DefaultHandicapType = HANDICAP_TYPE.IndexHandicap;
//                    break;
//                case 2:
//                    cCourse.DefaultHandicapType = HANDICAP_TYPE.EstimatedScore;
//                    break;
//            }
//            cCourse.MaxPlayers = (byte)rowCourses[0]["MaxPlayers"];
//            cCourse.NumTees = (byte)rowCourses[0]["NumberOfTees"];
//            g_State.CurrentCourseName = rowCourses[0]["Name"].ToString();
//            g_State.ShortCourseName = rowCourses[0]["ShortCourseName"].ToString();

//            rowCourses = null;
//            tblCourses = null;
//        }

//        // Update all of the other course tables, now that a course has been selected
//        public void UpdateAllOtherCourseData(int CourseID)
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;
//            OleDbDataAdapter objAdapter2 = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            string strSQL2 = "";

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM Tees";
//            strSQL = strSQL + @" WHERE (((CourseID)=" + CourseID.ToString() + "))";
//            strSQL2 = strSQL2 + @" ORDER BY MCourseRating DESC";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);
//            objAdapter.Fill( dsGolfESP,"Tees" );

//            // Move the Data into the "cTees" class
//            DataTable tblTees;
//            DataRow[] rowTees;

//            tblTees = dsGolfESP.Tables["Tees"];
//            rowTees = tblTees.Select();
//            if (tblTees.Rows.Count > 0)
//            {
//                // TEES are defined
//                byte k = 0;
//                cTees = null;
//                cTees = new TEE_INFORMATION[tblTees.Rows.Count];
//                for (int i=0;i<tblTees.Rows.Count;i++)
//                {
//                    cTees[i] = new TEE_INFORMATION();
//                    cTees[i].TeeID = (uint)(int)rowTees[i]["TeeID"];
//                    cTees[i].TeeName = rowTees[i]["TeeName"].ToString();
//                    cTees[i].ShortName = rowTees[i]["ShortName"].ToString();
//                    cTees[i].Mens = (bool)rowTees[i]["Mens"];
//                    cTees[i].Ratings[0] = new COURSE_RATINGS();
//                    cTees[i].Ratings[0].Slope = (ushort)(short)rowTees[i]["MSlope"];
//                    cTees[i].Ratings[0].CourseRating = (double)rowTees[i]["MCourseRating"];
//                    cTees[i].Ratings[1] = new COURSE_RATINGS();
//                    cTees[i].Ratings[1].Slope = (ushort)(short)rowTees[i]["FSlope"];
//                    cTees[i].Ratings[1].CourseRating = (double)rowTees[i]["FCourseRating"];
//                    cTees[i].MPrint = (bool)rowTees[i]["MPrint"];
//                    cTees[i].FPrint = (bool)rowTees[i]["FPrint"];
//                    cTees[i].PinLocation = rowTees[i]["PinLocation"].ToString();

//                    // Get HOLE data for this Tee
//                    strSQL2 = @"SELECT *";
//                    strSQL2 = strSQL2 + @" FROM Holes";
//                    strSQL2 = strSQL2 + @" WHERE (((TeeID)=" + cTees[i].TeeID.ToString() + "))";
//                    // Open the connection/data adapter
//                    objAdapter2 = new OleDbDataAdapter(strSQL2, objConnection);
//                    objAdapter2.Fill( dsGolfESP,"Holes" );

//                    DataTable tblHoles;
//                    DataRow[] rowHoles;

//                    tblHoles = dsGolfESP.Tables["Holes"];
//                    rowHoles = tblHoles.Select();
//                    if (tblHoles.Rows.Count > 0)
//                    {
//                        // HOLES are defined (NOTE all TEES must have the same number of HOLES)
//                        // This code may need to be updated if there is ever an exception (shouldn't be)
//                        // unless the database was entered incorrectly.
//                        cTees[i].Holes = new HOLE_INFORMATION[tblHoles.Rows.Count];
//                        for (int j=0;j<tblHoles.Rows.Count;j++)
//                        {
//                            // Store the Hole Data
//                            k = (byte)((byte)(rowHoles[j]["HoleNumber"]) - 1);
//                            cTees[i].Holes[k] = new HOLE_INFORMATION();
//                            cTees[i].Holes[k].Length = (ushort)(short)rowHoles[j]["Length"];
//                            cTees[i].Holes[k].Par = (byte)rowHoles[j]["Par"];
//                            cTees[i].Holes[k].Handicap = (byte)rowHoles[j]["Handicap"];
//                        }
//                    }

//                    rowHoles = null;
//                    tblHoles = null;
//                    objAdapter2.Dispose();
//                    // Remove the Holes Table
//                    dsGolfESP.Tables.Remove("Holes");
//                }
//            }

//            rowTees = null;
//            tblTees = null;

//            // Remove the Tees Table
//            dsGolfESP.Tables.Remove("Tees");

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();
//        }

//        // Get all of the Dates when rounds were played and store in
//        // a data table "RoundDates".
//        public void UpdateRoundDatesTable()
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT DISTINCT Format([RoundDate],""yyyymmdd"") AS sdate";
//            strSQL = strSQL + @", Format([RoundDate],""mm/dd/yyyy"") AS rdate";
//            strSQL = strSQL + @", Format([RoundDate],""dddd mmmm dd, yyyy"") AS dispdate";
//            strSQL = strSQL + @" FROM Rounds";
//            strSQL = strSQL + @" WHERE (((Rounds.CourseID)=" + g_State.CourseID.ToString() + "))";
//            strSQL = strSQL + @" ORDER BY Format([RoundDate],""yyyymmdd"") DESC";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of RoundDates (subset of Table rounds).
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["RoundDates"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"RoundDates" );

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        public bool IsThisARoundDate(string indate)
//        {
//            bool retval = false;

//            // Get RoundID
//            DataTable tblRoundDates;
//            DataRow[] rowRoundDates;

//            tblRoundDates = dsGolfESP.Tables["RoundDates"];
//            rowRoundDates = tblRoundDates.Select("rdate='"+indate+"'");
//            if (rowRoundDates.Length > 0)
//                retval = true;

//            rowRoundDates = null;
//            tblRoundDates = null;
//            return retval;
//        }

//        // Get all of the Times when rounds were played on the specified date and store in
//        // a data table "RoundTimes".
//        public void UpdateRoundTimesTable()
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT RoundTime, MilitaryTime";
//            strSQL = strSQL + @" FROM Rounds";
//            strSQL = strSQL + @" WHERE (((CourseID)=" + g_State.CourseID.ToString();
//            strSQL = strSQL + @") AND ((RoundDate)=#" + g_State.DatePlayed.ToString() + "#))";
//            strSQL = strSQL + @" ORDER BY MilitaryTime DESC";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of RoundDates (subset of Table rounds).
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["RoundTimes"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"RoundTimes" );

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        public void UpdateUnprintedRoundsTable()
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM PDADataIn";
//            strSQL = strSQL + @" WHERE ((InDate)>=#"+DateTime.Today.AddDays(-1)+"#)";
//            strSQL = strSQL + @" ORDER BY InTimeMilitary DESC";

//            try
//            {
//                // Open the connection/data adapter
//                objConnection = new OleDbConnection(strConnection);
//                objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//                // Fill the datset with a table of RoundDates (subset of Table rounds).
//                // Make sure that the table is empty before updating with new data.
//                try
//                {
//                    dsGolfESP.Tables["UnprintedRounds"].Clear();
//                }
//                catch
//                {
//                    // Table was not yet created, no error processing needed.
//                }

//                objAdapter.Fill( dsGolfESP,"UnprintedRounds" );
//            }
//            catch
//            {
//                // Problem accessing database, just wait until next pass.
//            }

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        public void GetTournamentRoundTimes(int id)
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT DISTINCTROW Rounds.RoundTime, Rounds.MilitaryTime, Rounds.RoundID";
//            strSQL = strSQL + @" FROM (Rounds INNER JOIN TourLiteTeams ON Rounds.RoundID = TourLiteTeams.RoundID)";
//            strSQL = strSQL + @" INNER JOIN TourLiteGames ON TourLiteTeams.TLGameID = TourLiteGames.TLGameID";
//            strSQL = strSQL + @" WHERE (((TourLiteGames.TournamentID)="+id.ToString()+"))";
//            strSQL = strSQL + @" ORDER BY Rounds.RoundDate DESC , Rounds.MilitaryTime DESC";
///*
//SELECT DISTINCTROW Rounds.RoundTime, Rounds.MilitaryTime, Rounds.RoundID
//FROM (Rounds INNER JOIN TourLiteTeams ON Rounds.RoundID = TourLiteTeams.RoundID) INNER JOIN TourLiteGames ON TourLiteTeams.TLGameID = TourLiteGames.TLGameID
//WHERE (((TourLiteGames.TournamentID)=6))
//ORDER BY Rounds.RoundDate DESC , Rounds.MilitaryTime DESC
//*/
//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of RoundDates (subset of Table rounds).
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TournamentRoundTimes"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TournamentRoundTimes" );

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        public void UpdateTournamentsTable()
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM Tournaments";
//            strSQL = strSQL + @" ORDER BY DateStart DESC";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of RoundDates (subset of Table rounds).
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["Tournaments"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"Tournaments" );

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }

//        public OleDbDataAdapter GetSelectedTournamentGames(int id)
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM TourLiteGames";
//            strSQL = strSQL + @" WHERE TournamentID = "+id.ToString();

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of RoundDates (subset of Table rounds).
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TourLiteGames"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TourLiteGames" );

//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            objAdapter.DeleteCommand = tlg.GetDeleteCommand();
//            objAdapter.InsertCommand = tlg.GetInsertCommand();
//            objAdapter.UpdateCommand = tlg.GetUpdateCommand();

//            return objAdapter;
//        }

//        public void UpdateTourLiteHHID(int id)
//        {
//            // UPDATE Tournaments SET Tournaments.HHID = "TL"+Str([TournamentID]);
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            strSQL = @"UPDATE Tournaments";
//            strSQL += @" SET HHID = 'TL"+id.ToString()+"'";
//            strSQL += @" WHERE (TournamentID = "+id.ToString() + ")";
//            objCommand.CommandText = strSQL;
//            objCommand.ExecuteNonQuery();

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }

//        public OleDbDataAdapter GetSelectedTournament(int id)
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM Tournaments";
//            strSQL = strSQL + @" WHERE TournamentID = "+id.ToString();

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["AEDTournament"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"AEDTournament" );

//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            objAdapter.DeleteCommand = tlg.GetDeleteCommand();
//            objAdapter.InsertCommand = tlg.GetInsertCommand();
//            objAdapter.UpdateCommand = tlg.GetUpdateCommand();

//            return objAdapter;
//        }

//        /// <summary>
//        /// Delete record from PDADataIn using current value of CourseID, Date, Time.
//        /// NOTE: this function should not return an error if there is no record, but it should
//        ///			update the UNPRINTEDROUNDS Table and Set selection fields to point
//        ///			to the first record in the table.  This insures that the system always displays
//        ///			the selection criteria for the first record in the UnprintedRounds Table.
//        ///			If there are no records, leave the values set as they were on entry.
//        /// </summary>
//        public void DeleteFromUnprintedRoundsMasterTable()
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            //OleDbDataAdapter objAdapter = null;
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Get Delete the import record in PDADATAIN
//                strSQL = "DELETE PDADataIn.*, PDADataIn.CourseID, PDADataIn.InDate, PDADataIn.InTime";
//                strSQL += " FROM PDADataIn";
//                strSQL += " WHERE (((PDADataIn.CourseID)="+g_State.CourseID+") AND";
//                strSQL += " ((PDADataIn.InDate)=#" + g_State.DatePlayed + "#) AND";
//                strSQL += " ((PDADataIn.InTime)='"+g_State.TeeTime+"'))";

//                objCommand.CommandText = strSQL;
//                objCommand.ExecuteNonQuery();
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Update UnprintedRounds Table
//            UpdateUnprintedRoundsTable();

//            // Update COURSE class data and DATES
//            UpdateCourseData();

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }

//        /// <summary>
//        /// Load Round Player and Game Tables
//        /// </summary>
//        /// <returns>No return Values</returns>
//        public void LoadRoundAndGameData()
//        {
//            // Local Variables
//            int RoundID = 0;

//            // Get the ROUND record
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM Rounds";
//            strSQL = strSQL + @" WHERE (((CourseID)=" + g_State.CourseID.ToString();
//            strSQL = strSQL + @") AND ((RoundDate)=#" + g_State.DatePlayed.ToString() + "#";
//            strSQL = strSQL + ") AND ((RoundTime)=\"" + g_State.TeeTime.ToString() + "\"))";

//            // Open the connection/data adapter
//            objConnection = new OleDbConnection(strConnection);
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Rounds (1 record)
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["Rounds"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"Rounds" );

//            // Get RoundID
//            DataTable tblRounds;
//            DataRow[] rowRounds;

//            tblRounds = dsGolfESP.Tables["Rounds"];
//            rowRounds = tblRounds.Select();

//            RoundID = (int)rowRounds[0]["RoundID"];

//            // ROUNDS table no longer needed
//            dsGolfESP.Tables["Rounds"].Clear();
//            rowRounds = null;
//            tblRounds = null;

//            objAdapter = null;

//            //=================================================
//            // Get Players
//            GetPlayers(RoundID);
//            //
//            //=================================================
//            //=================================================
//            // Get Games
//            objAdapter = null;

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM Games";
//            strSQL = strSQL + @" WHERE ((RoundID)=" + RoundID.ToString();
//            strSQL = strSQL + @") ORDER BY TeamGame";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Games
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["Games"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"Games" );

//            //######################################
//            // Get GameTeams Table
//            objAdapter = null;

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM GameTeams";
//            strSQL = strSQL + @" ORDER BY GameID, TeamNumber";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of GameTeams
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["GameTeams"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"GameTeams" );

//            //######################################
//            //######################################
//            // Get GamePresses Table
//            objAdapter = null;

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM GamePresses";
//            strSQL = strSQL + @" ORDER BY GameID, HoleNumber";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of GamePresses
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["GamePresses"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"GamePresses" );

//            //######################################
//            //######################################
//            // Get TeamPlayers Table
//            objAdapter = null;

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM TeamPlayers";
//            strSQL = strSQL + @" ORDER BY GameTeamID, PlayerNumber";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of TeamPlayers
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TeamPlayers"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TeamPlayers" );

//            //######################################

//            // Fill the Games CLASS Data
//            DataTable tblGames;
//            DataRow[] rowGames;

//            tblGames = dsGolfESP.Tables["Games"];
//            rowGames = tblGames.Select("","GameType,GameNumber");

//            //------------------------------------------------------
//            cGames = null;
//            g_State.NumGames = (byte)tblGames.Rows.Count;
//            cGames = new GAME_INFORMATION[g_State.NumGames];
//            for (int i=0;i<tblGames.Rows.Count;i++)
//            {
//                cGames[i] = new GAME_INFORMATION();
//                cGames[i].TeamGame = (bool)rowGames[i]["TeamGame"];
//                cGames[i].TeamSize = (byte)rowGames[i]["TeamSize"];
//                cGames[i].GameType = (GAME_TYPE)(byte)rowGames[i]["GameType"];
//                cGames[i].GameFlags = (uint)(int)rowGames[i]["GameFlags"];
//                cGames[i].HandicapPercent = (short)rowGames[i]["HandicapPercent"];

//                // Store Team Arrays (1 and 2) until unlimited teams are allowed
//                //------------------------------------------------------
//                DataTable tblGameTeams;
//                DataRow[] rowGameTeams;

//                tblGameTeams = dsGolfESP.Tables["GameTeams"];
//                rowGameTeams = tblGameTeams.Select("GameID=" + rowGames[i]["GameID"].ToString());

//                // Using Team Number, Get the Players on the Team
//                for (int j=0;j<rowGameTeams.Length;j++)
//                {
//                    // Get Team Players
//                    DataTable tblTeamPlayers;
//                    DataRow[] rowTeamPlayers;

//                    tblTeamPlayers = dsGolfESP.Tables["TeamPlayers"];
//                    rowTeamPlayers = tblTeamPlayers.Select("GameTeamID=" + rowGameTeams[j]["GameTeamID"].ToString());

//                    if ((byte)rowGameTeams[j]["TeamNumber"] == (byte)1)
//                    {
//                        // Store TEAM1
//                        for (int k=0;k<rowTeamPlayers.Length;k++)
//                        {
//                            // Get PlayerNumber from PLAYERS table
//                            DataTable tblPlayers1;
//                            DataRow[] rowPlayers1;

//                            tblPlayers1 = dsGolfESP.Tables["Players"];
//                            rowPlayers1 = tblPlayers1.Select("PlayerID=" + rowTeamPlayers[k]["PlayerID"].ToString());

//                            cGames[i].Team1[(byte)rowTeamPlayers[k]["PlayerNumber"]] = (byte)rowPlayers1[0]["PlayerNumber"];

//                            rowPlayers1 = null;
//                            tblPlayers1 = null;
//                        }
//                    }
//                    else
//                    {
//                        if ((byte)rowGameTeams[j]["TeamNumber"] == (byte)2)
//                        {
//                            // Store TEAM2
//                            for (int k=0;k<rowTeamPlayers.Length;k++)
//                            {
//                                // Get PlayerNumber from PLAYERS table
//                                DataTable tblPlayers1;
//                                DataRow[] rowPlayers1;

//                                tblPlayers1 = dsGolfESP.Tables["Players"];
//                                rowPlayers1 = tblPlayers1.Select("PlayerID=" + rowTeamPlayers[k]["PlayerID"].ToString());

//                                cGames[i].Team2[(byte)rowTeamPlayers[k]["PlayerNumber"]] = (byte)rowPlayers1[0]["PlayerNumber"];

//                                rowPlayers1 = null;
//                                tblPlayers1 = null;
//                            }
//                        }
//                        else
//                        {
//                            // Invalid TEAM NUMBER for Version 1.  Clear Current Game Data
//                            // and decrement g_State.NumGames by 1
//                        }
//                    }
//                }

//                // Release GAMETEAMS local objects
//                rowGameTeams = null;
//                tblGameTeams = null;
//                //------------------------------------------------------

//                // Store GamePresses
//                DataTable tblGamePresses;
//                DataRow[] rowGamePresses;

//                tblGamePresses = dsGolfESP.Tables["GamePresses"];
//                rowGamePresses = tblGamePresses.Select("GameID=" + rowGames[i]["GameID"].ToString());

//                // Clear all PRESSES
//                for (byte kk=0;kk<Global.MAX_HOLES;kk++)
//                {
//                    cGames[i].Presses[kk] = (byte)0;
//                }

//                for (byte kk=0;kk<rowGamePresses.Length;kk++)
//                {
//                    cGames[i].Presses[(int)(byte)rowGamePresses[kk]["HoleNumber"]] = (byte)1;
//                }

//                // Release GAMEPRESSES local objects
//                rowGamePresses = null;
//                tblGamePresses = null;
//            }

//            //------------------------------------------------------

//            // Release GAMETEAMS table
//            dsGolfESP.Tables["TeamPlayers"].Clear();
//            // Release GAMETEAMS table
//            dsGolfESP.Tables["GamePresses"].Clear();
//            // Release GAMETEAMS table
//            dsGolfESP.Tables["GameTeams"].Clear();
//            // Release GAMES table and local objects
//            dsGolfESP.Tables["Games"].Clear();
//            rowGames = null;
//            tblGames = null;
//            //=================================================
//            // Release PLAYERS table
//            dsGolfESP.Tables["Players"].Clear();

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//        }

//        /// <summary>
//        /// Get the Players Data for the current Round
//        /// </summary>
//        /// <param name="RoundID"></param>
//        public void GetPlayers(int RoundID)
//        {
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM Players";
//            strSQL = strSQL + @" WHERE ((RoundID)=" + RoundID.ToString();
//            strSQL = strSQL + @") ORDER BY PlayerNumber";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["Players"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"Players" );

//            // Fill the Players CLASS Data
//            DataTable tblPlayers;
//            DataRow[] rowPlayers;

//            tblPlayers = dsGolfESP.Tables["Players"];
//            rowPlayers = tblPlayers.Select();

//            byte row = 0;
//            g_State.NumPlayers = (byte)tblPlayers.Rows.Count;
//            for (int i=0;i<tblPlayers.Rows.Count;i++)
//            {
//                row = (byte)rowPlayers[i]["PlayerNumber"];
//                cPlayers[row] = new PLAYER_INFORMATION();
//                cPlayers[row].PlayerID = (int)rowPlayers[i]["PlayerID"];
//                cPlayers[row].Posted = (bool)rowPlayers[i]["Posted"];
//                cPlayers[row].Initials = rowPlayers[i]["Initials"].ToString();
//                cPlayers[row].FirstName = rowPlayers[i]["FirstName"].ToString();
//                cPlayers[row].LastName = rowPlayers[i]["LastName"].ToString();
//                cPlayers[row].ClubNumber = rowPlayers[i]["ClubNumber"].ToString();
//                cPlayers[row].GHIN = rowPlayers[i]["GHIN"].ToString();
//                cPlayers[row].LocalNumber = rowPlayers[i]["LocalNumber"].ToString();
//                cPlayers[row].Handicap = (double)rowPlayers[i]["Handicap"];
//                cPlayers[row].HandicapStr = cPlayers[row].Handicap.ToString();
//                cPlayers[row].ComputedHandicap = (short)rowPlayers[i]["ComputedHandicap"];
//                cPlayers[row].ComputedHandicapStr = cPlayers[row].ComputedHandicap.ToString();
//                cPlayers[row].PlusHandicap = (bool)rowPlayers[i]["PlusHandicap"];
//                if ((byte)rowPlayers[i]["Gender"] == (byte)0)
//                {
//                    cPlayers[row].Gender = GENDER.Male;
//                }
//                else
//                {
//                    cPlayers[row].Gender = GENDER.Female;
//                }

//                cPlayers[row].Tees = (uint)(int)rowPlayers[i]["TeeID"];

//                // Store HANDICAP TYPE
//                cPlayers[row].HandicapType = (HANDICAP_TYPE)(byte)rowPlayers[i]["HandicapType"];
//                cPlayers[row].InGameStats = (uint)(int)rowPlayers[i]["InGameStats"];
//                cPlayers[row].TrackStats = (bool)rowPlayers[i]["TrackStats"];
//                cPlayers[row].TrackingStats = (uint)(int)rowPlayers[i]["TrackingStats"];

//                // Get the Scores for the Player
//                objAdapter = null;
//                //=================================================
//                // Get Game Scores
//                strSQL = @"SELECT *";
//                strSQL = strSQL + @" FROM GameScores";
//                strSQL = strSQL + @" WHERE ((PlayerID)=" + rowPlayers[i]["PlayerID"].ToString();
//                strSQL = strSQL + @") ORDER BY HoleNumber";

//                // Open the connection/data adapter
//                objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//                // Fill the datset with a table of Players
//                // Make sure that the table is empty before updating with new data.
//                try
//                {
//                    dsGolfESP.Tables["GameScores"].Clear();
//                }
//                catch
//                {
//                    // Table was not yet created, no error processing needed.
//                }

//                objAdapter.Fill( dsGolfESP,"GameScores" );

//                // Fill the Players CLASS Data
//                DataTable tblScores;
//                DataRow[] rowScores;

//                tblScores = dsGolfESP.Tables["GameScores"];
//                rowScores = tblScores.Select();

//                byte hole = 0;
//                for (int k=0;k<tblScores.Rows.Count;k++)
//                {
//                    hole = (byte)rowScores[k]["HoleNumber"];
//                    cPlayers[row].Scores[hole] = (byte)rowScores[k]["Score"];
//                    cPlayers[row].XScores[hole] = (bool)rowScores[k]["XScore"];
//                    // Store Stats
//                    cPlayers[row].Stats[hole,(int)STATS.Greens] = (byte)rowScores[k]["Greens"];
//                    cPlayers[row].Stats[hole,(int)STATS.Fairways] = (byte)rowScores[k]["Fairways"];
//                    cPlayers[row].Stats[hole,(int)STATS.Putts] = (byte)rowScores[k]["Putts"];
//                    cPlayers[row].Stats[hole,(int)STATS.Birdies] = (byte)rowScores[k]["Birdies"];
//                    cPlayers[row].Stats[hole,(int)STATS.Eagles] = (byte)rowScores[k]["Eagles"];
//                    cPlayers[row].Stats[hole,(int)STATS.SandSaves] = (byte)rowScores[k]["SandSaves"];
//                    cPlayers[row].Stats[hole,(int)STATS.ChipsIn] = (byte)rowScores[k]["ChipsIn"];
//                    cPlayers[row].Stats[hole,(int)STATS.Greenies] = (byte)rowScores[k]["Greenies"];
//                    cPlayers[row].Stats[hole,(int)STATS.PolePutts] = (byte)rowScores[k]["PolePutts"];
//                    cPlayers[row].Stats[hole,(int)STATS.Other] = (byte)rowScores[k]["Others"];
//                }

//                // Release Game Scores
//                dsGolfESP.Tables["GameScores"].Clear();
//                rowScores = null;
//                tblScores = null;
//            }

//            // Release local objects
//            rowPlayers = null;
//            tblPlayers = null;
//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//        }

//        public void GetTournamentRounds(int TournamentID)
//        {
//            // "Load TournamentRounds" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT DISTINCT RoundID";
//            strSQL = strSQL + @" FROM TourLiteTeams INNER JOIN TourLiteGames ON TourLiteTeams.TLGameID = TourLiteGames.TLGameID";
//            strSQL = strSQL + @" WHERE ((TourLiteGames.TournamentID)=" + TournamentID.ToString();
//            strSQL = strSQL + @")";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TournamentRounds"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TournamentRounds" );

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//        }

//        public void GetTournamentTeams(int RoundID)
//        {
//            // "Load TournamentTeams" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT TourLiteTeams.RoundID, TourLiteTeams.TLGameID, TourLiteTeams.TLTeamID, TourLiteTeamPlayers.PlayerID, TourLiteTeamPlayers.PlayerNumber";
//            strSQL = strSQL + @" FROM TourLiteTeams LEFT JOIN TourLiteTeamPlayers ON TourLiteTeams.TLTeamID = TourLiteTeamPlayers.TLTeamID";
//            strSQL = strSQL + @" WHERE (((TourLiteTeams.RoundID)=" + RoundID.ToString();
//            strSQL = strSQL + @"))";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TournamentTeams"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TournamentTeams" );

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();
//        }

//        public void GetTLGameScores(int tournamentid)
//        {
//            // "Load TourLiteGameScores" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT TourLiteGameScores.*, TourLiteGames.GameType,";
//            strSQL += @" TourLiteGames.TeamSize, TourLiteGames.TLGameID, Rounds.RoundDate, Rounds.MilitaryTime";
//            strSQL += @" FROM (TourLiteGameScores";
//            strSQL += @" INNER JOIN (TourLiteTeams INNER JOIN Rounds ON TourLiteTeams.RoundID = Rounds.RoundID)";
//            strSQL += @" ON TourLiteGameScores.TLTeamID = TourLiteTeams.TLTeamID)";
//            strSQL += @" INNER JOIN TourLiteGames ON TourLiteTeams.TLGameID = TourLiteGames.TLGameID";
//            strSQL += @" WHERE (((TourLiteGames.TournamentID)="+tournamentid.ToString();
//            strSQL +=  @"))";
///*
//SELECT TourLiteGameScores.*, TourLiteGames.GameType, TourLiteGames.TeamSize, TourLiteGames.TLGameID, Rounds.RoundDate, Rounds.MilitaryTime
//FROM (TourLiteGameScores INNER JOIN (TourLiteTeams INNER JOIN Rounds ON TourLiteTeams.RoundID = Rounds.RoundID) 
//ON TourLiteGameScores.TLTeamID = TourLiteTeams.TLTeamID) 
//INNER JOIN TourLiteGames ON TourLiteTeams.TLGameID = TourLiteGames.TLGameID
//WHERE (((TourLiteGames.TournamentID)=1))
//*/
//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Game Scores
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TLGameScores"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TLGameScores" );

//            strSQL = @"SELECT * FROM TourLiteGameScores WHERE (TLGameScoreID=0)";
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);
//            // Fill the datset with a table of Game Scores
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TourLiteGameScores"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TourLiteGameScores" );
//            // Make sure the table is created, with no records
//            dsGolfESP.Tables["TourLiteGameScores"].Clear();

//            /*
//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            objAdapter.DeleteCommand = tlg.GetDeleteCommand();
//            objAdapter.InsertCommand = tlg.GetInsertCommand();
//            objAdapter.UpdateCommand = tlg.GetUpdateCommand();

//            tlGameScoreAdapter = objAdapter;
//            */

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();
//        }
//        //
//        public bool SaveTourLiteGameScores()
//        {
//            bool retval = false;
//            // "Load TourLiteGameScores" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);
//            //
//            strSQL = @"SELECT * FROM TourLiteGameScores WHERE (TLGameScoreID=0)";
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);
//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            objAdapter.DeleteCommand = tlg.GetDeleteCommand();
//            objAdapter.InsertCommand = tlg.GetInsertCommand();
//            objAdapter.UpdateCommand = tlg.GetUpdateCommand();
//            try
//            {
//                objAdapter.Update(dsGolfESP,"TourLiteGameScores");
//                retval = true;
//            }
//            catch (OleDbException e)
//            {
//                retval = false;
//            }

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return retval;
//        }
//        //
//        public string GetTLGameScoreInitials(int TeamID)
//        {
//            // "Load TourLiteGameScores" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT Players.Initials";
//            strSQL += @" FROM Players INNER JOIN TourLiteTeamPlayers ON Players.PlayerID = TourLiteTeamPlayers.PlayerID";
//            strSQL += @" WHERE (((TourLiteTeamPlayers.TLTeamID)="+TeamID.ToString();
//            strSQL +=  @"))";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Game Scores
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TLinitials"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TLinitials" );

//            DataTable dt;
//            DataRow[] dr;
//            string names = "";

//            dt = dsGolfESP.Tables["TLinitials"];
//            dr = dt.Select();
//            for (int i=0;i<dr.Length;i++)
//            {
//                // Add all of the Team Player Initials separated by "/"
//                if (i > 0) names += "/";
//                names += dr[i]["Initials"].ToString();
//            }

//            dr = null;
//            dt = null;
//            dsGolfESP.Tables["TLinitials"].Dispose();
//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return names;
//        }

//        public int GetCourseID(int RoundID)
//        {
//            // Get CourseID for the Specified Round
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT Rounds.CourseID";
//            strSQL = strSQL + @" FROM Rounds";
//            strSQL = strSQL + @" WHERE ((Rounds.RoundID)=" + RoundID.ToString();
//            strSQL = strSQL + @")";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["CourseID"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"CourseID" );
//            // get CourseID
//            DataTable dt;
//            DataRow[] dr;
//            int courseid = 0;

//            dt = dsGolfESP.Tables["CourseID"];
//            dr = dt.Select();
//            courseid = (int)dr[0]["CourseID"];
//            dr = null;
//            dt = null;

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return courseid;
//        }
//        //
//        /// <summary>
//        /// Remove all existing scores for the specified TournamentID, and then
//        /// update the TLGameScores table in memory to make sure that it is empty and
//        /// that all of the records were removed from the DATABASE.
//        /// </summary>
//        /// <param name="tournamentid"></param>
//        /// <param name="roundid"></param>
//        public void RemoveTLGameScores(int tournamentid, int roundid)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Delete the previously computed game scores
//                strSQL = "qTourLiteScores_DeleteTR";
//                objCommand.CommandType = CommandType.StoredProcedure;
//                objCommand.CommandText = strSQL;
//                // Define paramer(s)
//                OleDbParameter parmID = new OleDbParameter("TournamentID",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = tournamentid;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("RoundID",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = roundid;
//                objCommand.Parameters.Add(parmID);
//                objCommand.ExecuteNonQuery();
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Update the TLGameScores Table
//            GetTLGameScores(tournamentid);

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }
//        //
//        public bool SetPlayerPostedFlag(int tournamentid,int roundid,int playerid,bool flag)
//        {
//            bool recompute = false;
//            // set the POSTED flag for the specified player
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Update Posted Flag
//                strSQL = "qPlayers_UpdatePostedFlag";
//                objCommand.CommandType = CommandType.StoredProcedure;
//                objCommand.CommandText = strSQL;
//                // Define paramer(s)
//                OleDbParameter parmID = new OleDbParameter("PlayerID",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = playerid;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("SetPosted",OleDbType.Boolean);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = flag;
//                objCommand.Parameters.Add(parmID);
//                objCommand.ExecuteNonQuery();

//                cPlayers[this.GetPlayerIndexFromID(playerid)].Posted = flag;

//                objConnection.Close();
//                recompute = TournamentUpdatePostedFlagAndScores(tournamentid,roundid,flag);
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();

//            return recompute;
//        }
//        //
//        private bool TournamentUpdatePostedFlagAndScores(int tournamentid,int roundid,bool flag)
//        {
//            bool recompute = false;
//            // If all players for the ROUND have posted scores, set the Tournament Round POSTED flag
//            // set the POSTED flag for the specified player
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();
//            OleDbCommand objCommand2 = new OleDbCommand();
//            OleDbDataAdapter objAdapter = new OleDbDataAdapter();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand2.Connection = objConnection;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Delete the previously computed game scores
//                strSQL = "qPlayers_PostedCount";
//                objCommand.CommandType = CommandType.StoredProcedure;
//                objCommand.CommandText = strSQL;
//                // Define paramer(s)
//                OleDbParameter parmID = new OleDbParameter("RoundID",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = roundid;
//                objCommand.Parameters.Add(parmID);
//                objAdapter.SelectCommand = objCommand;

//                DataTable dt = new DataTable();
//                objAdapter.Fill(dt);
//                DataRow [] dr = dt.Select();
//                if (dt.Rows.Count > 0)
//                {
//                    // valid rows were returned
//                    //int count = (int)(double)dr[0]["Count"];
//                    //int players = (int)dr[0]["Players"];
					
//                    if ((int)(double)dr[0]["Count"] == (int)dr[0]["Players"])
//                    {
//                        // ALL SCORES are POSTED, so update tournament posted flag
//                        try
//                        {
//                            // Update Posted Flag
//                            strSQL = "qTournamentRounds_UpdatePostedFlag";
//                            objCommand2.CommandType = CommandType.StoredProcedure;
//                            objCommand2.CommandText = strSQL;
//                            // Define paramer(s)
//                            parmID = new OleDbParameter("RoundID",OleDbType.Integer);
//                            parmID.Direction = ParameterDirection.Input;
//                            parmID.Value = roundid;
//                            objCommand2.Parameters.Add(parmID);
//                            parmID = new OleDbParameter("SetPosted",OleDbType.Boolean);
//                            parmID.Direction = ParameterDirection.Input;
//                            parmID.Value = (flag?1:0);
//                            objCommand2.Parameters.Add(parmID);
//                            objCommand2.ExecuteNonQuery();
//                            recompute = true;
//                        }
//                        catch
//                        {
//                            // No Error processing if no records to remove.
//                        }
//                    }
//                    else
//                    {
//                        // Update Posted Flag
//                        strSQL = "qTournamentRounds_UpdatePostedFlag";
//                        objCommand2.CommandType = CommandType.StoredProcedure;
//                        objCommand2.CommandText = strSQL;
//                        // Define paramer(s)
//                        parmID = new OleDbParameter("RoundID",OleDbType.Integer);
//                        parmID.Direction = ParameterDirection.Input;
//                        parmID.Value = roundid;
//                        objCommand2.Parameters.Add(parmID);
//                        parmID = new OleDbParameter("SetPosted",OleDbType.Boolean);
//                        parmID.Direction = ParameterDirection.Input;
//                        parmID.Value = (flag?1:0);
//                        objCommand2.Parameters.Add(parmID);
//                        objCommand2.ExecuteNonQuery();
//                        // Make sure the tournament scores are removed
//                        RemoveTLGameScores(tournamentid,roundid);
//                    }
//                }
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objCommand2.Dispose();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return recompute;
//        }
//        //
//        public void UpdatePlayerInitialsAndHandicap(int playerid,string initials, 
//            double handicap, short computed, byte handicaptype, bool plushandicap)
//        {
//            // Update Player Initials and Handicap
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Update Posted Flag
//                strSQL = "qPlayers_UpdateInitialsAndHandicap";
//                objCommand.CommandType = CommandType.StoredProcedure;
//                objCommand.CommandText = strSQL;
//                // Define paramer(s)
//                OleDbParameter parmID = new OleDbParameter("PlayerID",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = playerid;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("Initials",OleDbType.Char);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = initials;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("Handicap",OleDbType.Double);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = (double)handicap;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("Computed",OleDbType.SmallInt);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = computed;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("HandicapType",OleDbType.TinyInt);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = handicaptype;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("Plus",OleDbType.Boolean);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = plushandicap;
//                objCommand.Parameters.Add(parmID);
//                objCommand.ExecuteNonQuery();
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }
//        //
//        public void UpdatePlayerScore(int playerid,byte hole,byte score,bool xscore)
//        {
//            // Update Player Initials and Handicap
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Update Posted Flag
//                strSQL = "qPlayers_UpdateScore";
//                objCommand.CommandType = CommandType.StoredProcedure;
//                objCommand.CommandText = strSQL;
//                // Define paramer(s)
//                OleDbParameter parmID = new OleDbParameter("PlayerID",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = playerid;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("Hole",OleDbType.TinyInt);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = hole;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("NewScore",OleDbType.TinyInt);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = score;
//                objCommand.Parameters.Add(parmID);
//                parmID = new OleDbParameter("NewX",OleDbType.Boolean);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = xscore;
//                objCommand.Parameters.Add(parmID);
//                objCommand.ExecuteNonQuery();
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }
//        //
//        public void GetPostedRounds(int tourid)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();
//            OleDbDataAdapter objAdapter = new OleDbDataAdapter();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Delete the previously computed game scores
//                strSQL = "qTournamentRounds_Posted";
//                objCommand.CommandType = CommandType.StoredProcedure;
//                objCommand.CommandText = strSQL;
//                // Define paramer(s)
//                OleDbParameter parmID = new OleDbParameter("tourid",OleDbType.Integer);
//                parmID.Direction = ParameterDirection.Input;
//                parmID.Value = tourid;
//                objCommand.Parameters.Add(parmID);
//                objAdapter.SelectCommand = objCommand;

//                // Fill the datset with a table of Rounds
//                // Make sure that the table is empty before updating with new data.
//                try
//                {
//                    dsGolfESP.Tables["RoundsPosted"].Clear();
//                }
//                catch
//                {
//                    // Table was not yet created, no error processing needed.
//                }

//                objAdapter.Fill( dsGolfESP,"RoundsPosted" );
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return;
//        }
//        //
//        public void InsertPDADataOutRecord(bool tour, int ID, bool player, int teetimeid, string destination)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            strSQL = @"INSERT INTO PDADataOut";
//            strSQL += @" (Destination, FileCreated, FileCopied, Terminate, Tournament, SendData, Player, TeeTimeID)";
//            strSQL += @" SELECT '" + (destination==""?"ALL":destination) + "' as Destination, ";
//            strSQL += @"No as FileCreated, No as FileCopied, No as Terminate,";
//            strSQL += (tour?"Yes":"No") + " as Tournament,";
//            strSQL += @ID.ToString() + " as SendData, ";
//            strSQL += (player?"Yes":"No") + " as Player, ";
//            strSQL += @teetimeid.ToString() + " as TeeTimeID";
//            objCommand.CommandText = strSQL;
//            objCommand.ExecuteNonQuery();

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }
//        //
//        public void TerminatePDADataOut(int ID)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            strSQL = @"UPDATE PDADataOut";
//            strSQL += @" SET Terminate = Yes";
//            strSQL += @" WHERE (SendData=" + ID.ToString() + ")";
//            objCommand.CommandText = strSQL;
//            objCommand.ExecuteNonQuery();

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }
//        //
//        public bool PDADataOutTerminated(int ID)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";
//            uint returnID = 0;

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            strSQL = @"SELECT PDADataOutID FROM PDADataOut";
//            strSQL += @" WHERE (SendData=" + ID.ToString() + ")";

//            objCommand.CommandText = strSQL;
//            object o = objCommand.ExecuteScalar();
//            if (o == null) returnID = 0;
//            else returnID = UInt32.Parse(o.ToString());

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//            if (returnID == 0) return true;
//            else return false;
//        }
//        //
//        public byte PDADataOutStatus(int ID)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";
//            byte retval = 0;
//            bool fileCreated = false;
//            bool fileCopied = false;

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            strSQL = @"SELECT FileCreated FROM PDADataOut";
//            strSQL += @" WHERE (SendData=" + ID.ToString() + ")";

//            objCommand.CommandText = strSQL;
//            object o = objCommand.ExecuteScalar();
//            if (o == null)
//            {
//                // Terminated
//                retval = 4;
//            }
//            else 
//            {
//                fileCreated = (o.ToString().ToLower() == "true"?true:false);
//            }

//            strSQL = @"SELECT FileCopied FROM PDADataOut";
//            strSQL += @" WHERE (SendData=" + ID.ToString() + ")";

//            objCommand.CommandText = strSQL;
//            o = objCommand.ExecuteScalar();
//            if (o == null)
//            {
//                // Terminated
//                retval = 4;
//            }
//            else 
//            {
//                fileCopied = (o.ToString().ToLower() == "true"?true:false);
//            }
//            if (fileCopied) retval = 3;
//            else if (fileCreated) retval = 2;
//            else retval = 1;

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//            return retval;
//        }

//        public bool GetTLRound(int tlid, int roundid)
//        {
//            // "Load TLRound" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;
//            bool retval = false;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM TournamentRounds";
//            strSQL = strSQL + @" WHERE (((RoundID)=" + roundid.ToString();
//            strSQL = strSQL + @") AND (TournamentID)=" + tlid.ToString();
//            strSQL = strSQL + @")";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TLRound"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            objAdapter.Fill( dsGolfESP,"TLRound" );

//            // get CourseID
//            DataTable dt;
//            DataRow[] dr;

//            dt = dsGolfESP.Tables["TLRound"];
//            dr = dt.Select();
//            if (dt.Rows.Count > 0)
//                retval = true;

//            dr = null;
//            dt = null;

//            // Close the conn
//            objConnection.Close();
//            objAdapter.Dispose();
//            objConnection.Dispose();

//            return retval;
//        }
//        public bool AddTLRound(int tlid, int roundid)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            OleDbCommand objCommand = new OleDbCommand();
//            bool retval = false;

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            strSQL = @"INSERT INTO TournamentRounds";
//            strSQL += @" (TournamentID, RoundID, ScorecardPrinted, Posted, Revised)";
//            strSQL += @" SELECT " + tlid.ToString() + " as TournamentID, ";
//            strSQL += @roundid.ToString() + " as RoundID, ";
//            strSQL += @"No as ScorecardPrinted, No as Posted, No as Revised";
//            objCommand.CommandText = strSQL;
//            if (objCommand.ExecuteNonQuery() > 0) retval = true;

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();

//            return retval;
//        }

//        //======TournamentDetails==========================
//        private string strSelectDetails = "";
//        private OleDbCommand UpdateDetails;
//        private OleDbCommand DeleteDetails;
//        private OleDbCommand InsertDetails;
//        public void GetTournamentDetails(int tournamentid)
//        {
//            // Load "TournamentDetails" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;
//            Guid tGUID;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM TournamentDetails";
//            DataTable dt = dsGolfESP.Tables["Tournaments"];
//            DataRow [] dr = dt.Select("TournamentID = " + tournamentid.ToString());
//            if (dr.Length > 0)
//            {
//                tGUID = (Guid)dr[0]["TournamentGUID"];

//                strSQL = strSQL + @" WHERE ((TournamentGUID)={" + tGUID.ToString("D")+"}";
//                strSQL = strSQL + @")";
//            }
//            else
//            {
//                strSQL = strSQL + @" WHERE ((TournamentGUID)={0000}";
//                strSQL = strSQL + @")";
//            }
//            strSQL += @" ORDER BY RoundDate, RoundNumber, StartingHole";
//            strSelectDetails = strSQL;

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of TournamentDetails
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TournamentDetails"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            try
//            {
//                objAdapter.Fill( dsGolfESP,"TournamentDetails" );
//            }
//            catch
//            {
//                // Most likely cause is no data, no error processing needed.
//            }

//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            DeleteDetails = tlg.GetDeleteCommand();
//            InsertDetails = tlg.GetInsertCommand();
//            UpdateDetails = tlg.GetUpdateCommand();

//            dr = null;
//            dt = null;
//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();
//        }

//        public void SaveTournamentDetailChanges()
//        {
//            // "Update TournamentDetails" to TournamentDetails Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            objConnection = new OleDbConnection(strConnection);

//            // Open the connection/data adapter
//            DeleteDetails.Connection = objConnection;
//            InsertDetails.Connection = objConnection;
//            UpdateDetails.Connection = objConnection;
//            objAdapter = new OleDbDataAdapter(strSelectRoundTimes, objConnection);
//            objAdapter.DeleteCommand = DeleteDetails;
//            objAdapter.InsertCommand = InsertDetails;
//            objAdapter.UpdateCommand = UpdateDetails;

//            try
//            {
//                objAdapter.Update( dsGolfESP,"TournamentDetails" );
//            }
//            catch
//            {
//                // Error Updating Record
//                int i = 0;
//            }

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();
//        }
//        //======TournamentDetails==========================
//        //
//        //======TournamentTeeTimes==========================
//        private string strSelectRoundTimes = "";
//        private OleDbCommand UpdateRoundTimes;
//        private OleDbCommand DeleteRoundTimes;
//        private OleDbCommand InsertRoundTimes;
//        /*
//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            objAdapter.DeleteCommand = tlg.GetDeleteCommand();
//            objAdapter.InsertCommand = tlg.GetInsertCommand();
//            objAdapter.UpdateCommand = tlg.GetUpdateCommand();
//        */
//        public void GetRoundTimes(int tournamentid)
//        {
//            // "Load RoundTeeTimes" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;
//            Guid tGUID;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM RoundTimes";
//            DataTable dt = dsGolfESP.Tables["Tournaments"];
//            DataRow [] dr = dt.Select("TournamentID = " + tournamentid.ToString());
//            if (dr.Length > 0)
//            {
//                tGUID = (Guid)dr[0]["TournamentGUID"];

//                strSQL = strSQL + @" WHERE ((TournamentGUID)={" + tGUID.ToString("D")+"}";
//                strSQL = strSQL + @")";
//            }
//            else
//            {
//                strSQL = strSQL + @" WHERE ((TournamentGUID)={0000}";
//                strSQL = strSQL + @")";
//            }
//            strSQL += @" ORDER BY TeeDate, TeeTime, HoleStart, HHset";
//            strSelectRoundTimes = strSQL;

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["RoundTeeTimes"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            try
//            {
//                objAdapter.Fill( dsGolfESP,"RoundTeeTimes" );
//            }
//            catch
//            {
//                // Most likely cause is no data, no error processing needed.
//            }

//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            DeleteRoundTimes = tlg.GetDeleteCommand();
//            InsertRoundTimes = tlg.GetInsertCommand();
//            UpdateRoundTimes = tlg.GetUpdateCommand();

//            // Add fields
//            dt = dsGolfESP.Tables["RoundTeeTimes"];
//            try
//            {
//                dt.Columns.Add("PlayerCount", Type.GetType("System.Int32"));
//                dt.Columns["PlayerCount"].DefaultValue = 0;
//            }
//            catch
//            {
//                // columns exist
//            }
//            // Initialize new Fields
//            int count = 0;
//            dr = dt.Select();
//            if (dr.Length > 0)
//            {
//                string field = "";
//                for (int i=0;i<dr.Length;i++)
//                {
//                    count = 0;
//                    for (int k=1;k<6;k++)
//                    {
//                        field = "P"+k.ToString()+"GUID";
//                        try
//                        {
//                            if ( dr[i][field] != System.DBNull.Value) count++;
//                        }
//                        catch
//                        {
//                            // not set
//                        }
//                    }
//                    dr[i].BeginEdit();
//                    dr[i]["PlayerCount"] = count;
//                    dr[i].EndEdit();
//                }
//            }

//            dr = null;
//            dt = null;
//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();

//            // Update PlayerMaster Using RoundTimes
//            this.UpdatePlayerMasterFromTeeTimes();
//        }
//        //
//        public void SaveRoundTimeChanges()
//        {
//            // "Update RoundTeeTimes" to RoundTimes Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            objConnection = new OleDbConnection(strConnection);

//            // Open the connection/data adapter
//            DeleteRoundTimes.Connection = objConnection;
//            InsertRoundTimes.Connection = objConnection;
//            UpdateRoundTimes.Connection = objConnection;
//            objAdapter = new OleDbDataAdapter(strSelectRoundTimes, objConnection);
//            objAdapter.DeleteCommand = DeleteRoundTimes;
//            objAdapter.InsertCommand = InsertRoundTimes;
//            objAdapter.UpdateCommand = UpdateRoundTimes;

//            try
//            {
//                objAdapter.Update( dsGolfESP,"RoundTeeTimes" );
//            }
//            catch
//            {
//                // Error Updating Record
//                int i = 0;
//            }

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();

//            // Update PlayerMaster Using RoundTimes
//            this.UpdatePlayerMasterFromTeeTimes();
//        }
//        //
//        public void GetCourseGUIDAndTeeNames()
//        {
//            // "Load PlayerMaster" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);
///*
//SELECT Tees.TeeName, Courses.GUID
//FROM Courses INNER JOIN Tees ON Courses.CourseID = Tees.CourseID
//ORDER BY Courses.CourseID, Tees.TeeName
//*/
//            strSQL = @"SELECT Tees.TeeName, Courses.GUID";
//            strSQL = strSQL + @" FROM Courses INNER JOIN Tees ON Courses.CourseID = Tees.CourseID";
//            strSQL = strSQL + @" ORDER BY Courses.CourseID, Tees.TeeName";

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["TeeNames"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            try
//            {
//                objAdapter.Fill( dsGolfESP,"TeeNames" );
//            }
//            catch
//            {
//                // Most likely cause is no data, no error processing needed.
//            }

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();
//        }
//        //
//        public void ClearUnitInTeeTimes(string unit)
//        {
//            DataTable dt = dsGolfESP.Tables["RoundTeeTimes"];
//            DataRow [] dr = dt.Select();
//            if (dr.Length > 0)
//            {
//                for (int i=0;i<dr.Length;i++)
//                {
//                    if (dr[i]["HHunit"].ToString() == unit)
//                    {
//                        dr[i].BeginEdit();
//                        dr[i]["HHunit"] = "";
//                        dr[i].EndEdit();
//                    }
//                }
//            }
//            dr = null;
//            dt = null;
//        }
//        //======TournamentTeeTimes==========================
//        //======RoundTimesPlayers Table============================
//        private string strSelectPlayers = "";
//        private OleDbCommand UpdatePlayers;
//        private OleDbCommand DeletePlayers;
//        private OleDbCommand InsertPlayers;
//        public void GetRoundTimesPlayers()
//        {
//            // "Load RoundTimesPlayers" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM RoundTimesPlayers";
//            strSQL = strSQL + @" ORDER BY RoundTimeGUID, HHPosition";
//            strSelectPlayers = strSQL;

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["RoundTimesPlayers"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            try
//            {
//                objAdapter.Fill( dsGolfESP,"RoundTimesPlayers" );
//            }
//            catch
//            {
//                // Most likely cause is no data, no error processing needed.
//            }

//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            DeletePlayers = tlg.GetDeleteCommand();
//            InsertPlayers = tlg.GetInsertCommand();
//            UpdatePlayers = tlg.GetUpdateCommand();

//            // Add fields
//            DataTable dt = dsGolfESP.Tables["RoundTimesPlayers"];
//            try
//            {
//                dt.Columns.Add("Name", Type.GetType("System.String"));
//                dt.Columns.Add("DisplayGender", Type.GetType("System.String"));
//                dt.Columns["Name"].DefaultValue = "";
//                dt.Columns["DisplayGender"].DefaultValue = "";
//            }
//            catch
//            {
//                // columns exist
//            }
//            // Initialize new Fields
//            DataRow [] dr = dt.Select();
//            DataTable dtp = dsGolfESP.Tables["PlayerMaster"];
//            DataRow []drp;
//            Guid g;
//            if (dr.Length > 0)
//            {
//                for (int i=0;i<dr.Length;i++)
//                {
//                    dr[i].BeginEdit();
//                    try
//                    {
//                        g = (Guid)dr[i]["PlayerMasterGUID"];
//                        drp = dtp.Select("PlayerMasterGUID='"+g.ToString("D")+"'");
//                        dr[i]["Name"] = drp[0]["LastName"].ToString() + ", " + drp[0]["FirstName"].ToString();
//                        if ((byte)drp[0]["Gender"] == 0)
//                            dr[i]["DisplayGender"] = "Male";
//                        else
//                            dr[i]["DisplayGender"] = "Female";
//                    }
//                    catch
//                    {
//                        dr[i]["Name"] = "";
//                        dr[i]["DisplayGender"] = "";
//                    }
//                    dr[i].EndEdit();
//                }
//            }
//            dr = null;
//            dt = null;

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();
//        }

//        public void SaveRoundTimesPlayersChanges()
//        {
//            // "Update RoundTimesPlayers" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            objConnection = new OleDbConnection(strConnection);

//            // Open the connection/data adapter
//            DeletePlayers.Connection = objConnection;
//            UpdatePlayers.Connection = objConnection;
//            InsertPlayers.Connection = objConnection;
//            objAdapter = new OleDbDataAdapter(strSelectPlayers, objConnection);
//            objAdapter.DeleteCommand = DeletePlayers;
//            objAdapter.InsertCommand = InsertPlayers;
//            objAdapter.UpdateCommand = UpdatePlayers;

//            objAdapter.Update( dsGolfESP,"RoundTimesPlayers" );

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();
//        }
//        public void DeleteFromRoundTimesPlayersTable(Guid rtg)
//        {
//            OleDbConnection objConnection = new OleDbConnection(GetConnection());
//            //OleDbDataAdapter objAdapter = null;
//            OleDbCommand objCommand = new OleDbCommand();

//            string strSQL = "";

//            // Set up Command
//            objCommand.Connection = objConnection;
//            objCommand.CommandType = CommandType.Text;

//            // Open the connection
//            objConnection.Open();

//            try
//            {
//                // Get Delete the import record in PDADATAIN
//                strSQL = "DELETE RoundTimesPlayers.*, RoundTimesPlayers.RoundTimeGUID";
//                strSQL += " FROM RoundTimesPlayers";
//                strSQL += " WHERE (((RoundTimesPlayers.RoundTimeGUID)="+rtg.ToString("B")+"))";

//                objCommand.CommandText = strSQL;
//                objCommand.ExecuteNonQuery();
//            }
//            catch
//            {
//                // No Error processing if no records to remove.
//            }

//            // Update the DataSet
//            GetRoundTimesPlayers();

//            // Close the conn
//            objConnection.Close();
//            objCommand.Dispose();
//            objConnection.Dispose();
//        }

//        //======RoundTimesPlayers Table============================
//        //======PlayerMaster Table============================
//        private string strSelectPlayerMaster = "";
//        private OleDbCommand UpdatePlayerMaster;
//        private OleDbCommand DeletePlayerMaster;
//        private OleDbCommand InsertPlayerMaster;
//        public void GetPlayerMaster()
//        {
//            // "Load PlayerMaster" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            string strSQL = "";
//            objConnection = new OleDbConnection(strConnection);

//            strSQL = @"SELECT *";
//            strSQL = strSQL + @" FROM PlayerMaster";
//            strSQL = strSQL + @" ORDER BY LastName, FirstName";
//            strSelectPlayerMaster = strSQL;

//            // Open the connection/data adapter
//            objAdapter = new OleDbDataAdapter(strSQL, objConnection);

//            // Fill the datset with a table of Players
//            // Make sure that the table is empty before updating with new data.
//            try
//            {
//                dsGolfESP.Tables["PlayerMaster"].Clear();
//            }
//            catch
//            {
//                // Table was not yet created, no error processing needed.
//            }

//            try
//            {
//                objAdapter.Fill( dsGolfESP,"PlayerMaster" );
//            }
//            catch
//            {
//                // Most likely cause is no data, no error processing needed.
//            }

//            // set the Delete/Insert/Update commands
//            OleDbCommandBuilder tlg = new OleDbCommandBuilder(objAdapter);
//            DeletePlayerMaster = tlg.GetDeleteCommand();
//            InsertPlayerMaster = tlg.GetInsertCommand();
//            UpdatePlayerMaster = tlg.GetUpdateCommand();

//            // Add fields
//            DataTable dt = dsGolfESP.Tables["PlayerMaster"];
//            try
//            {
//                dt.Columns.Add("Assigned", Type.GetType("System.Boolean"));
//                dt.Columns.Add("DisplayGender", Type.GetType("System.String"));
//                dt.Columns.Add("TeeTimeID", Type.GetType("System.Int32"));
//                dt.Columns["Assigned"].DefaultValue = false;
//                dt.Columns["DisplayGender"].DefaultValue = "";
//                dt.Columns["TeeTimeID"].DefaultValue = 0;
//            }
//            catch
//            {
//                // columns exist
//            }
//            // Initialize new Fields
//            DataRow [] dr = dt.Select();
//            if (dr.Length > 0)
//            {
//                for (int i=0;i<dr.Length;i++)
//                {
//                    dr[i]["Assigned"] = false;
//                    if ((byte)dr[i]["Gender"] == 0) dr[i]["DisplayGender"] = "Male"; else dr[i]["DisplayGender"] = "Female";
//                    dr[i]["TeeTimeID"] = 0;
//                }
//            }
//            dr = null;
//            dt = null;

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();

//            // Update PlayerMaster Using RoundTimes
//            this.UpdatePlayerMasterFromTeeTimes();
//        }

//        public void SavePlayerMasterChanges()
//        {
//            // "Update PlayerMaster" Table
//            OleDbConnection objConnection = null;
//            OleDbDataAdapter objAdapter = null;

//            // Get conn String
//            string strConnection = GetConnection();
//            objConnection = new OleDbConnection(strConnection);

//            // Open the connection/data adapter
//            DeletePlayerMaster.Connection = objConnection;
//            UpdatePlayerMaster.Connection = objConnection;
//            InsertPlayerMaster.Connection = objConnection;
//            objAdapter = new OleDbDataAdapter(strSelectPlayerMaster, objConnection);
//            objAdapter.DeleteCommand = DeletePlayerMaster;
//            objAdapter.InsertCommand = InsertPlayerMaster;
//            objAdapter.UpdateCommand = UpdatePlayerMaster;

//            objAdapter.Update( dsGolfESP,"PlayerMaster" );

//            // Close the conn
//            objConnection.Close();
//            objConnection.Dispose();
//        }
//        private void UpdatePlayerMasterFromTeeTimes()
//        {
//            DataTable dt = dsGolfESP.Tables["PlayerMaster"];
//            if (dt == null) return;
//            DataRow [] dr = dt.Select();
//            //
//            DataTable dt2 = dsGolfESP.Tables["RoundTeeTimes"];
//            if (dt2 == null) return;
//            DataRow [] dr2  = dt2.Select();
//            //
//            if (dr.Length > 0)
//            {
//                // There are PlayerMaster records
//                if (dr2.Length > 0)
//                {
//                    // There Are TeeTimes
//                    // Update PlayerMaster records from TeeTime records
//                    string field = "";
//                    for (int i=0;i<dr.Length;i++)
//                    {
//                        for (int j=0;j<dr2.Length;j++)
//                        {
//                            if ((int)dr2[j]["PlayerCount"] > 0)
//                            {
//                                for (int k=1;k<6;k++)
//                                {
//                                    field = "P"+k.ToString()+"GUID";
//                                    try
//                                    {
//                                        if (dr2[j][field] == System.DBNull.Value)
//                                        {
//                                            break;
//                                        }
//                                        else
//                                        {
//                                            // See if GUID matches current Player
//                                            if ((Guid)dr2[j][field] == (Guid)dr[i]["PlayerMasterGUID"])
//                                            {
//                                                dr[i].BeginEdit();
//                                                dr[i]["Assigned"] = true;
//                                                dr[i]["TeeTimeID"] = dr2[j]["RoundTimeID"];
//                                                dr[i].EndEdit();
//                                            }
//                                        }
//                                    }
//                                    catch
//                                    {
//                                        // not set
//                                        break;
//                                    }
//                                } // for k
//                            }
//                        } // for j
//                    } // for i
//                }
//                else
//                {
//                    // Make sure all Flags and IDs are cleared as there are no TeeTime Records yet
//                    for (int i=0;i<dr.Length;i++)
//                    {
//                        dr[i].BeginEdit();
//                        dr[i]["Assigned"] = false;
//                        dr[i]["TeeTimeID"] = 0;
//                        dr[i].EndEdit();
//                    }
//                }
//            }
//            //
//            dr2 = null;
//            dt2 = null;
//            dr = null;
//            dt = null;
//        }
//        public void SetPlayerMasterAssignedFlag(int rowindex, bool assigned)
//        {
//            DataTable dt = dsGolfESP.Tables["PlayerMaster"];
//            DataRow dr = dt.Rows[rowindex];
//            //
//            dr.BeginEdit();
//            dr["Assigned"] = assigned;
//            dr.EndEdit();
//            //
//            dr = null;
//            dt = null;
//        }
//        //======PlayerMaster Table============================

//        ///////////////////////////////////////////////////////////////////////
//        //  IsTeamGame - is this a team game?
//        //  Input:  none
//        //  Output: none
//        //  Return: 
//        //  Notes:	returns true if we're working on a team game
//        ///////////////////////////////////////////////////////////////////////
//        public bool IsTeamGame()
//        {
//            return cGames[g_State.CurrentGame].TeamGame;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetMaxTees - gets the maximum number of tees in our database
//        //  Input:  none
//        //  Output: none
//        //  Return: returns the number of tees we have
//        //  Notes:	
//        ///////////////////////////////////////////////////////////////////////
//        public byte GetMaxTees()
//        {
//            return cCourse.NumTees;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetMaxPlayers - gets the maximum number of players allowed on this course
//        //  Input:  none
//        //  Output: none
//        //  Return: returns the max number of allowed players
//        //  Notes:	
//        ///////////////////////////////////////////////////////////////////////
//        public byte GetMaxPlayers()
//        {
//            return cCourse.MaxPlayers;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetDefaultHandicapType - gets the default handicap type for this course
//        //  Input:  none
//        //  Output: none
//        //  Return: returns the default handicap type
//        //  Notes:	
//        ///////////////////////////////////////////////////////////////////////
//        public HANDICAP_TYPE GetDefaultHandicapType()
//        {
//            return cCourse.DefaultHandicapType;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetTeeInfo - gets a locked down pointer to the specified tees
//        //  Input:  Index - the index to get(TeeID in Appliance)
//        //  Output: tee data record
//        //  Return: NULL on failure
//        //  Notes:	modified from PALM
//        ///////////////////////////////////////////////////////////////////////
//        public TEE_INFORMATION GetTeeInfo(uint Index)
//        {
//            // Locate Tee Record in Class Array
//            for (int i=0;i<cTees.Length;i++)
//            {
//                if (cTees[i].TeeID == Index)
//                {
//                    // Return Tee Data Record
//                    return cTees[i];
//                }
//            }

//            // return a null pointer
//            return null;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetPlayerInfo - gets the specified player
//        //  Input:  Index - the index of the player data to get
//        //  Output: Player Data record
//        //  Return: NULL on failure
//        //  Notes:	modified from PALM
//        ///////////////////////////////////////////////////////////////////////
//        public PLAYER_INFORMATION GetPlayerInfo(byte Index)
//        {
//            // check Index (array subscript)
//            if ((Index <0) | (Index >= cPlayers.Length)) 
//            {
//                return null;
//            } 

//            // return player data record
//            return cPlayers[Index];
//        }

//        public byte GetPlayerIndexFromID(int id)
//        {
//            for (byte i=0;i<g_State.NumPlayers;i++)
//            {
//                if (cPlayers[i].PlayerID == id)
//                    return i;
//            } 

//            // return INVALID player index
//            return 5;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  WriteToPlayer - store the specified player data
//        //  Input:  Index - the index of the player data to store
//        //             Player - player data to store
//        //  Output: cPlayer
//        //  Return: <none>
//        //  Notes:	New
//        ///////////////////////////////////////////////////////////////////////
//        public void WriteToPlayer(PLAYER_INFORMATION Player, byte Index)
//        {
//            cPlayers[Index] = Player;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  WriteToGame - store the specified game data
//        //  Input:  Index - the index of the game data to store
//        //             Game - game data to store
//        //  Output: cGame
//        //  Return: <none>
//        //  Notes:	New
//        ///////////////////////////////////////////////////////////////////////
//        public void WriteToGame(GAME_INFORMATION Game, byte Index)
//        {
//            cGames[Index] = Game;
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetGame - gets the specified game
//        //  Input:  Index - the index of game to get
//        //  Output: game information for specified game index
//        //  Return: NULL on failure
//        //  Notes:	different definition than PALM (of the same name)
//        ///////////////////////////////////////////////////////////////////////
//        public GAME_INFORMATION GetGame(byte Index)
//        {
//            // fetch their record
//            if ((Index < 0) | (Index >= cGames.Length)) 
//            {
//                return null;
//            } 

//            // return game information
//            return cGames[Index];
//        }

//        ///////////////////////////////////////////////////////////////////////
//        //  GetInitials - gets the initials for a player
//        //  Input:  Index - the index of the player
//        //  Output: pStr - the initials
//        //  Return: none
//        //  Notes:	
//        ///////////////////////////////////////////////////////////////////////
//        public void GetInitials(byte Index, ref string pStr)
//        {
//            // check Index (array subscript)
//            if ((Index <0) | (Index >= cPlayers.Length)) 
//            {
//                pStr = "";
//                return;
//            }

//            pStr = cPlayers[Index].Initials;
//        }

		//================================
	}
}
