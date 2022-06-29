<?php
class dbHandler
{
    const DATASOURCE = 'mysql:dbname=verkiezingenprj3;host=localhost';
    const USERNAME = 'root';
    const PASSWORD = '';

function selectAll()
    {
        try {
            $pdo = new PDO(self::DATASOURCE, self::USERNAME, self::PASSWORD);

            $statement = $pdo->prepare('SELECT * FROM partij');
            $statement->execute();
            $rows = $statement->fetchAll();

            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    function selectThema()
    {
        try {
            $pdo = new PDO(self::DATASOURCE, self::USERNAME, self::PASSWORD);

            $statement = $pdo->prepare('SELECT * FROM thema');
            $statement->execute();
            $rows = $statement->fetchAll();

            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    function selectStandpuntThema()
    {
        try {
            $pdo = new PDO(self::DATASOURCE, self::USERNAME, self::PASSWORD);

            $statement = $pdo->prepare('SELECT * FROM partij_standpunt INNER JOIN standpunt ON partij_standpunt.standpunt_id = standpunt.standpunt_id JOIN thema ON thema.thema_id = standpunt.thema_id');
            $statement->execute();
            $rows = $statement->fetchAll();

            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    function selectMening($mening)
    {
        try {
            $pdo = new PDO(self::DATASOURCE, self::USERNAME, self::PASSWORD);

            $statement = $pdo->prepare('INSERT INTO partij_standpunt(mening) VALUES (:mening) WHERE id = ?');
            $statement->bindParam('mening',$mening);
            $statement->execute();
            $rows = $statement->fetchAll();

            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }
    

    // function selectStandpunt()
    // {
    //     try {
    //         $pdo = new PDO(self::DATASOURCE, self::USERNAME, self::PASSWORD);

    //         $statement = $pdo->prepare('SELECT * FROM standpunt ');
    //         $statement->execute();
    //         $rows = $statement->fetchAll();

    //         return $rows;
    //     } catch (PDOException $e) {
    //         return false;
    //     }
    // }
    
}