namespace Conservation.WepAPI.DbSetting
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConservationCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
