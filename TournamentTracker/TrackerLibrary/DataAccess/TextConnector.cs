﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // Add the new record with the new ID (max + 1).
            model.Id = currentId;
            // Convert the prizes to list<string>.
            people.Add(model);
            // Save the list<string> to the text file.
            people.SaveToPeopleFile(PeopleFile);
            // Return the new person with the ID.
            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            // Find the ID.
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // Add the new record with the new ID (max + 1).
            model.Id = currentId;

            // Convert the prizes to list<string>.
            teams.Add(model);

            // Save the list<string> to the text file.
            teams.SaveToTeamFile(TeamFile);

            // Return the new person with the ID.
            return model;

        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);

            // Find the ID.
            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // Add the new record with the new ID (max + 1).
            model.Id = currentId;

            // Convert the prizes to list<string>.
            tournaments.Add(model);

            // Save the list<string> to the text file.
            tournaments.SaveToTournamentFile(TournamentFile);

            // Return the new person with the ID.
            return model;
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        // TODO: Wire up the CreatePrize for text files.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file.
            // Convert the text to List<PrizeModel>.
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            // Find the MAX ID
            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            model.Id = currentId;

            // Add the new record with the new ID (max + 1).
            prizes.Add(model);


            // Convert the prizes to list<string>.
            // Save the list<string> to the text file.
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
