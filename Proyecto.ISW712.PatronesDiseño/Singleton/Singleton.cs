namespace Proyecto.ISW712.PatronesDiseño.Singleton
{
    public class Singleton
    {
        private static Singleton instance = null;
        private Dictionary<string, string> motores_bd = new Dictionary<string, string>();
        private Dictionary<string, string> cadenas_conexion = new Dictionary<string, string>();
        private string bd_actual;

        private Singleton()
        {
            bd_actual = "db1";
            motores_bd = new Dictionary<string, string>();
            cadenas_conexion = new Dictionary<string, string>();

            motores_bd.Add("db1", "MSSql");
            cadenas_conexion.Add("db1", "conexionMSSql");
            motores_bd.Add("db2", "PgSql");
            cadenas_conexion.Add("db2", "conexionPgSql");
            motores_bd.Add("db3", "MySql");
            cadenas_conexion.Add("db3", "conexionMySql");
        }

        public Dictionary<string, string> Motores_bd { get => motores_bd; set => motores_bd = value; }
        public Dictionary<string, string> Cadenas_conexion { get => cadenas_conexion; set => cadenas_conexion = value; }
        public string Bd_actual { get => bd_actual; set => bd_actual = value; }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
         public Dictionary<string, string> GetCurrentDbData()
    {
        Dictionary<string, string> currentDbData = new Dictionary<string, string>();

        if (motores_bd.ContainsKey(bd_actual))
        {
            currentDbData.Add("motor_bd", motores_bd[bd_actual]);
        }

        if (cadenas_conexion.ContainsKey(bd_actual))
        {
            currentDbData.Add("cadena_conexion", cadenas_conexion[bd_actual]);
        }

        return currentDbData;
    }



    }
}
