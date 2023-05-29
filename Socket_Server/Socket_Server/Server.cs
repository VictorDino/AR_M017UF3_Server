class Server
{
    static void Main(string[] args)
    {
        bool bServerOn = true;

        //Instanciamos el manager de red y esta inicia la BDD
        Network_Manager Network_Service = new Network_Manager();

        //Iniciamos los servicios del servidor, actualmente solo tenemos los servicios de red pero en un futuro tendremos BBDD
        StartServices();

        //Mantenemos el servidor iniciado con un bucle "infinito"
        while (bServerOn)
        {
            //Comprobamos conexiones
            Network_Service.CheckConnection();
            //Desconectamos usuarios
            Network_Service.DisconnectClients();
            //Comprobamos mensajes
            Network_Service.CheckMessage();

        }

        CloseServices();


        void StartServices()
        {
            //Iniciamos todos los servicios existentes, en este caso solo el red
            Network_Service.Start_Network_Service();
        }

        void CloseServices()
        {
            //Cerramos conecion de la BDD
            Network_Service.Close_DB_Connection();
        }
    }
}