namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetBetAreaResponse : ResponseBase<List<GetBetAreaResponseData>>
    {

    }

    public class GetBetAreaResponseData
    {
        public GameTypeEnum GameId
        {
            get
            {
                if (Enum.TryParse(this.GameName, out GameTypeEnum gameResult))
                {
                    return gameResult;
                }
                else
                {
                    return 0;
                }
            }
        }
        public string GameName { get; set; }
        public string BetArea { get; set; }
        public string Context { get; set; }
        public string Lang { get; set; }
    }

    public enum GameTypeEnum
    {
        // NewGame 新增遊戲 - 加入新的GameID

        Bacc = 1,

        InsuBacc = 6,

        LongHu = 2,

        LunPan = 3,

        PokDeng = 7,

        FanTan = 5,

        ShaiZi = 4,

        SamBo = 9,

        BullBull = 8,

        RgRacing = 10,

        BCBacc = 11,

        BCLongHu = 12,

        AndarBahar = 15,

        SeDie = 16,

        HiLo = 17,

        BCSDD = 18
    }
}
