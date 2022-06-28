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
    
}