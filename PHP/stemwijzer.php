<?php
include_once 'classes/dbHandler.php';

$dbHandler = new dbHandler();
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico">
    <link rel="stylesheet" href="css/nav.css">
    <link rel="stylesheet" href="css/styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>Stemwijzer | Stemwijzer</title>
</head>

<body>
    <div class="gridcontainer">
        <div class="topnav" id="myTopnav">
            <a id="homeBtn" href="index.php"><img src="assets/logo.png" alt="logo stemwijzer"></a>
            <a href="partijen.php">Partijen</a>
            <a href="themas.php">Thema's</a>
            <a href="stemwijzer.php" class="active">Stemwijzer</a>
            <!-- Voor responsive nav het icoontje om het menu uit te klappen -->
            <a href="javascript:void(0);" class="icon" onclick="myFunction()">
                <i class="fa fa-bars"></i></a>
        </div>

        <script>
            //Functie voor het uitklapmenu bij responsive nav doormiddel van classes
            function myFunction() {
                var x = document.getElementById("myTopnav");
                if (x.className === "topnav") {
                    x.className += " responsive";
                } else {
                    x.className = "topnav";
                }
            }
        </script>
        <article>
            <h2>Thema</h2>

            <table>
            <tr>
                <th>Standpunt</th>
                <th>Eens</th>
                <th>Oneens</th>
            </tr>
            <?php $dataArray = $dbHandler->selectStandpuntThema();

            for ($rowCounter = 0; $rowCounter < count($dataArray); $rowCounter++) {
            ?>
                <tr>
                    <td><?= $dataArray[$rowCounter]["standpunt"] ?></td>
                    <td><input type="radio"></td>
                    <td><input type="radio"></td>
                </tr>
            <?php
            }
            ?>
            <?php
                if (isset($_GET['standpunt_id'])) {
                    // MySQL query that selects the poll records by the GET request "id"
                    $stmt = $pdo->prepare('SELECT * FROM partij_standpunt WHERE standpunt_id = ?');
                    $stmt->execute([ $_GET['standpunt_id'] ]);
                    // Fetch the record
                    $poll = $stmt->fetch(PDO::FETCH_ASSOC);
                    // Check if the poll record exists with the id specified
                    if ($poll) {
                        // MySQL query that selects all the poll answers
                        $stmt = $pdo->prepare('SELECT * FROM partij_standpunt WHERE mening = ?');
                        $stmt->execute([ $_GET['standpunt_id'] ]);
                        // Fetch all the poll anwsers
                        $poll_answers = $stmt->fetchAll(PDO::FETCH_ASSOC);
                        // If the user clicked the "Vote" button...
                        if (isset($_POST['partij_standpunt'])) {
                            // Update and increase the vote for the answer the user voted for
                            $dbHandler->selectMening([ $_POST['partij_standpunt']]);
                            // Redirect user to the result page


                            // header('Location: result.php?id=' . $_GET['id']);
                            // exit;
                        }
                    }
                }
            ?>
            </table>
        </article>
    </div>
</body>

</html>