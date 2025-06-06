﻿using NBA_League.domain;
using NBA_League.repository;
using NBA_League.exceptions;
using NBA_League.validator;

namespace NBA_League.service;

class ActivePlayerService
{
    private Repository<Tuple<int, int>, ActivePlayer> activePlayerRepo;
    private Repository<int,Player>playerRepo;
    private Validator<ActivePlayer> activePlayerValidator;
    public ActivePlayerService(Repository<Tuple<int,int>,ActivePlayer> activePlayerRepo,Repository<int,Player>playerRepo,Validator<ActivePlayer>activePlayerValidator)
    {
        this.activePlayerRepo = activePlayerRepo;
        this.playerRepo = playerRepo;
        this.activePlayerValidator = activePlayerValidator; 
    }
    public IEnumerable<ActivePlayer>GetActivePlayersFromGame(Game game)
    {
        List<ActivePlayer> activePlayers = this.GetAll().ToList();
        var result = activePlayers.Where(a => a.GameID.Equals(game.Id));
        return result.ToList();
    }
    public IEnumerable<ActivePlayer>GetAllActivePlayersFromGameAndTeam(Game game, Team team)
    {
        if (!game.FirstTeam.Name.Equals(team.Name) && !game.SecondTeam.Name.Equals(team.Name))
            throw new ServiceException(team.Name + " doesn't play in this game!");
        List<Player> allplayers = this.playerRepo.FindAll().ToList();
        List<ActivePlayer> allactivePlayers = this.GetAll().ToList();
        var result = from players in allplayers
            join activePlayers in allactivePlayers on players.Id equals activePlayers.Id.Item1
            where activePlayers.GameID.Equals(game.Id) && players.Team.Name.Equals(team.Name)
            select activePlayers;
        return result.ToList();
    }
    public IEnumerable<ActivePlayer> GetAll()
    {
        return this.activePlayerRepo.FindAll().ToList();
    }
}