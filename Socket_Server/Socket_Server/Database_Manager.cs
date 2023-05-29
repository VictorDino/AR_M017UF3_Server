using MySql.Data.MySqlClient;

class Database_Manager
{
    public MySqlConnection Start_DB_Connection()
    {
        //String con los datos de conexion
        const string connectionString = "Server=db4free.net;Port=3306;database=proyecto_online;Uid=victorblazquez;password=Canela.98;SSL Mode=None;connect timeout=3600;default command timeout = 3600;";

        //Clase encargada de la conexion
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            //Abro conexion
            connection.Open();
        }
        catch (Exception ex)
        {
            //Gestiono posibles errores de conexiÃ³n.
            Console.WriteLine(ex.Message);
        }

        return connection;
    }

    public void Close_DB_Connection(MySqlConnection connection)
    {
        //Cierro conexion
        connection.Close();
    }


    //Funcion para eliminar datos "Hardcoded"
    public void DeleteExample(MySqlConnection connection)
    {
        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = connection.CreateCommand();

        //AÃ±ado en el atributo de la clase la query a realizar
        command.CommandText = "DELETE FROM users Where Player.Id = 5;";

        try
        {
            //Ejecuto la instrucciÃ³n, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    //Funcion optimizada de select, recibe por parametro la query de la consulta y que campo debe devolver
    public List<string> OptimizedStringSelect(MySqlConnection connection, string commandString, string returnedRow)
    {
        //Creo el reader para leer los datos
        MySqlDataReader reader;

        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = connection.CreateCommand();

        //AÃ±ado en el atributo de la clase la query a realizar
        command.CommandText = commandString;

        //Variable para almacenar temporalmente los datos
        List<string> tmp = new List<string>();

        try
        {
            //Creo el reader para leer los datos
            reader = command.ExecuteReader();

            //Mientras haya datos voy leyendo
            while (reader.Read())
            {
                //Almaceno el dato
                tmp.Add(reader[returnedRow].ToString());
            }

            //Devuelvo los datos
            reader.Close();
            return tmp;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return tmp;
        }
    }

    //Funcion de ejecutar consultas genericas asincronas, es decir, que no necesito esperar respuesta de la base de datos
    public void OptimizedExecuteCommandExample(MySqlConnection connection, string commandString)
    {
        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = connection.CreateCommand();

        //Almaceno la query recibida por parametro.
        command.CommandText = commandString;

        try
        {
            //Ejecuto la instrucciÃ³n, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void OptimizedInsert(MySqlConnection connection, string commandString)
    {
        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = connection.CreateCommand();
        
        //AÃ±ado en el atributo de la clase la query a realizar
        command.CommandText = commandString;
        try
        {
            //Ejecuto la instrucciÃ³n, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
            command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //Funcion de insert con la query "Hardcoded"
    public void InsertExample(MySqlConnection connection)
    {
        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = connection.CreateCommand();

        //AÃ±ado en el atributo de la clase la query a realizar
        command.CommandText = "Insert Into users (nick, pass, raza_id) Values ('Pepe', '123456', 1);";
        try
        {
            //Ejecuto la instrucciÃ³n, el NonQuery() evita que el programa se interrumpa y espere respuesta de SQL
            command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //Funcion de select con la query "Hardcoded"
    public void SelectExample(MySqlConnection connection)
    {

        //Creo el reader para leer los datos
        MySqlDataReader reader;

        //Creo la instruccion que quiero ejecutar de SQL (clase)
        MySqlCommand command = connection.CreateCommand();

        //AÃ±ado en el atributo de la clase la query a realizar
        command.CommandText = "Select * from users";

        try
        {
            //Ejecuto la query (SQL es asincrono, respondera cuando quiera), interrumpe el programa hasta recibir respuesta.
            reader = command.ExecuteReader();

            //reader.Read() devuelve true mientras haya algo que leer.
            while (reader.Read())
            {
                //Puedo leer el reader como un array [0], [1]... o directamente los campos que devuelve my query.
                Console.WriteLine(reader["nick"].ToString());
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex);
        }
    }
}