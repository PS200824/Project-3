using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace verkiezingPartijProject3.Classes
{
    class beheerDB
    {
        MySqlConnection _dbConnect = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        // ___________________________________ Partij __________________________________________

        //_______ Select Partij _________
        public DataTable SelectPartij()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM Partij;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _dbConnect.Close();
            }
            return result;
        }

        //_____________ CREATE ________________

        public bool InsertPartij(string naam, string adres, string postcode, string gemeente, string emailadres, string telefoonnummer)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "INSERT INTO `partij` (`partij_id`, `naam`, `adres`, `postcode`, `gemeente`, `emailadres`, `telefoonnummer`) VALUES (NULL, @naam, @adres, @postcode, @gemeente, @emailadres, @telefoonnummer)";
                command.Parameters.AddWithValue("@naam", naam);
                command.Parameters.AddWithValue("@adres", adres);
                command.Parameters.AddWithValue("@postcode", postcode);
                command.Parameters.AddWithValue("@gemeente", gemeente);
                command.Parameters.AddWithValue("@emailadres", emailadres);
                command.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        //_____________ Update ____________

        public bool UpdatePartij(string id, string naam, string adres, string postcode, string gemeente, string emailadres, string telefoonnummer)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "UPDATE `partij` SET `naam` = @naam, `adres` = @adres, `postcode` = @postcode, `gemeente` = @gemeente, `emailadres` = @emailadres, `telefoonnummer` = @telefoonnummer WHERE `partij`.`partij_id` = @id;";
                command.Parameters.AddWithValue("@naam", naam);
                command.Parameters.AddWithValue("@adres", adres);
                command.Parameters.AddWithValue("@postcode", postcode);
                command.Parameters.AddWithValue("@gemeente", gemeente);
                command.Parameters.AddWithValue("@emailadres", emailadres);
                command.Parameters.AddWithValue("@telefoonnummer", telefoonnummer);
                command.Parameters.AddWithValue("@id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        // ______________ Delete __________________

        public bool DeletePartij(string partij_id)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "DELETE FROM `partij` WHERE `partij`.`partij_id` = @partij_id;";
                command.Parameters.AddWithValue("@partij_id", partij_id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        // ___________________________________ Thema __________________________________________

        //_______ Select Thema _________
        public DataTable SelectThema()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM thema;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {


            }
            finally
            {
                _dbConnect.Close();
            }
            return result;
        }

        //_____________ CREATE ________________

        public bool InsertThema(string thema)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "INSERT INTO `thema` (`thema_id`, `thema`) VALUES (NULL, @thema)";
                command.Parameters.AddWithValue("@thema", thema);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        //_____________ Update ____________

        public bool UpdateThema(string id, string thema)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "UPDATE `thema` SET `thema` = @thema WHERE `thema`.`thema_id` = @id;";
                command.Parameters.AddWithValue("@thema", thema);
                command.Parameters.AddWithValue("@id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        // ______________ Delete __________________

        public bool DeleteThema(string thema_id)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "DELETE FROM `thema` WHERE `thema`.`thema_id` = @thema_id;";
                command.Parameters.AddWithValue("@thema_id", thema_id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        // ___________________________________ Partij_Standpunten __________________________________________


        //_______ Select [Standpunt] _________
        public DataTable SelectStandpunt()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM standpunt;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {


            }
            finally
            {
                _dbConnect.Close();
            }
            return result;
        }

        //_______ Select Partij_Standpunten _________
        public DataTable SelectStandpunten()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM partij_standpunt INNER JOIN standpunt ON partij_standpunt.standpunt_id = standpunt.standpunt_id JOIN partij ON partij_standpunt.partij_id = partij.partij_id JOIN thema ON thema.thema_id = standpunt.thema_id";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                _dbConnect.Close();
            }
            return result;

            


            /*
             * standpunt
                4- SELECT* FROM `partij` WHERE `thema_id` = 2(int thema_id) if int is not NULL / 0
                3- put selected thema_id in INT thema_id
                2- SELECT `thema_id` FROM `thema` WHERE `thema` = (string => selected thema)
                1- Show thema's

                Partij
                Add thema combobox in beheer partij => show names in interface and save id in database
            */
        }

        // ___________________________________ Verkiezingsoorten __________________________________________

        //MIKE

        //_______ Select Verkiezingsoorten _________
        public DataTable SelectVerkiezingsoorten()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezingsoort;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {


            }
            finally
            {
                _dbConnect.Close();
            }
            return result;
        }

        //_____________ CREATE ________________

        public bool InsertVerkiezingsoorten(string verkiezingsoort)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "INSERT INTO `verkiezingsoort` (`verkiezingsoort`) VALUES (@verkiezingsoort)";
                command.Parameters.AddWithValue("@verkiezingsoort", verkiezingsoort);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        // ______________ Delete __________________

        public bool DeleteVerkiezingsoort(string verkiezingsoort_id)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "DELETE FROM verkiezingsoort WHERE verkiezingsoort.verkiezingsoort_id = @verkiezingsoort_id";
                command.Parameters.AddWithValue("@verkiezingsoort_id", verkiezingsoort_id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        //_____________ Update ____________

        public bool UpdateVerkiezingsoort(string id, string verkiezingsoort)
        {
            bool succes = false;
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "UPDATE `verkiezingsoort` SET `verkiezingsoort` = @verkiezingsoort WHERE `verkiezingsoort`.`verkiezingsoort_id` = @id;";
                command.Parameters.AddWithValue("@verkiezingsoort", verkiezingsoort);
                command.Parameters.AddWithValue("@id", id);
                int nrOfRowsAffected = command.ExecuteNonQuery();
                succes = (nrOfRowsAffected != 0);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _dbConnect.Close();
            }
            return succes;
        }

        // ___________________________________ VerkiezingsPartij __________________________________________

        //_______ Select VerkiezingsPartij _________
        public DataTable SelectVerkiezingsPartij()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM partij_verkiezing;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {


            }
            finally
            {
                _dbConnect.Close();
            }
            return result;
        }

        // ___________________________________ Verkiezingen __________________________________________

        //_______ Select Verkiezingen _________
        public DataTable SelectVerkiezingen()
        {
            DataTable result = new DataTable();
            try
            {
                _dbConnect.Open();
                MySqlCommand command = _dbConnect.CreateCommand();
                command.CommandText = "SELECT * FROM verkiezing;";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {


            }
            finally
            {
                _dbConnect.Close();
            }
            return result;
        }
    }
}
